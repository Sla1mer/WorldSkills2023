using System;
using System.Collections.Generic;

namespace WS2023.Models.Entity;

public partial class Departament
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();
}
