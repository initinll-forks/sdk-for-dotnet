using Appwrite.Core.Apis;
using Appwrite.Core.Helpers;
using Appwrite.Core.Models;

using Refit;

using System.Xml.Linq;

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
    public async Task<DatabaseList> List(IEnumerable<string>? queries = null,
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

    /// <summary>
    /// Delete Database
    /// </summary>
    /// <para>
    /// Delete a database by its unique ID. 
    /// Only API keys with with databases.write scope can delete a database.
    /// </para>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns></returns>
    public async Task Delete(string databaseId, CancellationToken cancellationToken = default)
    {
        await _databasesApi.Delete(databaseId, cancellationToken);
    }

    /// <summary>
    /// Create Collection
    /// </summary>
    /// <para>
    /// Create a new Collection. 
    /// Before using this route, you should create a new database resource using 
    /// either a server integration API or directly from your database console.
    /// </para>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Unique Id. 
    /// Choose your own unique ID or pass the string ID.unique() to auto generate it. 
    /// Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. 
    /// Can't start with a special char. Max length is 36 chars.
    /// </param>
    /// <param name="name">Collection name. Max length: 128 chars.</param>
    /// <param name="permissions">
    /// An array of permissions strings. By default no user is granted with any permissions.
    /// </param>
    /// <param name="documentSecurity">
    /// Enables configuring permissions for individual documents. 
    /// A user needs one of document or collection level permissions to access a document. 
    /// </param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Collection</returns>
    public async Task<Collection> CreateCollection(string databaseId,
        string collectionId,
        string name,
        IEnumerable<string>? permissions = null,
        bool? documentSecurity = null,
        CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "collectionId", collectionId },
            { "name", name }
        };

        if (permissions != null && permissions.Count() > 0)
        {
            bodyParameters.Add("permissions", permissions);
        }

        if (documentSecurity != null)
        {
            bodyParameters.Add("documentSecurity", documentSecurity);
        }

        return await _databasesApi.CreateCollection(databaseId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// List Collections
    /// </summary>
    /// <para>
    /// Get a list of all collections that belong to the provided databaseId. 
    /// You can use the search parameter to filter your results.
    /// </para>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="queries">
    /// Array of query strings generated using the Query class provided by the SDK. 
    /// Maximum of 100 queries are allowed, each 4096 characters long. 
    /// You may filter on the following attributes: name, enabled, documentSecurity
    /// </param>
    /// <param name="search">Search term to filter your list results. Max length: 256 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>CollectionList</returns>
    public async Task<CollectionList> ListCollections(string databaseId,
        IEnumerable<string>? queries = null,
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

        return await _databasesApi.ListCollections(databaseId, queryParameters, cancellationToken);
    }

    /// <summary>
    /// Get Collection
    /// </summary>
    /// <para>
    /// Get a collection by its unique ID. 
    /// This endpoint response returns a JSON object with the collection metadata.
    /// </para>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">Collection ID.</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>Collection</returns>
    public async Task<Collection> GetCollection(string databaseId,
        string collectionId,
        CancellationToken cancellationToken = default)
    {
        return await _databasesApi.GetCollection(databaseId, collectionId, cancellationToken);
    }

    /// <summary>
    /// Update Collection
    /// </summary>
    /// <para>Update a collection by its unique ID.</para>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">Collection ID.</param>
    /// <param name="name">Collection name. Max length: 128 chars.</param>
    /// <param name="permissions">
    /// An array of permission strings. 
    /// By default the current permission are inherited.
    /// </param>
    /// <param name="documentSecurity">
    /// Enables configuring permissions for individual documents. 
    /// A user needs one of document or collection level permissions to access a document.
    /// </param>
    /// <param name="enabled">Is collection enabled?</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Collection</returns>
    public async Task<Collection> UpdateCollection(string databaseId,
        string collectionId,
        string name,
        IEnumerable<string>? permissions = null,
        bool? documentSecurity = null,
        bool? enabled = null,
        CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "name", name }
        };

        if (permissions != null && permissions.Count() > 0)
        {
            bodyParameters.Add("permissions", permissions);
        }

        if (documentSecurity != null)
        {
            bodyParameters.Add("documentSecurity", documentSecurity);
        }

        if (enabled != null)
        {
            bodyParameters.Add("enabled", enabled);
        }

        return await _databasesApi.UpdateCollection(databaseId, collectionId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Delete Collection
    /// </summary>
    /// <para>
    /// Delete a collection by its unique ID. 
    /// Only users with write permissions have access to delete this resource.
    /// </para>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">Collection ID.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns></returns>
    public async Task DeleteCollection(string databaseId, string collectionId, CancellationToken cancellationToken = default)
    {
        await _databasesApi.DeleteCollection(databaseId, collectionId, cancellationToken);
    }

    /// <summary>
    /// Create String Attribute
    /// </summary>
    /// <para>Create a string attribute.</para>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Collection ID. 
    /// You can create a new collection using the Create Collection API.
    /// </param>
    /// <param name="key">Attribute Key.</param>
    /// <param name="size">Attribute size for text attributes, in number of characters.</param>
    /// <param name="required">Is attribute required?</param>
    /// <param name="@default">Default value for attribute when not provided. Cannot be set when attribute is required.</param>
    /// <param name="array">Is attribute an array?</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>AttributeString</returns>
    public async Task<AttributeString> CreateStringAttribute(string databaseId, 
        string collectionId, 
        string key, 
        int size, 
        bool required, 
        string? @default = null, 
        bool? array = null, 
        CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "key", key },
            { "size", size },
            { "required", required }
        };

        if (!string.IsNullOrEmpty(@default))
        {
            bodyParameters.Add("default", @default);
        }

        if (array != null)
        {
            bodyParameters.Add("array", array);
        }

        return await _databasesApi.CreateStringAttribute(databaseId, collectionId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create Email Attribute
    /// </summary>
    /// <para>Create an email attribute.</para>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Collection ID. 
    /// You can create a new collection using the Create Collection API.
    /// </param>
    /// <param name="key">Attribute Key.</param>
    /// <param name="size">Attribute size for text attributes, in number of characters.</param>
    /// <param name="required">Is attribute required?</param>
    /// <param name="@default">Default value for attribute when not provided. Cannot be set when attribute is required.</param>
    /// <param name="array">Is attribute an array?</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>AttributeEmail</returns>
    public async Task<AttributeEmail> CreateEmailAttribute(string databaseId,
        string collectionId,
        string key,
        int size,
        bool required,
        string? @default = null,
        bool? array = null,
        CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "key", key },
            { "size", size },
            { "required", required }
        };

        if (!string.IsNullOrEmpty(@default))
        {
            bodyParameters.Add("default", @default);
        }

        if (array != null)
        {
            bodyParameters.Add("array", array);
        }

        return await _databasesApi.CreateEmailAttribute(databaseId, collectionId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create Enum Attribute
    /// </summary>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Collection ID. 
    /// You can create a new collection using the Create Collection API.
    /// </param>
    /// <param name="key">Attribute Key.</param>
    /// <param name="elements">
    /// Array of elements in enumerated type. 
    /// Uses length of longest element to determine size. 
    /// Maximum of 100 elements are allowed, each 4096 characters long.
    /// </param>
    /// <param name="required">Is attribute required?</param>
    /// <param name="@default">Default value for attribute when not provided. Cannot be set when attribute is required.</param>
    /// <param name="array">Is attribute an array?</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>AttributeEnum</returns>
    public async Task<AttributeEnum> CreateEnumAttribute(string databaseId,
        string collectionId,
        string key,
        IEnumerable<string> elements,
        bool required,
        string? @default = null,
        bool? array = null,
        CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "key", key },
            { "elements", elements },
            { "required", required }
        };

        if (!string.IsNullOrEmpty(@default))
        {
            bodyParameters.Add("default", @default);
        }

        if (array != null)
        {
            bodyParameters.Add("array", array);
        }

        return await _databasesApi.CreateEnumAttribute(databaseId, collectionId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create IP Address Attribute
    /// </summary>
    /// <para>Create IP address attribute.</para>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Collection ID. 
    /// You can create a new collection using the Create Collection API.
    /// </param>
    /// <param name="key">Attribute Key.</param>
    /// <param name="required">Is attribute required?</param>
    /// <param name="@default">Default value for attribute when not provided. Cannot be set when attribute is required.</param>
    /// <param name="array">Is attribute an array?</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>AttributeIp</returns>
    public async Task<AttributeIp> CreateIpAttribute(string databaseId,
        string collectionId,
        string key,
        bool required,
        string? @default = null,
        bool? array = null,
        CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "key", key },
            { "required", required }
        };

        if (!string.IsNullOrEmpty(@default))
        {
            bodyParameters.Add("default", @default);
        }

        if (array != null)
        {
            bodyParameters.Add("array", array);
        }

        return await _databasesApi.CreateIpAttribute(databaseId, collectionId, bodyParameters, cancellationToken);
    }
}
