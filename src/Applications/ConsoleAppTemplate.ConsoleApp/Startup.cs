namespace ConsoleAppTemplate.ConsoleApp;

using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Common.Constants;
using Services;
using Services.Interfaces;
using Services.Mapper;

internal class Startup
{
    private IConfiguration configuration;
    private readonly ServiceCollection services;

    public Startup(IConfiguration configuration)
    {
        this.configuration = configuration;
        this.services = new ServiceCollection();
    }

    internal ServiceCollection ConfigurationServices()
    {
        // LOGGING
        this.services.AddLogging(config =>
        {
            config.AddConfiguration(this.configuration.GetSection(GlobalConstants.LOGGING));
            config.AddConsole();
            config.AddLog4Net(this.configuration.GetSection(GlobalConstants.LOG4NET_CORE).Get<Log4NetProviderOptions>());
        });

        this.services.AddScoped<Engine>();

        // AUTOMAPPER
        AutoMapperConfiguration.ConfigureMappings(new[]
        {
            Assembly.Load(GlobalConstants.ASSEMBLY_MODELS)
        });

        // SERVICES
        this.services.AddScoped<IHttpService, HttpService>();

        return this.services;
    }
}