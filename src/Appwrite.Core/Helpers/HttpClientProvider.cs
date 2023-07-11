using Refit;

using System.Net.Http.Headers;

namespace Appwrite.Core.Helpers;

public abstract class HttpClientProvider
{
    private HttpClient _httpClient;

    internal T GetRestService<T>(Client client)
    {
        _httpClient = client.HttpClient;
        _httpClient.BaseAddress = new Uri(client.Endpoint);

        AddHeadersToHttpClient(client.Headers);

        // this setting is used to set query string parameters in url
        RefitSettings refitSettings = new RefitSettings
        {
            UrlParameterFormatter = new DefaultUrlParameterFormatter()
        };

        var restService = RestService.For<T>(_httpClient, refitSettings);

        return restService;
    }

    private void AddHeadersToHttpClient(IDictionary<string, string> headers)
    {
        _httpClient.DefaultRequestHeaders.Clear();

        foreach (var (header, value) in headers)
        {
            if ("Content-Type".Equals(header, StringComparison.CurrentCultureIgnoreCase))
            {
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(value));
                continue;
            }

            _httpClient.DefaultRequestHeaders.Add(header, value);
        }
    }
}
