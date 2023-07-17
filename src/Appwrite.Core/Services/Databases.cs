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
    /// <returns></returns>
    public async Task<Database> Create(string databaseId, string name, CancellationToken cancellationToken)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "databaseId", databaseId },
            { "name", name }
        };

        return await _databasesApi.Create(bodyParameters, cancellationToken);
    }
}
