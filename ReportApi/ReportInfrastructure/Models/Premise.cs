using System;
using System.Collections.Generic;

namespace ReportInfrastructure.Models;

public partial class Premise
{
    public int Id { get; set; }

    public string? PremiseName { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
