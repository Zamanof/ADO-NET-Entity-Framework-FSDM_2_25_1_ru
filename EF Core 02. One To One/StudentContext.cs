using Microsoft.EntityFrameworkCore;

#region One Class To DB
//class StudentContext : DbContext
//{
//    public DbSet<Student> Students { get; set; }

//    public StudentContext()
//    {
//        Database.EnsureDeleted();
//        Database.EnsureCreated();
//    }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//    {

//        optionsBuilder
//            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=MyStudent;Integrated Security=True;Trust Server Certificate=True;");
//    }
//}
#endregion

#region One to One DbContext
class StudentContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<StudentCard> StudentCards { get; set; }

    public StudentContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=OneToOne;Integrated Security=True;Trust Server Certificate=True;");
    }
}
#endregion
