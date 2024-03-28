using ReportInfrastructure;

namespace ReportApi;

public static class AppServiceCollection
{
    public static void AppConfigureServices(this IServiceCollection services)
    {
        services.RegisterReportInfrastructureServices(ApplicationConfiguration.GetConfiguration());
    }
}
