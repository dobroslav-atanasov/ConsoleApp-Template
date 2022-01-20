namespace ConsoleAppTemplate.Services.Interfaces;

public interface IHttpService
{
    Task<string> GetAsync(string url, string accessToken);

    Task<string> PostAsync(string url, string json, string accessToken);
}