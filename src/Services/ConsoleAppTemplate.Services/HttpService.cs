namespace ConsoleAppTemplate.Services;

using System.Text;

using HtmlAgilityPack;

using Interfaces;
using Data.Models.Http;

public class HttpService : IHttpService
{
    public async Task<HttpModel> GetAsync(string url, string accessToken = null)
    {
        using var handler = new HttpClientHandler();
        using var client = new HttpClient(handler);

        if (accessToken != null)
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");
        }

        var response = await client.GetAsync(url);

        if (response != null)
        {
            var httpModel = new HttpModel
            {
                Url = url,
                StatusCode = response.StatusCode,
                MimeType = response.Content.Headers.ContentType?.MediaType,
                Content = await response.Content.ReadAsStringAsync(),
            };

            if (httpModel.MimeType != null && httpModel.MimeType == "text/html")
            {
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(httpModel.Content);
            }

            httpModel.Encoding = Encoding.UTF8;
            var charSet = response.Content.Headers.ContentType?.CharSet;
            if (charSet != null && charSet.ToLower() != "utf-8")
            {
                httpModel.Encoding = Encoding.GetEncoding(charSet);
            }

            return httpModel;
        }

        return null;
    }

    public Task<HttpModel> PostAsync(string url, string json, string accessToken)
    {
        throw new NotImplementedException();
    }
}