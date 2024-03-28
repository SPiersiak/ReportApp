using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ReportInfrastructure.Services.Interfaces;

namespace ReportApi.Controllers;
[ApiController]
[Route("api/premises")]
[EnableCors("OpenCORSPolicy")]
public class PremiseController : ControllerBase
{
    private readonly IPremiseService _premiseService;

    public PremiseController(IPremiseService premiseService)
    {
        _premiseService = premiseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPremises()
    {
        var result = await _premiseService.GetPremisesAsync();

        return Ok(result);
    }
}
