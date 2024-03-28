using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReportInfrastructure.Query;
using ReportInfrastructure.Services.Interfaces;

namespace ReportApi.Controllers;
[Route("api/reports")]
[ApiController]
[EnableCors("OpenCORSPolicy")]
public class ReportsController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportsController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet]
    public async Task<IActionResult> GetReports([FromQuery]ReportQuery query)
    {
        var result = await _reportService.GetReportsAsync(query);

        return Ok(result);
    }
}
