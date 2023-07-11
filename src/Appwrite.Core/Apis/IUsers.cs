using Appwrite.Core.Models;

using Refit;

namespace Appwrite.Core.Apis;

internal interface IUsers
{
    [Post("/users")]
    Task<User> Create([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Post("/users/bcrypt")]
    Task<User> CreateBcryptUser([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Post("/users/md5")]
    Task<User> CreateMD5User([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Post("/users/argon2")]
    Task<User> CreateArgon2User([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Post("/users/sha")]
    Task<User> CreateSHAUser([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Post("/users/phpass")]
    Task<User> CreatePHPassUser([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Post("/users/scrypt")]
    Task<User> CreateScryptUser([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Post("/users/scrypt-modified")]
    Task<User> CreateScryptModifiedUser([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Get("/users")]
    Task<UserList> List([Query] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Get("/users/{userId}")]
    Task<User> Get(string userId, CancellationToken cancellationToken = default);

    [Get("/users/{userId}/prefs")]
    Task<Preferences> GetPrefs(string userId, CancellationToken cancellationToken = default);

    [Get("/users/{userId}/sessions")]
    Task<SessionList> ListSessions(string userId, CancellationToken cancellationToken = default);

    [Get("/users/{userId}/memberships")]
    Task<MembershipList> ListMemberships(string userId, CancellationToken cancellationToken = default);
}
