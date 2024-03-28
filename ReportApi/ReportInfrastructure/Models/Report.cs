using System;
using System.Collections.Generic;

namespace ReportInfrastructure.Models;

public partial class Report
{
    public int Id { get; set; }

    public string? ReportName { get; set; }

    public DateTime ReportDateTime { get; set; }

    public int UserId { get; set; }

    public int PremiseId { get; set; }

    public virtual Premise Premise { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
