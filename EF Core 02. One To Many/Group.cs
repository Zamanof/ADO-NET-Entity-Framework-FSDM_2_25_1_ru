// See https://aka.ms/new-console-template for more information
class Group
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Student> Students { get; set; }

    public override string ToString()
    {
        return $"{Name}";
    }
}
