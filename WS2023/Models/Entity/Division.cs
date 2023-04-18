using System;
using System.Collections.Generic;

namespace WS2023.Models.Entity;

public partial class Division
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<PersonalVisit> PersonalVisits { get; set; } = new List<PersonalVisit>();

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
