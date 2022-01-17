using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleAppTemplate.ConsoleApp;

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
        throw new NotImplementedException();
    }
}