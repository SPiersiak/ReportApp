using Microsoft.EntityFrameworkCore;
using ReportInfrastructure.Dtos;
using ReportInfrastructure.Models;
using ReportInfrastructure.Query;
using ReportInfrastructure.Services.Interfaces;

namespace ReportInfrastructure.Services;
public class ReportService : IReportService
{
    private readonly IDbContextFactory<ReportDbContext> _contextFactory;

    public ReportService(IDbContextFactory<ReportDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<PaginnationPageResponseDto<ReportDto>> GetReportsAsync(ReportQuery query)
    {
        using var context = _contextFactory.CreateDbContext();

        var resultQuery = context.Reports
            .Where(x => x.ReportDateTime.Date >= (query.DateFrom ?? DateTime.MinValue.Date) && x.ReportDateTime.Date <= (query.DateTo ?? DateTime.MaxValue.Date))
            .Include(i => i.User)
            .Include(i => i.Premise)
            .AsQueryable();

        if (query.PremisesId.HasValue)
        {
            resultQuery = resultQuery.Where(x => x.PremiseId == query.PremisesId.Value);
        }

        var result = new PaginnationPageResponseDto<ReportDto>();

        result.TotalRecords = await resultQuery.CountAsync();
        result.PageIndex = query.PageIndex;
        result.PageSize = query.PageSize;

        var skip = (query.PageIndex - 1) * query.PageSize;

        result.DataCollection = await resultQuery
            .AsNoTracking()
            .Skip(skip).Take(query.PageSize)
            .Select(s => new ReportDto()
            {
                ReportName = s.ReportName,
                ReportDate = s.ReportDateTime.Date,
                ReportTime = s.ReportDateTime.TimeOfDay,
                UserName = s.User.UserName,
                PremisesName = s.Premise.PremiseName,
            }).ToListAsync();

        return result;
    }
}
