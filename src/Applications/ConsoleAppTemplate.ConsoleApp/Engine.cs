namespace ConsoleAppTemplate.ConsoleApp;

using Services.Interfaces;

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