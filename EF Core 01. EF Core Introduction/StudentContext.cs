// EF Core - Entity Framework Core
// ORM - Object-Relational Mapper

// Database First
// Code First

using Microsoft.EntityFrameworkCore;

class StudentContext: DbContext
{
    public DbSet<Student> Students { get; set; }
    public string ConnectionString { get; set; }

    public StudentContext(string connectionString)
    {
        ConnectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {        
        optionsBuilder.UseSqlServer(ConnectionString);
    }
}