namespace ReportApi;

public static class ApplicationConfiguration
{
    private static IConfiguration _configuration;
    static ApplicationConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        _configuration = builder.Build();
    }

    public static IConfiguration GetConfiguration()
    {
        return _configuration;
    }
}
