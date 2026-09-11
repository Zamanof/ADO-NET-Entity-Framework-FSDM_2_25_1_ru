
using Microsoft.EntityFrameworkCore;

class StudentContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }

    public StudentContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=OneToMany;Integrated Security=True;Trust Server Certificate=True;");
    }
}
