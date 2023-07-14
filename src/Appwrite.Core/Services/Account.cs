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

    /// <summary>
    /// Get Account
    /// </summary>
    /// <para>Get currently logged in user data as JSON object.</para>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> Get(CancellationToken cancellationToken = default)
    {
        return await _accountApi.Get(cancellationToken);
    }

    /// <summary>
    /// Get Account Preferences
    /// </summary>
    /// <para>Get currently logged in user preferences as a key-value object.</para>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Preferences</returns>
    public async Task<Preferences> GetPrefs(CancellationToken cancellationToken = default)
    {
        return await _accountApi.GetPrefs(cancellationToken);
    }

    /// <summary>
    /// List Sessions
    /// </summary>
    /// <para>Get currently logged in user list of active sessions across different devices.</para>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>SessionList</returns>
    public async Task<SessionList> ListSessions(CancellationToken cancellationToken = default)
    {
        return await _accountApi.ListSessions(cancellationToken);
    }

    /// <summary>
    /// List Logs
    /// </summary>
    /// <para>
    /// Get currently logged in user list of latest security activity logs. 
    /// Each log returns user IP address, location and date and time of log.
    /// </para>
    /// <param name="queries">Array of query strings</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>LogList</returns>
    public async Task<LogList> ListLogs(List<string>? queries = null, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> queryParameters = new Dictionary<string, object>();

        if (queries != null && queries.Count() > 0)
        {
            queryParameters.Add("queries", queries);
        }

        return await _accountApi.ListLogs(queryParameters, cancellationToken);
    }

    /// <summary>
    /// Get Session
    /// </summary>
    /// <para>
    /// Use this endpoint to get a logged in user's session using a Session ID. 
    /// Inputting 'current' will return the current session being used.
    /// </para>
    /// <param name="sessionId">Session ID. Use the string 'current' to get the current device session.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Session</returns>
    public async Task<Session> GetSession(string sessionId, CancellationToken cancellationToken = default)
    {
        return await _accountApi.GetSession(sessionId, cancellationToken);
    }

    /// <summary>
    /// Update Name
    /// </summary>
    /// <para>Update currently logged in user account name.</para>
    /// <param name="name">User name. Max length: 128 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> UpdateName(string name, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "name", name }
        };

        return await _accountApi.UpdateName(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Update Password
    /// </summary>
    /// <para>
    /// Update currently logged in user password. 
    /// For validation, user is required to pass in the new password, and the old password. 
    /// For users created with OAuth, Team Invites and Magic URL, oldPassword is optional.
    /// </para>
    /// <param name="password">New user password. Must be at least 8 chars.</param>
    /// <param name="oldPassword">Current user password. Must be at least 8 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> UpdatePassword(string password, string? oldPassword = null, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "password", password }
        };

        if (!string.IsNullOrEmpty(oldPassword))
        {
            bodyParameters.Add("oldPassword", oldPassword);
        }

        return await _accountApi.UpdateName(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Update Email
    /// </summary>
    /// <para>
    /// Update currently logged in user account email address. 
    /// After changing user address, the user confirmation status will get reset. 
    /// A new confirmation email is not sent automatically however you can use the send confirmation email endpoint again to send the confirmation email. 
    /// For security measures, user password is required to complete this request. 
    /// This endpoint can also be used to convert an anonymous account to a normal one, by passing an email address and a new password.
    /// </para>
    /// <param name="email">User email.</param>
    /// <param name="password">User password. Must be at least 8 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> UpdateEmail(string email, string password, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "email", email },
            { "password", password }
        };

        return await _accountApi.UpdateEmail(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Update Phone
    /// </summary>
    /// <para>
    /// Update the currently logged in user's phone number. 
    /// After updating the phone number, the phone verification status will be reset. 
    /// A confirmation SMS is not sent automatically, 
    /// however you can use the POST /account/verification/phone endpoint to send a confirmation SMS.
    /// </para>
    /// <param name="phone">Phone number. Format this number with a leading '+' and a country code, e.g., +16175551212.</param>
    /// <param name="password">User password. Must be at least 8 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> UpdatePhone(string phone, string password, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "phone", phone },
            { "password", password }
        };

        return await _accountApi.UpdatePhone(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Update Preferences
    /// </summary>
    /// <para>
    /// To access this route, init your SDK with your project unique ID and a valid JWT. 
    /// Using the JWT authentication you will be able to perform API actions on behalf of your user.
    /// </para>
    /// <param name="prefs">Prefs key-value JSON object.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> UpdatePreferences(object prefs, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "prefs", prefs }
        };

        return await _accountApi.UpdatePreferences(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Update Status
    /// </summary>
    /// <para>
    /// Block the currently logged in user account. 
    /// Behind the scene, the user record is not deleted but permanently blocked from any access. 
    /// To completely delete a user, use the Users API instead.
    /// </para>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> UpdateStatus(CancellationToken cancellationToken = default)
    {
        return await _accountApi.UpdateStatus(cancellationToken);
    }

    /// <summary>
    /// Delete Session
    /// </summary>
    /// <para>
    /// Use this endpoint to log out the currently logged in user 
    /// from all their account sessions across all of their different devices. 
    /// When using the Session ID argument, only the unique session ID provided is deleted.
    /// </para>
    /// <param name="sessionId">Session ID. Use the string 'current' to delete the current device session.</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns></returns>
    public async Task DeleteSession(string sessionId, CancellationToken cancellationToken = default)
    {
        await _accountApi.DeleteSession(sessionId, cancellationToken);
    }

    /// <summary>
    /// Update OAuth Session (Refresh Tokens)
    /// </summary>
    /// <para>
    /// Access tokens have limited lifespan and expire to mitigate security risks. 
    /// If session was created using an OAuth provider, this route can be used to "refresh" the access token.
    /// </para>
    /// <param name="sessionId">Session ID. Use the string 'current' to update the current device session.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Session</returns>
    public async Task<Session> UpdateSession(string sessionId, CancellationToken cancellationToken = default)
    {
        return await _accountApi.UpdateSession(sessionId, cancellationToken);
    }

    /// <summary>
    /// Delete Sessions
    /// </summary>
    /// <para>Delete all sessions from the user account and remove any sessions cookies from the end client.</para>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns></returns>
    public async Task DeleteSessions(CancellationToken cancellationToken = default)
    {
        await _accountApi.DeleteSessions(cancellationToken);
    }

    /// <summary>
    /// Create Password Recovery
    /// </summary>
    /// <para>
    /// Sends the user an email with a temporary secret key for password reset. 
    /// When the user clicks the confirmation link he is redirected back to your app password 
    /// reset URL with the secret key and email address values attached to the URL query string. 
    /// Use the query string params to submit a request to the PUT /account/recovery endpoint to complete the process. 
    /// The verification link sent to the user's email address is valid for 1 hour.
    /// </para>
    /// <param name="email">User email.</param>
    /// <param name="url">
    /// URL to redirect the user back to your app from the recovery email. 
    /// Only URLs from hostnames in your project platform list are allowed. 
    /// This requirement helps to prevent an open redirect attack against your project API.
    /// </param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Token</returns>
    public async Task<Token> CreateRecovery(string email, string url, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "email", email },
            { "url", url }
        };

        return await _accountApi.CreateRecovery(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create Password Recovery (confirmation)
    /// </summary>
    /// <para>
    /// Use this endpoint to complete the user account password reset. 
    /// Both the userId and secret arguments will be passed as query parameters 
    /// to the redirect URL you have provided when sending your request to the POST /account/recovery endpoint.
    /// 
    /// Please note that in order to avoid a Redirect Attack the only valid redirect URLs 
    /// are the ones from domains you have set when adding your platforms in the console interface.
    /// </para>
    /// <param name="userId">User ID.</param>
    /// <param name="secret">Valid reset token.</param>
    /// <param name="password">New user password. Must be at least 8 chars.</param>
    /// <param name="passwordAgain">Repeat new user password. Must be at least 8 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Token</returns>
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

    /// <summary>
    /// Create Email Verification
    /// </summary>
    /// <para>
    /// Use this endpoint to send a verification message to your user email address to confirm 
    /// they are the valid owners of that address. Both the userId and secret arguments will be 
    /// passed as query parameters to the URL you have provided to be attached to the verification email. 
    /// The provided URL should redirect the user back to your app and allow you to complete the 
    /// verification process by verifying both the userId and secret parameters. 
    /// Learn more about how to complete the verification process. 
    /// The verification link sent to the user's email address is valid for 7 days.
    /// 
    /// Please note that in order to avoid a Redirect Attack, 
    /// the only valid redirect URLs are the ones from domains 
    /// you have set when adding your platforms in the console interface.
    /// </para>
    /// <param name="url">
    /// URL to redirect the user back to your app from the verification email. 
    /// Only URLs from hostnames in your project platform list are allowed. 
    /// This requirement helps to prevent an open redirect attack against your project API.
    /// </param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Token</returns>
    public async Task<Token> CreateVerification(string url, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "url", url }
        };

        return await _accountApi.CreateRecovery(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create Email Verification (confirmation)
    /// </summary>
    /// <para>
    /// Use this endpoint to complete the user email verification process. 
    /// Use both the userId and secret parameters that were attached to your app 
    /// URL to verify the user email ownership. If confirmed this route will return a 200 status code.
    /// </para>
    /// <param name="userId">User ID.</param>
    /// <param name="secret">Valid verification token.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Token</returns>
    public async Task<Token> UpdateVerification(string userId, string secret, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "userId", userId },
            { "secret", secret }
        };

        return await _accountApi.UpdateVerification(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create Phone Verification
    /// </summary>
    /// <para>
    /// Use this endpoint to send a verification SMS to the currently logged in user. 
    /// This endpoint is meant for use after updating a user's phone number using the 
    /// accountUpdatePhone endpoint. Learn more about how to complete the verification process. 
    /// The verification code sent to the user's phone number is valid for 15 minutes.
    /// </para>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Token</returns>
    public async Task<Token> CreatePhoneVerification(CancellationToken cancellationToken = default)
    {
        return await _accountApi.CreatePhoneVerification(cancellationToken);
    }

    /// <summary>
    /// Create Phone Verification (confirmation)
    /// </summary>
    /// <para>
    /// Use this endpoint to complete the user phone verification process. 
    /// Use the userId and secret that were sent to your user's phone number to 
    /// verify the user email ownership. If confirmed this route will return a 200 status code.
    /// </para>
    /// <param name="userId">User ID.</param>
    /// <param name="secret">Valid verification token.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Token</returns>
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
