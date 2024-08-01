using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ReceiptRewards.Domain.Requests;

namespace ReceiptRewards.Domain;

public static class RequestHelper
{
    public static async Task<T> GetDataFromUrl<T, TV>( string url,
        ILogger<TV> logger, IHttpClientFactory httpClientFactory)
    {
        var client = httpClientFactory.CreateClient("ReaderClient");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        logger.LogInformation("Sending request to {Url}", url);
        using var response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        return await ReadContentAs<T>(response.Content);
    }

    public static async Task<TU> SendDataToUrl<T, TU, TV>(string url, T data,
        ILogger<TV> logger, IHttpClientFactory httpClientFactory)
    {
        var client = httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        logger.LogInformation("Sending request to {Url}", url);

        using var response = await client.PostAsJsonAsync<T>(url, data);
        response.EnsureSuccessStatusCode();
        return await ReadContentAs<TU>(response.Content);
    }

    private static async Task<T> ReadContentAs<T>(HttpContent content)
    {
        if (typeof(T) == typeof(byte[]))
        {
            return (T)(object)await content.ReadAsByteArrayAsync();
        }
        else if (typeof(T) == typeof(string))
        {
            return (T)(object)await content.ReadAsStringAsync();
        }
        else
        {
            string json = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json)!;
        }
    }
}