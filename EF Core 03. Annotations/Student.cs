// Annotations

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

class Student
{
    public int Id { get; set; }

    [Required] // Этот атрибут указывает что столбец важный. На БД будет NOT NULL
    [MaxLength(30)]
    public string? FirstName { get; set; }

    [Required]
    [MaxLength(50)] // Этот атрибут указывает длину строки - nvarchar(50)
    public string? LastName { get; set; }

    [Required]
    [MaxLength(50)]
    public string? Email { get; set; }
    public DateTime BirthDay { get; set; }

    [ForeignKey("Group")]
    [Column("Id_Group")] // Этот атрибут указывает как будет указыватся имя столбца на БД 
    public int GroupId { get; set; } // Foreign Key

    public virtual Group Group { get; set; } // Navigation Property
}

// Entity Framework - Foreign Key and Navigation properties
// https://metanit.com/sharp/efcore/3.1.php