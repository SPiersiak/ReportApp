namespace ReportInfrastructure.Dtos;
public class PaginnationPageResponseDto<T>
{
    public int PageIndex { get; set; }

    public int PageSize { get; set; }

    public int TotalRecords { get; set; }

    public List<T> DataCollection { get; set; }
}
