using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReportInfrastructure.Models;
using ReportInfrastructure.Services;
using ReportInfrastructure.Services.Interfaces;

namespace ReportInfrastructure;
public static class ReportInfrastructureServiceCollection
{
    public static void RegisterReportInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<ReportDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("ReportDB")));

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddTransient<IReportService, ReportService>();
        services.AddTransient<IPremiseService, PremiseService>();
    }
}
