namespace ReportInfrastructure.Query;
public class ReportQuery
{
    public long? PremisesId { get; set; }

    public DateTime? DateFrom { get; set; }

    public DateTime? DateTo { get; set; }

    public int PageIndex { get; set; }

    public int PageSize { get; set; }
}
