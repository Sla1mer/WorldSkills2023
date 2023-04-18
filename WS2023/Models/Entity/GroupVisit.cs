using System;
using System.Collections.Generic;

namespace WS2023.Models.Entity;

public partial class GroupVisit
{
    public int Id { get; set; }

    public int? Number { get; set; }

    public string? Fio { get; set; } = null!;

    public string? PhoneNumber { get; set; } = null!;

    public string? Email { get; set; } = null!;

    public int? ParentVisit { get; set; }

    public byte[]? Avatar { get; set; }

    public virtual PersonalVisit? ParentVisitNavigation { get; set; } = null!;
}
