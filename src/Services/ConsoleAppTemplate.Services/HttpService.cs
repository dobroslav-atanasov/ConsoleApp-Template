namespace ConsoleAppTemplate.Services;

using Interfaces;

public class HttpService : IHttpService
{
    public Task<string> GetAsync(string url, string accessToken)
    {
        throw new NotImplementedException();
    }

    public Task<string> PostAsync(string url, string json, string accessToken)
    {
        throw new NotImplementedException();
    }
}