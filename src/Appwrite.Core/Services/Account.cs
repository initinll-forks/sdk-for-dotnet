using Appwrite.Core.Apis;
using Appwrite.Core.Helpers;
using Appwrite.Core.Models;

namespace Appwrite.Core.Services;

public class Account : HttpClientProvider
{
    private readonly Client _client;
    private readonly IAccount _accountApi;


    public Account(Client client)
    {
        _client = client;
        _accountApi = base.GetRestService<IAccount>(_client);
    }

    public async Task<User> Get(CancellationToken cancellationToken = default)
    {
        return await _accountApi.Get(cancellationToken);
    }

    public async Task<Preferences> GetPrefs(CancellationToken cancellationToken = default)
    {
        return await _accountApi.GetPrefs(cancellationToken);
    }

    public async Task<SessionList> ListSessions(CancellationToken cancellationToken = default)
    {
        return await _accountApi.ListSessions(cancellationToken);
    }

    public async Task<LogList> ListLogs(List<string>? queries = null, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> queryParameters = null;

        if (queries != null)
        {
            queryParameters = new Dictionary<string, object>
            {
                { "queries", queries }
            };
        }

        return await _accountApi.ListLogs(queryParameters, cancellationToken);
    }

    public async Task<Session> GetSession(string sessionId, CancellationToken cancellationToken = default)
    {
        return await _accountApi.GetSession(sessionId, cancellationToken);
    }

    public async Task<User> UpdateName(string name, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "name", name }
        };

        return await _accountApi.UpdateName(bodyParameters, cancellationToken);
    }

    public async Task<User> UpdatePassword(string password, string? oldPassword = null, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "password", password },
            { "oldPassword", oldPassword }
        };

        return await _accountApi.UpdateName(bodyParameters, cancellationToken);
    }

    public async Task<User> UpdateEmail(string email, string password, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "email", email },
            { "password", password }
        };

        return await _accountApi.UpdateEmail(bodyParameters, cancellationToken);
    }

    public async Task<User> UpdatePhone(string phone, string password, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "phone", phone },
            { "password", password }
        };

        return await _accountApi.UpdatePhone(bodyParameters, cancellationToken);
    }

    public async Task<User> UpdatePreferences(object prefs, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "prefs", prefs }
        };

        return await _accountApi.UpdatePreferences(bodyParameters, cancellationToken);
    }

    public async Task<User> UpdateStatus(CancellationToken cancellationToken = default)
    {
        return await _accountApi.UpdateStatus(cancellationToken);
    }

    public async Task DeleteSession(string sessionId, CancellationToken cancellationToken = default)
    {
        await _accountApi.DeleteSession(sessionId, cancellationToken);
    }

    public async Task<Session> UpdateSession(string sessionId, CancellationToken cancellationToken = default)
    {
        return await _accountApi.UpdateSession(sessionId, cancellationToken);
    }

    public async Task DeleteSessions(CancellationToken cancellationToken = default)
    {
        await _accountApi.DeleteSessions(cancellationToken);
    }

    public async Task<Token> CreateRecovery(string email, string url, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "email", email },
            { "url", url }
        };

        return await _accountApi.CreateRecovery(bodyParameters, cancellationToken);
    }

    public async Task<Token> UpdateRecovery(string userId, string secret, string password, string passwordAgain, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "userId", userId },
            { "secret", secret },
            { "password", password },
            { "passwordAgain", passwordAgain }
        };

        return await _accountApi.UpdateRecovery(bodyParameters, cancellationToken);
    }

    public async Task<Token> CreateVerification(string url, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "url", url }
        };

        return await _accountApi.CreateRecovery(bodyParameters, cancellationToken);
    }

    public async Task<Token> UpdateVerification(string userId, string secret, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "userId", userId },
            { "secret", secret }
        };

        return await _accountApi.UpdateVerification(bodyParameters, cancellationToken);
    }

    public async Task<Token> CreatePhoneVerification(CancellationToken cancellationToken = default)
    {
        return await _accountApi.CreatePhoneVerification(cancellationToken);
    }

    public async Task<Token> UpdatePhoneVerification(string userId, string secret, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "userId", userId },
            { "secret", secret }
        };

        return await _accountApi.UpdatePhoneVerification(bodyParameters, cancellationToken);
    }
}
