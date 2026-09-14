// Annotations

using Microsoft.EntityFrameworkCore;

class SchoolContext : DbContext
{
    public SchoolContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Department> Departments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SchoolWithFluentApi;Integrated Security=True;Trust Server Certificate=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Group
        modelBuilder
            .Entity<Group>()
            .Property(g => g.GroupName)
            .IsRequired()
            .HasMaxLength(20);

        modelBuilder
            .Entity<Group>()
            .HasIndex(g => g.GroupName)
            .IsUnique();

        modelBuilder
            .Entity<Group>()
            .Property(g => g.Id)
            .ValueGeneratedOnAdd();

        modelBuilder
            .Entity<Group>()
            .ToTable(g => g.HasCheckConstraint("CK_CourseYear"
            , "CourseYear >= 1 AND CourseYear <= 4"));

        modelBuilder
            .Entity<Group>()
            .ToTable(g => g.HasCheckConstraint("CK_GroupRating"
            , "GroupRating >= 1 AND GroupRating <= 12"));

        // Teacher
        modelBuilder
            .Entity<Teacher>()
            .Property(t => t.TeacherId)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd();

        modelBuilder
            .Entity<Teacher>()
            .Property(t => t.FirstName)
            .IsRequired()
            .HasMaxLength(30);

        modelBuilder
            .Entity<Teacher>()
            .Property(t => t.LastName)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder
            .Entity<Teacher>()
            .Property(t => t.Email)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(50);

        modelBuilder
            .Entity<Teacher>()
            .HasIndex(g => g.Email)
            .IsUnique()
            .HasDatabaseName("UQ_Email");



        // Student
        modelBuilder
            .Entity<Student>()
            .HasOne(s => s.Group)
            .WithMany(g => g.Students)
            .HasForeignKey(s => s.GroupId)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK_Groups_Students");

        modelBuilder
            .Entity<Student>()
            .Property(s => s.FirstName)
            .IsRequired()
            .HasMaxLength(30);

        modelBuilder
            .Entity<Student>()
            .Property(s => s.LastName)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder
            .Entity<Student>()
            .Property(s => s.Email)
            .IsRequired()
            .HasColumnType("varchar")
            .HasMaxLength(50);

        modelBuilder
            .Entity<Student>()
            .Property(s => s.GroupId)
            .HasColumnName("Id_Group");

    }
}

// ============================================================
// Entity Framework Core — Fluent API
// ============================================================
//
// Fluent API используется для настройки моделей EF Core
// внутри метода:
//
// protected override void OnModelCreating(ModelBuilder modelBuilder)
//
// Fluent API более гибкий, чем Data Annotations.
// Если настройка указана и через Data Annotations,
// и через Fluent API — приоритет имеет Fluent API.
//
// ============================================================


// ------------------------------------------------------------
// Базовый пример DbContext
// ------------------------------------------------------------
//
// public class AppDbContext : DbContext
// {
//     public DbSet<Product> Products { get; set; }
//
//     protected override void OnModelCreating(ModelBuilder modelBuilder)
//     {
//         base.OnModelCreating(modelBuilder);
//
//         // Настройки моделей находятся здесь
//     }
// }


// ============================================================
// Entity
// ============================================================
//
// Для настройки конкретной сущности используется:
//
// modelBuilder.Entity<Product>();
//
//
// Часто создаётся переменная:
//
// var product = modelBuilder.Entity<Product>();
//
// После этого:
//
// product.HasKey(...);
// product.Property(...);
// product.HasOne(...);
//
// ============================================================


// ------------------------------------------------------------
// ToTable
// ------------------------------------------------------------
// Указывает имя таблицы.
//
// modelBuilder.Entity<Product>()
//     .ToTable("Products");
//
//
// Можно указать schema:
//
// modelBuilder.Entity<Product>()
//     .ToTable("Products", "shop");
//
//
// SQL примерно:
//
// shop.Products


// ------------------------------------------------------------
// HasKey
// ------------------------------------------------------------
// Указывает PRIMARY KEY.
//
// modelBuilder.Entity<Product>()
//     .HasKey(p => p.Id);
//
//
// Составной Primary Key:
//
// modelBuilder.Entity<OrderProduct>()
//     .HasKey(op => new
//     {
//         op.OrderId,
//         op.ProductId
//     });


// ------------------------------------------------------------
// Property
// ------------------------------------------------------------
// Начинает настройку свойства.
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.Name);
//
//
// Обычно Property используется вместе с другими настройками:
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.Name)
//     .IsRequired()
//     .HasMaxLength(100);


// ------------------------------------------------------------
// IsRequired
// ------------------------------------------------------------
// Делает поле обязательным.
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.Name)
//     .IsRequired();
//
//
// Обычно соответствует:
//
// NOT NULL


