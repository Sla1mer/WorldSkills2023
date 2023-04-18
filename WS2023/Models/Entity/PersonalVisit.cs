using System;
using System.Collections.Generic;

namespace WS2023.Models.Entity;

public partial class PersonalVisit
{
    public int Id { get; set; }

    public DateTime DateSubmitted { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateFinish { get; set; }

    public int? Visitor { get; set; }

    public int? Purpose { get; set; }

    public int? Division { get; set; }

    public int? Worker { get; set; }

    public string? Surname { get; set; } = null!;

    public string? Name { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; } = null!;

    public string? Organization { get; set; }

    public string? Description { get; set; }

    public DateTime? Birthday { get; set; }

    public string? SeriaPassport { get; set; } = null!;

    public string? NumberPassport { get; set; } = null!;

    public byte[]? ScanPassport { get; set; } = null!;

    public virtual Division DivisionNavigation { get; set; } = null!;

    public virtual ICollection<GroupVisit> GroupVisits { get; set; } = new List<GroupVisit>();

    public virtual Purpose PurposeNavigation { get; set; } = null!;

    public virtual ICollection<StatusesVisit> StatusesVisits { get; set; } = new List<StatusesVisit>();

    public virtual User VisitorNavigation { get; set; } = null!;

    public virtual Worker WorkerNavigation { get; set; } = null!;
}
