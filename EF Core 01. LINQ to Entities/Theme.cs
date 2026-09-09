using System;
using System.Collections.Generic;

namespace EF_Core_01._LINQ_to_Entities;

public partial class Theme
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
