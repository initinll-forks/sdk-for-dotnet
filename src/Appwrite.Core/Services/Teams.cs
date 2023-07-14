using Appwrite.Core.Apis;
using Appwrite.Core.Helpers;
using Appwrite.Core.Models;

namespace Appwrite.Core.Services;

public class Teams : HttpClientProvider
{
    private readonly Client _client;
    private readonly ITeams _teamsApi;

    public Teams(Client client)
    {
        _client = client;
        _teamsApi = base.GetRestService<ITeams>(_client);
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
}
