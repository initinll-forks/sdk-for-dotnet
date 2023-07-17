using Appwrite.Core.Apis;
using Appwrite.Core.Helpers;
using Appwrite.Core.Models;

namespace Appwrite.Core.Services;

public class Teams : HttpClientProvider
{
    private readonly ITeams _teamsApi;

    public Teams(Client client)
    {
        _teamsApi = base.GetRestService<ITeams>(client);
    }

    /// <summary>
    /// Create Team
    /// </summary>
    /// <para>
    /// Create a new team. 
    /// The user who creates the team will automatically be assigned as the owner of the team. 
    /// Only the users with the owner role can invite new members, add new owners and delete 
    /// or update the team.
    /// </para>
    /// <param name="teamId">
    /// Team ID. 
    /// Choose your own unique ID or pass the string ID.unique() to auto generate it. 
    /// Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. 
    /// Can't start with a special char. Max length is 36 chars.
    /// </param>
    /// <param name="name">Team name. Max length: 128 chars.</param>
    /// <param name="roles">
    /// Array of strings. 
    /// Use this param to set the roles in the team for the user who created it. 
    /// The default role is owner. A role can be any string. 
    /// Learn more about roles and permissions. 
    /// Maximum of 100 roles are allowed, each 32 characters long.
    /// </param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Team</returns>
    public async Task<Team> Create(string teamId, string name, List<string>? roles = null, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "teamId", teamId },
            { "name", name }
        };

        if (roles != null && roles.Count() > 0)
        {
            bodyParameters.Add("roles", roles);
        }

        return await _teamsApi.Create(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// List Teams
    /// </summary>
    /// <para>
    /// Get a list of all the teams in which the current user is a member. 
    /// You can use the parameters to filter your results.
    /// </para>
    /// <param name="queries">
    /// Array of query strings generated using the Query class provided by the SDK. 
    /// Learn more about queries. Maximum of 100 queries are allowed, each 4096 characters long. 
    /// You may filter on the following attributes: name, total
    /// </param>
    /// <param name="search">Search term to filter your list results. Max length: 256 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>TeamList</returns>
    public async Task<TeamList> List(List<string>? queries = null, string? search = null, CancellationToken cancellationToken = default)
    {
        var queryParameters = new Dictionary<string, object>();

        if (queries != null && queries.Count() > 0)
        {
            queryParameters.Add("queries", queries);
        }

        if (!string.IsNullOrEmpty(search))
        {
            queryParameters.Add("search", search);
        }

        return await _teamsApi.List(queryParameters, cancellationToken);
    }

    /// <summary>
    /// Get Team
    /// </summary>
    /// <para>Get a team by its ID. All team members have read access for this resource.</para>
    /// <param name="teamId">Team ID.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Team</returns>
    public async Task<Team> Get(string teamId, CancellationToken cancellationToken = default)
    {
        return await _teamsApi.Get(teamId, cancellationToken);
    }

    /// <summary>
    /// Update Team
    /// </summary>
    /// <para>Update a team using its ID. Only members with the owner role can update the team.</para>
    /// <param name="teamId">Team ID.</param>
    /// <param name="name">New team name. Max length: 128 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Team</returns>
    public async Task<Team> Update(string teamId, string name, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "name", name }
        };

        return await _teamsApi.Update(teamId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Delete Team
    /// </summary>
    /// <para>Delete a team using its ID. Only team members with the owner role can delete the team.</para>
    /// <param name="teamId">Team ID.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns></returns>
    public async Task Delete(string teamId, CancellationToken cancellationToken = default)
    {
        await _teamsApi.Delete(teamId, cancellationToken);
    }

    /// <summary>
    /// Create Team Membership
    /// </summary>
    /// <para>
    /// Invite a new member to join your team. If initiated from the client SDK, 
    /// an email with a link to join the team will be sent to the member's email 
    /// address and an account will be created for them should they not be signed up already. 
    /// If initiated from server-side SDKs, the new member will automatically be added to the team.
    /// 
    /// Use the 'url' parameter to redirect the user from the invitation email back to your app. 
    /// When the user is redirected, use the Update Team Membership Status endpoint to allow the 
    /// user to accept the invitation to the team.
    /// 
    /// Please note that to avoid a Redirect Attack the only valid redirect URL's are the once from 
    /// domains you have set when adding your platforms in the console interface.
    /// </para>
    /// <param name="teamId">Team ID.</param>
    /// <param name="email">Email of the new team member.</param>
    /// <param name="roles">
    /// Array of strings. 
    /// Use this param to set the user roles in the team. 
    /// A role can be any string. 
    /// Learn more about roles and permissions. 
    /// Maximum of 100 roles are allowed, each 32 characters long.
    /// </param>
    /// <param name="url">
    /// URL to redirect the user back to your app from the invitation email. 
    /// Only URLs from hostnames in your project platform list are allowed. 
    /// This requirement helps to prevent an open redirect attack against your project API.
    /// </param>
    /// <param name="name">Name of the new team member. Max length: 128 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Membership</returns>
    public async Task<Membership> CreateMembership(string teamId,
        string email,
        List<string> roles,
        string url,
        string? name,
        CancellationToken cancellationToken)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "email", email },
            { "roles", roles },
            { "url", url }
        };

        if (!string.IsNullOrEmpty(name))
        {
            bodyParameters.Add("name", name);
        }

        return await _teamsApi.CreateMembership(teamId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// List Team Memberships
    /// </summary>
    /// <para>
    /// Use this endpoint to list a team's members using the team's ID. 
    /// All team members have read access to this endpoint.
    /// </para>
    /// <param name="teamId">Team ID.</param>
    /// <param name="queries">
    /// Array of query strings generated using the Query class provided by the SDK. 
    /// Learn more about queries. Maximum of 100 queries are allowed, each 4096 characters long. 
    /// You may filter on the following attributes: userId, teamId, invited, joined, confirm
    /// </param>
    /// <param name="search">Search term to filter your list results. Max length: 256 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>MembershipList</returns>
    public async Task<MembershipList> ListMemberships(string teamId,
        List<string>? queries,
        string? search,
        CancellationToken cancellationToken)
    {
        var queryParameters = new Dictionary<string, object>();

        if (queries != null && queries.Count() > 0)
        {
            queryParameters.Add("queries", queries);
        }

        if (!string.IsNullOrEmpty(search))
        {
            queryParameters.Add("search", search);
        }

        return await _teamsApi.ListMemberships(teamId, queryParameters, cancellationToken);
    }

    /// <summary>
    /// Get Team Membership
    /// </summary>
    /// <para>
    /// Get a team member by the membership unique id. 
    /// All team members have read access for this resource.
    /// </para>
    /// <param name="teamId">Team ID.</param>
    /// <param name="membershipId">Membership ID.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Membership</returns>
    public async Task<Membership> GetMembership(string teamId, string membershipId, CancellationToken cancellationToken)
    {
        return await _teamsApi.GetMembership(teamId, membershipId, cancellationToken);
    }

    /// <summary>
    /// Update Membership Roles
    /// </summary>
    /// <para>
    /// Modify the roles of a team member. 
    /// Only team members with the owner role have access to this endpoint. 
    /// Learn more about roles and permissions.
    /// </para>
    /// <param name="teamId">Team ID.</param>
    /// <param name="membershipId">Membership ID.</param>
    /// <param name="roles">
    /// An array of strings. 
    /// Use this param to set the user's roles in the team. 
    /// A role can be any string. Learn more about roles and permissions. 
    /// Maximum of 100 roles are allowed, each 32 characters long.
    /// </param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns></returns>
    public async Task<Membership> UpdateMembershipRoles(string teamId,
        string membershipId,
        List<string> roles,
        CancellationToken cancellationToken)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "roles", roles }
        };

        return await _teamsApi.UpdateMembershipRoles(teamId, membershipId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Update Team Membership Status
    /// </summary>
    /// <para>
    /// Use this endpoint to allow a user to accept an invitation to join a team after 
    /// being redirected back to your app from the invitation email received by the user.
    /// 
    /// If the request is successful, a session for the user is automatically created.
    /// </para>
    /// <param name="teamId">Team ID.</param>
    /// <param name="membershipId">Membership ID.</param>
    /// <param name="userId">User ID.</param>
    /// <param name="secret">Secret key.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Membership</returns>
    public async Task<Membership> UpdateMembershipStatus(string teamId,
        string membershipId,
        string userId,
        string secret,
        CancellationToken cancellationToken)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "userId", userId },
            { "secret", secret }
        };

        return await _teamsApi.UpdateMembershipStatus(teamId, membershipId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Delete Team Membership
    /// </summary>
    /// <para>
    /// This endpoint allows a user to leave a team or for a team owner to delete 
    /// the membership of any other team member. You can also use this endpoint to 
    /// delete a user membership even if it is not accepted.
    /// </para>
    /// <param name="teamId">Team ID.</param>
    /// <param name="membershipId">Membership ID.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns></returns>
    public async Task DeleteMembership(string teamId, string membershipId, CancellationToken cancellationToken)
    {
        await _teamsApi.DeleteMembership(teamId, membershipId, cancellationToken);
    }
}