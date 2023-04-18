using System;
using System.Collections.Generic;

namespace WS2023.Models.Entity;

public partial class Worker
{
    public int Id { get; set; }

    public string? Fio { get; set; }

    public int? CodeUser { get; set; }

    public int? Division { get; set; }

    public int? Departament { get; set; }

    public virtual Division? DepartamentNavigation { get; set; }

    public virtual Departament? DivisionNavigation { get; set; }

    public virtual ICollection<PersonalVisit> PersonalVisits { get; set; } = new List<PersonalVisit>();
}
