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