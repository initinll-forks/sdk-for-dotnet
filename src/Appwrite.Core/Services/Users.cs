using Appwrite.Core.Apis;
using Appwrite.Core.Helpers;
using Appwrite.Core.Models;

namespace Appwrite.Core.Services;

public class Users : HttpClientProvider
{
    private readonly Client _client;
    private readonly IUsers _usersApi;

    public Users(Client client)
    {
        _client = client;
        _usersApi = base.GetRestService<IUsers>(_client);
    }

    /// <summary>
    /// Create User
    /// </summary>
    /// <para>Create a new user.</para>
    /// <param name="userId">User ID. Choose your own unique ID or pass the string ID.unique() to auto generate it. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.</param>
    /// <param name="email">User email.</param>
    /// <param name="phone">Phone number. Format this number with a leading '+' and a country code, e.g., +16175551212.</param>
    /// <param name="password">Plain text user password. Must be at least 8 chars.</param>
    /// <param name="name">User name. Max length: 128 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> Create(string userId, string? email = null, string? phone = null, string? password = null, string? name = null, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "userId", userId },
            { "email", email },
            { "phone", phone },
            { "password", password },
            { "name", name }
        };

        return await _usersApi.Create(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create User with Bcrypt Password
    /// </summary>
    /// <para>Create a new user. Password provided must be hashed with the Bcrypt algorithm. Use the Create endpoint to create users with a plain text password.</para>
    /// <param name="userId">User ID. Choose your own unique ID or pass the string ID.unique() to auto generate it. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.</param>
    /// <param name="email">User email.</param>
    /// <param name="password">User password hashed using Bcrypt.</param>
    /// <param name="name">User name. Max length: 128 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> CreateBcryptUser(string userId, string email, string password, string? name = null, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "userId", userId },
            { "email", email },
            { "password", password },
            { "name", name }
        };

        return await _usersApi.CreateBcryptUser(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create User with MD5 Password
    /// </summary>
    /// <para>Create a new user. Password provided must be hashed with the MD5 algorithm. Use the Create endpoint to create users with a plain text password.</para>
    /// <param name="userId">User ID. Choose your own unique ID or pass the string ID.unique() to auto generate it. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.</param>
    /// <param name="email">User email.</param>
    /// <param name="password">User password hashed using MD5.</param>
    /// <param name="name">User name. Max length: 128 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> CreateMD5User(string userId, string email, string password, string? name = null, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "userId", userId },
            { "email", email },
            { "password", password },
            { "name", name }
        };

        return await _usersApi.CreateMD5User(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create User with Argon2 Password
    /// </summary>
    /// <para>Create a new user. Password provided must be hashed with the Argon2 algorithm. Use the Create endpoint to create users with a plain text password.</para>
    /// <param name="userId">User ID. Choose your own unique ID or pass the string ID.unique() to auto generate it. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.</param>
    /// <param name="email">User email.</param>
    /// <param name="password">User password hashed using Argon2.</param>
    /// <param name="name">User name. Max length: 128 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> CreateArgon2User(string userId, string email, string password, string? name = null, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "userId", userId },
            { "email", email },
            { "password", password },
            { "name", name }
        };

        return await _usersApi.CreateArgon2User(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create User with SHA Password
    /// </summary>
    /// <para>Create a new user. Password provided must be hashed with the SHA algorithm. Use the Create endpoint to create users with a plain text password.</para>
    /// <param name="userId">User ID. Choose your own unique ID or pass the string ID.unique() to auto generate it. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.</param>
    /// <param name="email">User email.</param>
    /// <param name="password">User password hashed using SHA.</param>
    /// <param name="passwordVersion">Optional SHA version used to hash password. Allowed values are: 'sha1', 'sha224', 'sha256', 'sha384', 'sha512/224', 'sha512/256', 'sha512', 'sha3-224', 'sha3-256', 'sha3-384', 'sha3-512'</param>
    /// <param name="name">User name. Max length: 128 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> CreateSHAUser(string userId, string email, string password, string? passwordVersion = null, string? name = null, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "userId", userId },
            { "email", email },
            { "password", password },
            { "passwordVersion", passwordVersion },
            { "name", name }
        };

        return await _usersApi.CreateSHAUser(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create User with PHPass Password
    /// </summary>
    /// <para>Create a new user. Password provided must be hashed with the PHPass algorithm. Use the Create endpoint to create users with a plain text password.</para>
    /// <param name="userId">User ID. Choose your own unique ID or pass the string ID.unique()to auto generate it. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.</param>
    /// <param name="email">User email.</param>
    /// <param name="password">User password hashed using PHPass.</param>
    /// <param name="name">User name. Max length: 128 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> CreatePHPassUser(string userId, string email, string password, string? name = null, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "userId", userId },
            { "email", email },
            { "password", password },
            { "name", name }
        };

        return await _usersApi.CreatePHPassUser(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create User with Scrypt Password
    /// </summary>
    /// <para>Create a new user. Password provided must be hashed with the Scrypt algorithm. Use the Create endpoint to create users with a plain text password.</para>
    /// <param name="userId">User ID. Choose your own unique ID or pass the string ID.unique() to auto generate it. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.</param>
    /// <param name="email">User email.</param>
    /// <param name="password">User password hashed using Scrypt.</param>
    /// <param name="passwordSalt">Optional salt used to hash password.</param>
    /// <param name="passwordCpu">Optional CPU cost used to hash password.</param>
    /// <param name="passwordMemory">Optional memory cost used to hash password.</param>
    /// <param name="passwordParallel">Optional parallelization cost used to hash password.</param>
    /// <param name="passwordLength">Optional hash length used to hash password.</param>
    /// <param name="name">User name. Max length: 128 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> CreateScryptUser(string userId, string email, string password, string passwordSalt, string passwordCpu, string passwordMemory, string passwordParallel, string passwordLength, string? name = null, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "userId", userId },
            { "email", email },
            { "password", password },
            { "passwordSalt", passwordSalt },
            { "passwordCpu", passwordCpu },
            { "passwordMemory", passwordMemory },
            { "passwordParallel", passwordParallel },
            { "passwordLength", passwordLength },
            { "name", name }
        };

        return await _usersApi.CreateScryptUser(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create User with Scrypt Modified Password
    /// </summary>
    /// <para>Create a new user. Password provided must be hashed with the Scrypt Modified algorithm. Use the Create endpoint to create users with a plain text password.</para>
    /// <param name="userId">User ID. Choose your own unique ID or pass the string ID.unique() to auto generate it. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.</param>
    /// <param name="email">User email.</param>
    /// <param name="password">User password hashed using Scrypt Modified.</param>
    /// <param name="passwordSalt">Salt used to hash password.</param>
    /// <param name="passwordSaltSeparator">Salt separator used to hash password.</param>
    /// <param name="passwordSignerKey">Signer key used to hash password.</param>
    /// <param name="name">User name. Max length: 128 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> CreateScryptModifiedUser(string userId, string email, string password, string passwordSalt, string passwordSaltSeparator, string passwordSignerKey, string? name = null, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "userId", userId },
            { "email", email },
            { "password", password },
            { "passwordSalt", passwordSalt },
            { "passwordSaltSeparator", passwordSaltSeparator },
            { "passwordSignerKey", passwordSignerKey },
            { "name", name }
        };

        return await _usersApi.CreateScryptModifiedUser(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// List Users
    /// </summary>
    /// <para>Get a list of all the project's users. You can use the query params to filter your results.</para>
    /// <param name="queries">Array of query strings. Maximum of 100 queries are allowed, each 4096 characters long. You may filter on the following attributes: name, email, phone, status, passwordUpdate, registration, emailVerification, phoneVerification.</param>
    /// <param name="search">Search term to filter your list results. Max length: 256 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>UserList</returns>
    public async Task<UserList> List(List<string>? queries = null, string? search = null, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> queryParameters = new Dictionary<string, object>
        {
            { "queries", queries },
            { "search", search }
        };

        return await _usersApi.List(queryParameters, cancellationToken);
    }

    /// <summary>
    /// Get User
    /// </summary>
    /// <para>Get a user by its unique ID.</para>
    /// <param name="userId">User ID.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> Get(string userId, CancellationToken cancellationToken = default)
    {
        return await _usersApi.Get(userId, cancellationToken);
    }

    /// <summary>
    /// Get User Preferences
    /// </summary>
    /// <para>Get the user preferences by its unique ID.</para>
    /// <param name="userId">User ID.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Preferences</returns>
    public async Task<Preferences> GetPrefs(string userId, CancellationToken cancellationToken = default)
    {
        return await _usersApi.GetPrefs(userId, cancellationToken);
    }

    /// <summary>
    /// List User Sessions
    /// </summary>
    /// <para>Get the user sessions list by its unique ID.</para>
    /// <param name="userId">User ID.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>SessionList</returns>
    public async Task<SessionList> ListSessions(string userId, CancellationToken cancellationToken = default)
    {
        return await _usersApi.ListSessions(userId, cancellationToken);
    }

    /// <summary>
    /// List User Memberships
    /// </summary>
    /// <para>Get the user membership list by its unique ID.</para>
    /// <param name="userId">User ID.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>MembershipList</returns>
    public async Task<MembershipList> ListMemberships(string userId, CancellationToken cancellationToken = default)
    {
        return await _usersApi.ListMemberships(userId, cancellationToken);
    }

    /// <summary>
    /// List User Logs
    /// </summary>
    /// <para>Get the user activity logs list by its unique ID.</para>
    /// <param name="userId">User ID.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>LogList</returns>
    public async Task<LogList> ListLogs(string userId, CancellationToken cancellationToken = default)
    {
        return await _usersApi.ListLogs(userId, cancellationToken);
    }

    /// <summary>
    /// Update User Status
    /// </summary>
    /// <para>Update the user status by its unique ID. Use this endpoint as an alternative to deleting a user if you want to keep user's ID reserved.</para>
    /// <param name="userId">User ID.</param>
    /// <param name="status">User Status. To activate the user pass true and to block the user pass false.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>User</returns>
    public async Task<User> UpdateStatus(string userId, bool status, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "status", status }
        };

        return await _usersApi.UpdateStatus(userId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Update Phone Verification
    /// </summary>
    /// <para>Update the user phone verification status by its unique ID.</para>
    /// <param name="userId">User ID.</param>
    /// <param name="phoneVerification">User phone verification status.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns></returns>
    public async Task<User> UpdatePhoneVerification(string userId, bool phoneVerification, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "phoneVerification", phoneVerification }
        };

        return await _usersApi.UpdatePhoneVerification(userId, bodyParameters, cancellationToken);
    }
}