// ------------------------------------------------------------
// IsRequired(false)
// ------------------------------------------------------------
// Разрешает NULL.
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.Description)
//     .IsRequired(false);
//
//
// Обычно соответствует:
//
// NULL


// ------------------------------------------------------------
// HasMaxLength
// ------------------------------------------------------------
// Максимальная длина строки.
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.Name)
//     .HasMaxLength(100);
//
//
// Например для SQL Server:
//
// NVARCHAR(100)


// ------------------------------------------------------------
// HasColumnName
// ------------------------------------------------------------
// Изменяет имя столбца.
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.Name)
//     .HasColumnName("product_name");


// ------------------------------------------------------------
// HasColumnType
// ------------------------------------------------------------
// Явно задаёт тип SQL.
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.Price)
//     .HasColumnType("decimal(10,2)");


// ------------------------------------------------------------
// HasPrecision
// ------------------------------------------------------------
// Настраивает decimal без прямого указания SQL типа.
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.Price)
//     .HasPrecision(10, 2);
//
//
// означает:
//
// decimal(10,2)


// ------------------------------------------------------------
// HasDefaultValue
// ------------------------------------------------------------
// Задаёт значение по умолчанию.
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.IsActive)
//     .HasDefaultValue(true);
//
//
// SQL примерно:
//
// DEFAULT 1


// ------------------------------------------------------------
// HasDefaultValueSql
// ------------------------------------------------------------
// Значение по умолчанию вычисляется самой БД.
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.CreatedAt)
//     .HasDefaultValueSql("GETDATE()");
//
//
// PostgreSQL пример:
//
// .HasDefaultValueSql("CURRENT_TIMESTAMP");


// ------------------------------------------------------------
// HasComputedColumnSql
// ------------------------------------------------------------
// Вычисляемый столбец.
//
// modelBuilder.Entity<Order>()
//     .Property(o => o.Total)
//     .HasComputedColumnSql("[Price] * [Quantity]");
//
//
// Значение вычисляет база данных.


// ------------------------------------------------------------
// ValueGeneratedOnAdd
// ------------------------------------------------------------
// Значение генерируется при INSERT.
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.Id)
//     .ValueGeneratedOnAdd();


// ------------------------------------------------------------
// ValueGeneratedOnAddOrUpdate
// ------------------------------------------------------------
// Значение генерируется при INSERT и UPDATE.
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.ModifiedAt)
//     .ValueGeneratedOnAddOrUpdate();


// ------------------------------------------------------------
// ValueGeneratedNever
// ------------------------------------------------------------
// EF не должен считать, что значение генерирует БД.
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.Id)
//     .ValueGeneratedNever();


// ============================================================
// IGNORE
// ============================================================


// ------------------------------------------------------------
// Ignore
// ------------------------------------------------------------
// Свойство не должно попадать в БД.
//
// modelBuilder.Entity<Product>()
//     .Ignore(p => p.DisplayName);
//
//
// Аналог:
//
// [NotMapped]


// ============================================================
// INDEXES
// ============================================================


// ------------------------------------------------------------
// HasIndex
// ------------------------------------------------------------
// Создаёт индекс.
//
// modelBuilder.Entity<User>()
//     .HasIndex(u => u.Email);


// ------------------------------------------------------------
// IsUnique
// ------------------------------------------------------------
// Создаёт UNIQUE INDEX.
//
// modelBuilder.Entity<User>()
//     .HasIndex(u => u.Email)
//     .IsUnique();
//
//
// SQL примерно:
//
// UNIQUE INDEX


// ------------------------------------------------------------
// Составной индекс
// ------------------------------------------------------------
//
// modelBuilder.Entity<Student>()
//     .HasIndex(s => new
//     {
//         s.FirstName,
//         s.LastName
//     });


// ============================================================
// RELATIONSHIPS
// ============================================================


// ------------------------------------------------------------
// One-to-Many
// ------------------------------------------------------------
//
// Например:
//
// Category
//     |
//     | 1
//     |
//     | *
// Product
//
//
// Category:
// public ICollection<Product> Products { get; set; }
//
// Product:
// public int CategoryId { get; set; }
// public Category Category { get; set; }
//
//
// Fluent API:
//
// modelBuilder.Entity<Product>()
//     .HasOne(p => p.Category)
//     .WithMany(c => c.Products)
//     .HasForeignKey(p => p.CategoryId);
//
//
// Читается:
//
// Product HAS ONE Category
// Category WITH MANY Products
// Foreign Key = Product.CategoryId


// ------------------------------------------------------------
// One-to-Many без navigation property с одной стороны
// ------------------------------------------------------------
//
// modelBuilder.Entity<Product>()
//     .HasOne(p => p.Category)
//     .WithMany()
//     .HasForeignKey(p => p.CategoryId);


