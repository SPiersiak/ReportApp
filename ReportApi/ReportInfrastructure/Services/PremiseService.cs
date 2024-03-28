using Microsoft.EntityFrameworkCore;
using ReportInfrastructure.Dtos;
using ReportInfrastructure.Models;
using ReportInfrastructure.Services.Interfaces;

namespace ReportInfrastructure.Services;
public class PremiseService : IPremiseService
{
    private readonly IDbContextFactory<ReportDbContext> _dbContextFactory;

    public PremiseService(IDbContextFactory<ReportDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<List<PremiseDto>> GetPremisesAsync()
    {
        using var context = _dbContextFactory.CreateDbContext();

        return await context.Premises
            .AsNoTracking()
            .Select(s => new PremiseDto()
            {
                Id = s.Id,
                PremiseName = s.PremiseName,
            }).ToListAsync();
    }
}
