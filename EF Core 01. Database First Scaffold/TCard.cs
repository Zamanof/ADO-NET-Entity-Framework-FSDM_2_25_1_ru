using System;
using System.Collections.Generic;

namespace EF_Core_01._Database_First_Scaffold;

public partial class TCard
{
    public int Id { get; set; }

    public int IdTeacher { get; set; }

    public int IdBook { get; set; }

    public DateTime DateOut { get; set; }

    public DateTime? DateIn { get; set; }

    public int IdLib { get; set; }

    public virtual Book IdBookNavigation { get; set; } = null!;

    public virtual Lib IdLibNavigation { get; set; } = null!;

    public virtual Teacher IdTeacherNavigation { get; set; } = null!;
}
