// Annotations

Console.WriteLine();

using (SchoolContext db = new SchoolContext())
{
    Student student = new()
    {
        FirstName = "Ali",
        LastName = "Aliyev",
        Email = "Ali@aliyev.com",
        BirthDay = new DateTime(2005, 10, 7)
    };
    db.Students.Add(student);

    Group group = new Group()
    {
        GroupName = "FSDM_2_25_1_ru",
        GroupRaiting = 9,
        CourseYear = 1,
        Students = [student]
    };
    db.Groups.Add(group);

    Student student1 = new()
    {
        FirstName = "Vali",
        LastName = "Valiyev",
        Email = "Vali@valiyev.com",
        BirthDay = new DateTime(2003, 2, 28),
        GroupId = 1
    };

    db.Students.Add(student1);

    db.Faculties.Add(new Faculty() { FacultyName = "Programming" });
    Department department = new()
    {
        DepartmentName = "Development"
    };
    db.Departments.Add(department);

    Teacher teacher = new()
    {
        FirstName = "Nadir",
        LastName = "Zamanov",
        Email = "Zamanov@itstep.org",
        BirthDay = new DateTime(1980, 10, 7),
        Salary = 2_350_890,
        Bonus = 3_000_000
    };

    Teacher teacher1 = new()
    {
        FirstName = "Ismayil",
        LastName = "Seyidmemmedli",
        Email = "Seyidmemmedli@itstep.org",
        BirthDay = new DateTime(1998, 11, 17),
        Salary = 5_000_000,
        Bonus = 4_000_000
    };

    db.Teachers.AddRange(teacher, teacher1);

    db.SaveChanges();
}

// ============================================================
// Entity Framework Core — Data Annotations
// ============================================================
//
// Data Annotations — атрибуты, которые позволяют настраивать
// модели Entity Framework Core непосредственно в классах.
//
// Обычно подключаются:
// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;
//
// ============================================================


// ------------------------------------------------------------
// [Key]
// ------------------------------------------------------------
// Указывает, что свойство является PRIMARY KEY.
//
// [Key]
// public int ProductId { get; set; }


// ------------------------------------------------------------
// [Required]
// ------------------------------------------------------------
// Поле является обязательным.
// Для строк обычно приводит к NOT NULL.
//
// [Required]
// public string Name { get; set; }


// ------------------------------------------------------------
// [MaxLength(n)]
// ------------------------------------------------------------
// Максимальная длина строки или массива.
// В БД, например, может создать NVARCHAR(100).
//
// [MaxLength(100)]
// public string Name { get; set; }


// ------------------------------------------------------------
// [StringLength(n)]
// ------------------------------------------------------------
// Максимальная длина строки.
// Также можно указать MinimumLength.
//
// [StringLength(100)]
// public string Name { get; set; }
//
// [StringLength(100, MinimumLength = 3)]
// public string Name { get; set; }
//
// ВАЖНО:
// MinimumLength используется для валидации,
// но не создаёт соответствующее ограничение длины в БД.


// ------------------------------------------------------------
// [Column]
// ------------------------------------------------------------
// Настраивает столбец таблицы.
//
// Можно изменить имя:
//
// [Column("product_name")]
// public string Name { get; set; }
//
// Можно указать SQL-тип:
//
// [Column(TypeName = "decimal(10,2)")]
// public decimal Price { get; set; }


// ------------------------------------------------------------
// [Table]
// ------------------------------------------------------------
// Позволяет указать имя таблицы.
//
// [Table("Products")]
// public class Product
// {
// }


// ------------------------------------------------------------
// [DatabaseGenerated]
// ------------------------------------------------------------
// Определяет, как генерируется значение свойства.
//
// DatabaseGeneratedOption.Identity
// Значение генерируется при добавлении записи.
//
// [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
// public int Id { get; set; }
//
//
// DatabaseGeneratedOption.Computed
// Значение вычисляется базой данных.
//
// [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
// public DateTime UpdatedAt { get; set; }
//
//
// DatabaseGeneratedOption.None
// Значение НЕ генерируется базой.
//
// [DatabaseGenerated(DatabaseGeneratedOption.None)]
// public int Id { get; set; }


// ------------------------------------------------------------
// [NotMapped]
// ------------------------------------------------------------
// Свойство НЕ должно сохраняться в базе данных.
//
// [NotMapped]
// public decimal TotalPrice
// {
//     get { return Price * Quantity; }
// }


// ------------------------------------------------------------
// [ForeignKey]
// ------------------------------------------------------------
// Явно указывает FOREIGN KEY.
//
// public int CategoryId { get; set; }
//
// [ForeignKey("CategoryId")]
// public Category Category { get; set; }
//
// Можно написать и наоборот:
//
// [ForeignKey("Category")]
// public int CategoryId { get; set; }
//
// public Category Category { get; set; }


