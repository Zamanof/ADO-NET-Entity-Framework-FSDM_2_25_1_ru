// See https://aka.ms/new-console-template for more information

using StudentContext db = new();


var group = new Group()
{
    Name = "FSDM_2_25_1_ru",

    Students = new List<Student>
    {
        new Student
        {
            FirstName = "Said",
            LastName = "Babayev",
            BirthDay = new DateTime(2002, 6, 30)
        },

        new Student
        {
            FirstName = "Nihat",
            LastName = "Ahmadzada",
            BirthDay = new DateTime(2003, 3, 15)
        },

        new Student
        {
            FirstName = "Nicat",
            LastName = "Mahmudzada",
            BirthDay = new DateTime(2002, 9, 12)
        },

        new Student
        {
            FirstName = "Elchin",
            LastName = "Mehdi Garay",
            BirthDay = new DateTime(2003, 5, 21)
        },

        new Student
        {
            FirstName = "Kanan",
            LastName = "Mammadov",
            BirthDay = new DateTime(2002, 11, 8)
        },

        new Student
        {
            FirstName = "Elmi",
            LastName = "Nasirli",
            BirthDay = new DateTime(2003, 7, 17)
        },

        new Student
        {
            FirstName = "Elman",
            LastName = "Orucoglu",
            BirthDay = new DateTime(2002, 4, 25)
        }
    }
};

db.Groups.Add(group);

db.SaveChanges();