// ------------------------------------------------------------
// One-to-One
// ------------------------------------------------------------
//
// Например:
//
// User
// |
// | 1
// |
// | 1
// UserProfile
//
//
// modelBuilder.Entity<User>()
//     .HasOne(u => u.Profile)
//     .WithOne(p => p.User)
//     .HasForeignKey<UserProfile>(p => p.UserId);
//
//
// HasForeignKey<UserProfile>
// означает, что FK находится в UserProfile.


// ------------------------------------------------------------
// Many-to-Many
// ------------------------------------------------------------
//
// Например:
//
// Student <----> Course
//
//
// Student:
// public ICollection<Course> Courses { get; set; }
//
// Course:
// public ICollection<Student> Students { get; set; }
//
//
// modelBuilder.Entity<Student>()
//     .HasMany(s => s.Courses)
//     .WithMany(c => c.Students);
//
//
// EF Core самостоятельно создаст промежуточную таблицу.


// ------------------------------------------------------------
// Many-to-Many с собственной промежуточной Entity
// ------------------------------------------------------------
//
// Например:
//
// StudentCourse
//
// StudentId
// CourseId
// EnrolledAt
//
//
// modelBuilder.Entity<StudentCourse>()
//     .HasKey(sc => new
//     {
//         sc.StudentId,
//         sc.CourseId
//     });
//
//
// modelBuilder.Entity<StudentCourse>()
//     .HasOne(sc => sc.Student)
//     .WithMany(s => s.StudentCourses)
//     .HasForeignKey(sc => sc.StudentId);
//
//
// modelBuilder.Entity<StudentCourse>()
//     .HasOne(sc => sc.Course)
//     .WithMany(c => c.StudentCourses)
//     .HasForeignKey(sc => sc.CourseId);


// ============================================================
// DELETE BEHAVIOR
// ============================================================


// ------------------------------------------------------------
// OnDelete
// ------------------------------------------------------------
// Настраивает поведение при удалении связанной записи.
//
// modelBuilder.Entity<Product>()
//     .HasOne(p => p.Category)
//     .WithMany(c => c.Products)
//     .HasForeignKey(p => p.CategoryId)
//     .OnDelete(DeleteBehavior.Cascade);


// ------------------------------------------------------------
// DeleteBehavior.Cascade
// ------------------------------------------------------------
// Если удалить родителя,
// связанные дочерние записи тоже удалятся.
//
// Category удалена
//     ->
// Products удаляются.


// ------------------------------------------------------------
// DeleteBehavior.Restrict
// ------------------------------------------------------------
// Нельзя удалить родителя,
// пока существуют связанные записи.
//
// .OnDelete(DeleteBehavior.Restrict);


// ------------------------------------------------------------
// DeleteBehavior.NoAction
// ------------------------------------------------------------
// EF не создаёт автоматическое каскадное действие.
//
// .OnDelete(DeleteBehavior.NoAction);


// ------------------------------------------------------------
// DeleteBehavior.SetNull
// ------------------------------------------------------------
// При удалении родителя FK становится NULL.
//
// .OnDelete(DeleteBehavior.SetNull);
//
// ВАЖНО:
// FK должен быть nullable.
//
// public int? CategoryId { get; set; }


// ============================================================
// CONCURRENCY
// ============================================================


// ------------------------------------------------------------
// IsConcurrencyToken
// ------------------------------------------------------------
// Свойство участвует в Optimistic Concurrency.
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.Name)
//     .IsConcurrencyToken();


// ------------------------------------------------------------
// IsRowVersion
// ------------------------------------------------------------
// Настройка RowVersion / Timestamp.
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.RowVersion)
//     .IsRowVersion();
//
// Обычно:
//
// public byte[] RowVersion { get; set; }


// ============================================================
// DATA SEEDING
// ============================================================


// ------------------------------------------------------------
// HasData
// ------------------------------------------------------------
// Добавляет начальные данные.
//
// modelBuilder.Entity<Category>()
//     .HasData(
//         new Category
//         {
//             Id = 1,
//             Name = "Backend"
//         },
//         new Category
//         {
//             Id = 2,
//             Name = "Frontend"
//         }
//     );
//
//
// Эти данные будут добавлены через migration.


// ============================================================
// ALTERNATE KEY
// ============================================================


// ------------------------------------------------------------
// HasAlternateKey
// ------------------------------------------------------------
// Создаёт дополнительный уникальный ключ,
// который может использоваться в relationship.
//
// modelBuilder.Entity<User>()
//     .HasAlternateKey(u => u.Email);
//
//
// Это не то же самое, что обычный INDEX.
// Alternate Key является candidate key.


// ============================================================
// COMPOSITE KEY
// ============================================================
//
// modelBuilder.Entity<StudentCourse>()
//     .HasKey(sc => new
//     {
//         sc.StudentId,
//         sc.CourseId
//     });
//
//
// PRIMARY KEY:
//
// StudentId + CourseId