// ------------------------------------------------------------
// [InverseProperty]
// ------------------------------------------------------------
// Помогает EF определить связь, если между двумя сущностями
// существует несколько отношений.
//
// Например, у Employee есть CreatedDocuments
// и ApprovedDocuments.
//
// [InverseProperty("Creator")]
// public ICollection<Document> CreatedDocuments { get; set; }
//
// [InverseProperty("Approver")]
// public ICollection<Document> ApprovedDocuments { get; set; }


// ------------------------------------------------------------
// [Timestamp]
// ------------------------------------------------------------
// Используется для optimistic concurrency.
//
// Обычно применяется к byte[].
//
// [Timestamp]
// public byte[] RowVersion { get; set; }
//
// EF сможет определить, что запись была изменена другим
// пользователем после того, как мы её прочитали.


// ------------------------------------------------------------
// [ConcurrencyCheck]
// ------------------------------------------------------------
// Указывает, что свойство участвует в проверке concurrency.
//
// [ConcurrencyCheck]
// public string Name { get; set; }


// ============================================================
// Data Annotations для ВАЛИДАЦИИ
// ============================================================
//
// Эти атрибуты относятся прежде всего к валидации данных.
// Некоторые из них практически не влияют на структуру БД.


// ------------------------------------------------------------
// [Range]
// ------------------------------------------------------------
// Проверяет диапазон значения.
//
// [Range(0, 10000)]
// public decimal Price { get; set; }
//
// [Range(1, 120)]
// public int Age { get; set; }


// ------------------------------------------------------------
// [MinLength]
// ------------------------------------------------------------
// Минимальная длина.
//
// [MinLength(3)]
// public string Name { get; set; }


// ------------------------------------------------------------
// [MaxLength]
// ------------------------------------------------------------
// Максимальная длина.
//
// [MaxLength(100)]
// public string Name { get; set; }


// ------------------------------------------------------------
// [EmailAddress]
// ------------------------------------------------------------
// Проверяет формат email.
//
// [EmailAddress]
// public string Email { get; set; }


// ------------------------------------------------------------
// [Phone]
// ------------------------------------------------------------
// Проверяет формат телефонного номера.
//
// [Phone]
// public string PhoneNumber { get; set; }


// ------------------------------------------------------------
// [Url]
// ------------------------------------------------------------
// Проверяет URL.
//
// [Url]
// public string Website { get; set; }


// ------------------------------------------------------------
// [RegularExpression]
// ------------------------------------------------------------
// Валидация с помощью регулярного выражения.
//
// [RegularExpression(@"^[A-Za-z]+$")]
// public string Name { get; set; }


// ------------------------------------------------------------
// [Compare]
// ------------------------------------------------------------
// Сравнивает значение с другим свойством.
// Часто используется для подтверждения пароля.
//
// public string Password { get; set; }
//
// [Compare("Password")]
// public string ConfirmPassword { get; set; }


// ============================================================
// Пример Entity
// ============================================================
//
// [Table("Products")]
// public class Product
// {
//     [Key]
//     public int Id { get; set; }
//
//     [Required]
//     [MaxLength(100)]
//     [Column("product_name")]
//     public string Name { get; set; }
//
//     [Column(TypeName = "decimal(10,2)")]
//     [Range(0, 100000)]
//     public decimal Price { get; set; }
//
//     public int CategoryId { get; set; }
//
//     [ForeignKey("CategoryId")]
//     public Category Category { get; set; }
//
//     [NotMapped]
//     public string DisplayName
//     {
//         get { return $"{Name} - {Price}"; }
//     }
//
//     [Timestamp]
//     public byte[] RowVersion { get; set; }
// }


// ============================================================
// Краткая шпаргалка
// ============================================================
//
// [Key]               -> Primary Key
// [Required]          -> обязательное значение / NOT NULL
// [MaxLength]         -> максимальная длина
// [StringLength]      -> ограничение длины + validation
// [Column]            -> настройка столбца
// [Table]             -> имя таблицы
// [NotMapped]         -> не добавлять свойство в БД
// [ForeignKey]        -> внешний ключ
// [InverseProperty]   -> уточнение отношений между Entity
// [DatabaseGenerated] -> генерация значения БД
// [Timestamp]         -> optimistic concurrency
// [ConcurrencyCheck]  -> проверка конкурентного изменения
//
// Validation:
//
// [Range]              -> диапазон значений
// [MinLength]          -> минимальная длина
// [MaxLength]          -> максимальная длина
// [EmailAddress]       -> проверка email
// [Phone]              -> проверка телефона
// [Url]                -> проверка URL
// [RegularExpression] -> проверка RegEx
// [Compare]            -> сравнение двух свойств
//
// ============================================================
// ВАЖНО
// ============================================================
//
// В EF Core есть три основных способа настройки модели:
//
// 1. Conventions
//    EF сам определяет структуру по именам и типам свойств.
//
// 2. Data Annotations
//    [Key], [Required], [MaxLength], [ForeignKey] и т.д.
//
// 3. Fluent API
//    Настройка через ModelBuilder в OnModelCreating().
//
// Fluent API имеет более широкие возможности, чем
// Data Annotations, и имеет приоритет над ними.
//
// ============================================================