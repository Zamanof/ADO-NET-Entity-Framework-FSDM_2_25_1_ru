
using Microsoft.EntityFrameworkCore;

class BookContext : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    public BookContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ManyToMany;Integrated Security=True;Trust Server Certificate=True;");
    }
}