// Annotations

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

class Teacher
{
    [Key]  //Этот атрибут обявляет свойство Первичным Ключом
    [Column("Id")] // TeacherId(EF) <-> Id (DB)
    public int TeacherId { get; set; }
    [Required] 
    [MaxLength(30)]
    public string? FirstName { get; set; }
    [Required]
    [MaxLength(50)]
    public string? LastName { get; set; }
    [Required]
    [Column(TypeName = "varchar(50)")] // TypeName указывает какого типа в БД будет этот столбец
    public string? Email { get; set; }
    public DateTime BirthDay { get; set; }
    public float Salary { get; set; }
    public float Bonus { get; set; }

}
