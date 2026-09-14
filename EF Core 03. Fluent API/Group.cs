// Annotations
class Group
{
    public int Id { get; set; }  
    public string? GroupName { get; set; } 
    public int GroupRating { get; set; }
    public int CourseYear { get; set; }
    public List<Student> Students { get; set; } = [];
}
