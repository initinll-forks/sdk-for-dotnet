using Appwrite.Core.Apis;
using Appwrite.Core.Helpers;
using Appwrite.Core.Models;

namespace Appwrite.Core.Services;

public class Databases : HttpClientProvider
{
    private readonly IDatabases _databasesApi;

    public Databases(Client client)
    {
        _databasesApi = base.GetRestService<IDatabases>(client);
    }

    /// <summary>
    /// Create Database
    /// </summary>
    /// <para>Create a new Database.</para>
    /// <param name="databaseId">
    /// Unique Id. Choose your own unique ID or pass the string ID.unique() to auto generate it. 
    /// Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. 
    /// Can't start with a special char. Max length is 36 chars.
    /// </param>
    /// <param name="name">Collection name. Max length: 128 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Database</returns>
    public async Task<Database> Create(string databaseId, string name, CancellationToken cancellationToken)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "databaseId", databaseId },
            { "name", name }
        };

        return await _databasesApi.Create(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// List Databases
    /// </summary>
    /// <para>
    /// Get a list of all databases from the current Appwrite project. 
    /// You can use the search parameter to filter your results.
    /// </para>
    /// <param name="queries">
    /// Array of query strings generated using the Query class provided by the SDK. 
    /// Maximum of 100 queries are allowed, each 4096 characters long. 
    /// You may filter on the following attributes: name
    /// </param>
    /// <param name="search">Search term to filter your list results. Max length: 256 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>DatabaseList</returns>
    public async Task<DatabaseList> List(List<string>? queries = null,
        string? search = null,
        CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> queryParameters = null;

        if ((queries != null && queries.Count() > 0) || (!string.IsNullOrEmpty(search)))
        {
            queryParameters = new Dictionary<string, object>();

            if (queries != null && queries.Count() > 0)
            {
                queryParameters.Add("queries", queries);
            }

            if (!string.IsNullOrEmpty(search))
            {
                queryParameters.Add("search", search);
            }
        }

        return await _databasesApi.List(queryParameters, cancellationToken);
    }

    /// <summary>
    /// Get Database
    /// </summary>
    /// <para>
    /// Get a database by its unique ID. 
    /// This endpoint response returns a JSON object with the database metadata.
    /// </para>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Database</returns>
    public async Task<Database> Get(string databaseId, CancellationToken cancellationToken = default)
    {
        return await _databasesApi.Get(databaseId, cancellationToken);
    }

    /// <summary>
    /// Update Database
    /// </summary>
    /// <para>Update a database by its unique ID.</para>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="name">Collection name. Max length: 128 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Database</returns>
    public async Task<Database> Update(string databaseId, string name, CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "name", name }
        };

        return await _databasesApi.Update(databaseId, bodyParameters, cancellationToken);
    }
}
