Student student = new()
{
    FirstName = "Salam",
    LastName = "Salamzade",
    BirthDay = new DateTime(2001, 2, 25)
};

StudentCard Card = new StudentCard()
{
    StartDate = new DateTime(2026, 9, 11),
    EndDate = new DateTime(2027, 9, 11),
    Student = student
};

#region Single class to DB
//using (var db = new StudentContext())
//{
//    db.Students.Add(student);
//    db.SaveChanges();
//}
#endregion

#region OneToOne
//using (var db = new StudentContext())
//{
//    db.StudentCards.Add(Card);
//    db.SaveChanges();
//}


using (var db = new StudentContext())
{
    var student1 = db.Students.First();
    var studentCard = db.StudentCards.First();
    //Console.WriteLine(student1);
    Console.WriteLine(studentCard);
    Console.WriteLine(studentCard.Student);
    
}
#endregion

