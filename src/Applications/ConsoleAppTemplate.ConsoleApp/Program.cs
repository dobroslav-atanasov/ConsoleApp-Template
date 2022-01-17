using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ConsoleAppTemplate.Constants;

namespace ConsoleAppTemplate.ConsoleApp;

public class Program
{
    public static async Task Main(string[] args)
    {
        var configuration = SetupConfiguration();
        var services = ConfigurationServiceProvider(configuration);

        var engine = services.GetService<Engine>();
        if (engine != null)
        {
            await engine.RunAsync();
        }
    }

    private static ServiceProvider ConfigurationServiceProvider(IConfiguration configuration)
    {
        var serviceProvider = new Startup(configuration)
            .ConfigurationServices()
            .BuildServiceProvider();

        return serviceProvider;            
    }

    private static IConfiguration SetupConfiguration()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile(GlobalConstants.APPLICATION_CONFIG_FILE, false, true)
            .Build();

        return configuration;
    }
}