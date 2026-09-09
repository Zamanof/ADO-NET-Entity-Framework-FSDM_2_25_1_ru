using System;
using System.Collections.Generic;

namespace EF_Core_01._Database_First_Scaffold;

public partial class Faculty
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
}