// ============================================================
// Пример полной настройки Product
// ============================================================
//
// protected override void OnModelCreating(ModelBuilder modelBuilder)
// {
//     base.OnModelCreating(modelBuilder);
//
//     var product = modelBuilder.Entity<Product>();
//
//     product.ToTable("Products");
//
//     product.HasKey(p => p.Id);
//
//     product.Property(p => p.Name)
//         .IsRequired()
//         .HasMaxLength(100)
//         .HasColumnName("product_name");
//
//     product.Property(p => p.Description)
//         .HasMaxLength(500);
//
//     product.Property(p => p.Price)
//         .HasPrecision(10, 2);
//
//     product.Property(p => p.IsActive)
//         .HasDefaultValue(true);
//
//     product.Property(p => p.CreatedAt)
//         .HasDefaultValueSql("GETDATE()");
//
//     product.Ignore(p => p.DisplayName);
//
//     product.HasIndex(p => p.Name);
//
//     product.HasOne(p => p.Category)
//         .WithMany(c => c.Products)
//         .HasForeignKey(p => p.CategoryId)
//         .OnDelete(DeleteBehavior.Restrict);
// }


// ============================================================
// Краткая шпаргалка Fluent API
// ============================================================
//
// modelBuilder.Entity<T>()
//     -> настройка Entity
//
// .ToTable()
//     -> имя таблицы
//
// .HasKey()
//     -> Primary Key
//
// .Property()
//     -> настройка свойства
//
// .IsRequired()
//     -> NOT NULL
//
// .HasMaxLength()
//     -> максимальная длина
//
// .HasColumnName()
//     -> имя столбца
//
// .HasColumnType()
//     -> SQL тип
//
// .HasPrecision()
//     -> precision / scale для decimal
//
// .HasDefaultValue()
//     -> default значение
//
// .HasDefaultValueSql()
//     -> default SQL expression
//
// .HasComputedColumnSql()
//     -> вычисляемый столбец
//
// .Ignore()
//     -> не добавлять свойство в БД
//
// .HasIndex()
//     -> индекс
//
// .IsUnique()
//     -> UNIQUE индекс
//
// .HasOne()
//     -> Entity имеет одну связанную Entity
//
// .HasMany()
//     -> Entity имеет много связанных Entity
//
// .WithOne()
//     -> обратная сторона One
//
// .WithMany()
//     -> обратная сторона Many
//
// .HasForeignKey()
//     -> Foreign Key
//
// .OnDelete()
//     -> поведение при DELETE
//
// .IsConcurrencyToken()
//     -> optimistic concurrency
//
// .IsRowVersion()
//     -> rowversion / timestamp
//
// .HasData()
//     -> начальные данные
//
// .HasAlternateKey()
//     -> Alternate Key
//
// ============================================================
// Связи — очень коротко
// ============================================================
//
// ONE-TO-MANY:
//
// HasOne()
//     .WithMany()
//     .HasForeignKey();
//
//
// ONE-TO-ONE:
//
// HasOne()
//     .WithOne()
//     .HasForeignKey();
//
//
// MANY-TO-MANY:
//
// HasMany()
//     .WithMany();
//
//
// ============================================================
// Data Annotations vs Fluent API
// ============================================================
//
// Data Annotation:
//
// [Required]
// [MaxLength(100)]
// public string Name { get; set; }
//
//
// Fluent API:
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.Name)
//     .IsRequired()
//     .HasMaxLength(100);
//
//
// ------------------------------------------------------------
//
// Data Annotation:
//
// [Key]
// public int Id { get; set; }
//
//
// Fluent:
//
// modelBuilder.Entity<Product>()
//     .HasKey(p => p.Id);
//
//
// ------------------------------------------------------------
//
// Data Annotation:
//
// [NotMapped]
// public string DisplayName { get; set; }
//
//
// Fluent:
//
// modelBuilder.Entity<Product>()
//     .Ignore(p => p.DisplayName);
//
//
// ------------------------------------------------------------
//
// Data Annotation:
//
// [Column(TypeName = "decimal(10,2)")]
// public decimal Price { get; set; }
//
//
// Fluent:
//
// modelBuilder.Entity<Product>()
//     .Property(p => p.Price)
//     .HasPrecision(10, 2);
//
//
// ============================================================
// ВАЖНО
// ============================================================
//
// В EF Core настройка обычно идёт по приоритету:
//
// Conventions
//       ↓
// Data Annotations
//       ↓
// Fluent API
//
// Fluent API имеет самый высокий приоритет.
//
// Для небольших проектов можно использовать Data Annotations.
//
// Для сложных моделей, relationships, composite keys,
// indexes, delete behavior и точной настройки БД
// обычно удобнее Fluent API.
//
// ============================================================