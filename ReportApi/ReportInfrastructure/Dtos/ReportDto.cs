namespace ReportInfrastructure.Dtos;
public class ReportDto
{
    public string ReportName { get; set; }

    public DateTime ReportDate { get; set; }

    public TimeSpan ReportTime { get; set; }

    public string UserName { get; set; }

    public string PremisesName { get; set; }
}
