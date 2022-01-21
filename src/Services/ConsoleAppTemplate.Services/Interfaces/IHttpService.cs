namespace ConsoleAppTemplate.Services.Interfaces;

using Data.Models.Http;

public interface IHttpService
{
    Task<HttpModel> GetAsync(string url, string accessToken = null);

    Task<HttpModel> PostAsync(string url, string json, string accessToken = null);
}