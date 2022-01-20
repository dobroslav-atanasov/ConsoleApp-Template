namespace ConsoleAppTemplate.Services;

using Interfaces;
using Data.Models.Http;

public class HttpService : IHttpService
{
    public Task<HttpModel> GetAsync(string url, string accessToken)
    {
        throw new NotImplementedException();
    }

    public Task<HttpModel> PostAsync(string url, string json, string accessToken)
    {
        throw new NotImplementedException();
    }
}