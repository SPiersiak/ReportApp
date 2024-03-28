using Microsoft.AspNetCore.Mvc;
using ReportInfrastructure.Services.Interfaces;

namespace ReportApi.Controllers;
[Route("api/premises")]
[ApiController]
public class PremiseController : ControllerBase
{
    private readonly IPremiseService _premiseService;

    public PremiseController(IPremiseService premiseService)
    {
        _premiseService = premiseService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _premiseService.GetPremisesAsync();

        return Ok(result);
    }
}
