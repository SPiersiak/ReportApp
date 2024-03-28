using System;
using System.Collections.Generic;

namespace ReportInfrastructure.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
