using Appwrite.Core.Models;

using Refit;

namespace Appwrite.Core.Apis;

internal interface IAccount
{
    [Get("/account")]
    Task<User> Get(CancellationToken cancellationToken = default);

    [Get("/account/prefs")]
    Task<Preferences> GetPrefs(CancellationToken cancellationToken = default);

    [Get("/account/sessions")]
    Task<SessionList> ListSessions(CancellationToken cancellationToken = default);

    [Get("/account/logs")]
    Task<LogList> ListLogs([Query] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Get("/account/sessions/{sessionId}")]
    Task<Session> GetSession(string sessionId, CancellationToken cancellationToken = default);

    [Patch("/account/name")]
    Task<User> UpdateName([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Patch("/account/password")]
    Task<User> UpdatePassword([Query] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Patch("/account/email")]
    Task<User> UpdateEmail([Query] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Patch("/account/phone")]
    Task<User> UpdatePhone([Query] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Patch("/account/prefs")]
    Task<User> UpdatePreferences([Query] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Patch("/account/status")]
    Task<User> UpdateStatus(CancellationToken cancellationToken = default);

    [Delete("/account/sessions/{sessionId}")]
    Task DeleteSession(string sessionId, CancellationToken cancellationToken = default);

    [Patch("/account/sessions/{sessionId}")]
    Task<Session> UpdateSession(string sessionId, CancellationToken cancellationToken = default);

    [Delete("/account/sessions")]
    Task DeleteSessions(CancellationToken cancellationToken = default);

    [Post("/account/recovery")]
    Task<Token> CreateRecovery([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Put("/account/recovery")]
    Task<Token> UpdateRecovery([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Post("/account/verification")]
    Task<Token> CreateVerification([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Put("/account/verification")]
    Task<Token> UpdateVerification([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Post("/account/verification/phone")]
    Task<Token> CreatePhoneVerification(CancellationToken cancellationToken = default);

    [Put("/account/verification/phone")]
    Task<Token> UpdatePhoneVerification([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);
}
