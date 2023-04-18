using System;
using System.Collections.Generic;

namespace WS2023.Models.Entity;

public partial class StatusesVisit
{
    public int Id { get; set; }

    public int Status { get; set; }

    public string? Description { get; set; }

    public int PersonalVisit { get; set; }

    public virtual PersonalVisit PersonalVisitNavigation { get; set; } = null!;
}
