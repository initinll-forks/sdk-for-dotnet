using Appwrite.Core.Models;

using Refit;

namespace Appwrite.Core.Apis;

internal interface ITeams
{
    [Post("/teams")]
    Task<Team> Create([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters = null, CancellationToken cancellationToken = default);

    [Get("/teams")]
    Task<TeamList> List([Query] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);

    [Get("/teams/{teamId}")]
    Task<Team> Get(string teamId, CancellationToken cancellationToken = default);

    [Put("/teams/{teamId}")]
    Task<Team> Update(string teamId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Delete("/teams/{teamId}")]
    Task Delete(string teamId, CancellationToken cancellationToken = default);

    [Post("/teams/{teamId}/memberships")]
    Task<Membership> CreateMembership(string teamId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Get("/teams/{teamId}/memberships")]
    Task<MembershipList> ListMemberships(string teamId, [Query] IDictionary<string, object> queryParameters = null, CancellationToken cancellationToken = default);
}
