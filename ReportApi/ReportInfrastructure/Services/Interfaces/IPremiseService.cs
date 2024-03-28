using ReportInfrastructure.Dtos;

namespace ReportInfrastructure.Services.Interfaces;
public interface IPremiseService
{
    Task<List<PremiseDto>> GetPremisesAsync();
}
