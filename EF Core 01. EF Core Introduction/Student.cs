// EF Core - Entity Framework Core
// ORM - Object-Relational Mapper

// Database First
// Code First


class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Group { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"{Id}. {FirstName} {LastName} -> {Age}";
    }
}
