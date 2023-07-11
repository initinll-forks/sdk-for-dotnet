using Appwrite.Core.Helpers;

using Microsoft.Extensions.DependencyInjection;

namespace Appwrite.Core;

public class Client
{
    private string _endpoint;
    private string _project;
    private bool _selfSigned;
    private IDictionary<string, string> _headers = new Dictionary<string, string>();
    private IServiceCollection _services = new ServiceCollection();

    public Client()
    {
        AddHttpClientService();
        AddCommonHeaders();
    }

    #region Internal to Library

    private void AddHttpClientService()
    {
        _services.AddSingleton<AppwriteExceptionHandler>();

        _services
            .AddHttpClient("ApiClient")
            .AddHttpMessageHandler<AppwriteExceptionHandler>();
    }

    private void AddCommonHeaders()
    {
        AddHeader("Content-Type", "application/json");
        AddHeader("User-Agent", $"AppwriteDotNetSDK/0.4.0 ({Environment.OSVersion.Platform}; {Environment.OSVersion.VersionString})");
        AddHeader("x-sdk-name", ".NET");
        AddHeader("x-sdk-language", "dotnet");
        AddHeader("x-sdk-platform", "server");
        AddHeader("x-sdk-version", "0.4.0");
        AddHeader("X-Appwrite-Response-Format", "1.0.0");
    }

    internal string Endpoint
    {
        get
        {
            return _endpoint;
        }
    }

    internal string Project
    {
        get
        {
            return _project;
        }
    }

    internal bool SelfSigned
    {
        get
        {
            return _selfSigned;
        }
    }

    internal IDictionary<string, string> Headers
    {
        get
        {
            return _headers;
        }
    }

    internal HttpClient HttpClient
    {
        get
        {
            var serviceProvider = _services.BuildServiceProvider();
            var httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
            return httpClientFactory!.CreateClient("ApiClient");
        }
    }

    #endregion

    #region Public Api

    public Client SetEndpoint(string endpoint)
    {
        this._endpoint = endpoint;
        return this;
    }

    public Client SetProject(string project)
    {
        AddHeader("X-Appwrite-Project", project);
        return this;
    }

    public Client SetKey(string key)
    {
        AddHeader("X-Appwrite-Key", key);
        return this;
    }

    public Client SetJWT(string token)
    {
        AddHeader("X-Appwrite-JWT", token);
        return this;
    }

    public Client SetLocale(string locale)
    {
        AddHeader("X-Appwrite-Locale", locale);
        return this;
    }

    public Client SetSelfSigned(bool selfSigned)
    {
        this._selfSigned = selfSigned;
        return this;
    }

    public Client AddHeader(string key, string value)
    {
        _headers.Add(key, value);
        return this;
    }

    #endregion
}
