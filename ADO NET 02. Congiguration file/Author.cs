// Configuration file

// connection string in code file (hard code) - not secure
//string connectionString = @"
//Server=(localdb)\MSSQLLocalDB;
//Database=Library;
//Integrated Security=True;
//Trust Server Certificate=True;";

class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public override string ToString()
    {
        return $"{Id}. {FirstName} {LastName}";
    }
}
