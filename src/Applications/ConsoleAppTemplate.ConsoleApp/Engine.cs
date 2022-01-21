using ConsoleAppTemplate.Services.Interfaces;

namespace ConsoleAppTemplate.ConsoleApp;

internal class Engine
{
    private readonly IHttpService httpService;

    public Engine(IHttpService httpService)
    {
        this.httpService = httpService;
    }

    internal async Task RunAsync()
    {

    }
}