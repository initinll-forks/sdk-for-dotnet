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
    /// 
    /// </summary>
    /// <param name="queries"></param>
    /// <param name="search"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
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
}
