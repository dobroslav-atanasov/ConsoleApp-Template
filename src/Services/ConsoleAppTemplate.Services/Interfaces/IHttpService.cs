namespace ConsoleAppTemplate.Services.Interfaces;

using Data.Models.Http;

public interface IHttpService
{
    Task<HttpModel> GetAsync(string url, string accessToken);

    Task<HttpModel> PostAsync(string url, string json, string accessToken);
}