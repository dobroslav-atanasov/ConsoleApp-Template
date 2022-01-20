namespace ConsoleAppTemplate.ConsoleApp;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Common.Constants;

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

        return this.services;
    }
}