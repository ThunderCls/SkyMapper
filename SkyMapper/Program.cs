using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using SkyMapper.DataAccess;
using SkyMapper.Services;
using SkyMapper.UI;

namespace SkyMapper;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var configuration = BuildConfiguration(hostingContext);
                    BuildLogger(configuration);
                    config.Sources.Clear();
                    config.AddConfiguration(configuration);
                })
                .ConfigureServices(SetupServices)
                .UseSerilog()
                .Build();

        using var scope = host.Services.CreateScope();
        var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
        using var dbContext = dbContextFactory.CreateDbContext();
        dbContext.Database.Migrate();
        
        var application = host.Services.GetService<FrmMain>()!;
        Application.Run(application);
    }

    private static void SetupServices(HostBuilderContext hostBuilderContext, IServiceCollection services)
    {
        services.AddSingleton<FrmMain>();
        services.AddTransient<WorkerService>();
        services.AddTransient<DataService>();

        services.AddDbContextFactory<AppDbContext>(options =>
        {
            options.UseSqlite("Data Source=data.db");
        });
    }

    private static IConfiguration BuildConfiguration(HostBuilderContext hostBuilderContext)
    {
        var environment = hostBuilderContext.HostingEnvironment;

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", true, true)
            .AddEnvironmentVariables();

        if (environment.IsDevelopment())
        {
            config.AddUserSecrets<FrmMain>(true);
        }
        return config.Build();
    }

    private static void BuildLogger(IConfiguration configuration)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .CreateLogger();
    }
}