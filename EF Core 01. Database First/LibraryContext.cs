// Database First
using Microsoft.EntityFrameworkCore;

class LibraryContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Lib> Libs { get; set; }
    public string ConnectionString { get; set; }

    public LibraryContext(string connectionString)
    {
        ConnectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(ConnectionString);
    }
}