using System;
using System.Collections.Generic;

namespace EF_Core_01._Database_First_Scaffold;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
