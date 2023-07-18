using Appwrite.Core.Apis;
using Appwrite.Core.Helpers;
using Appwrite.Core.Models;

using Refit;

using System.Xml;

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

        if ((queries != null && queries.Any()) || (!string.IsNullOrEmpty(search)))
        {
            queryParameters = new Dictionary<string, object>();

            if (queries != null && queries.Any())
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

        if (permissions != null && permissions.Any())
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

        if ((queries != null && queries.Any()) || (!string.IsNullOrEmpty(search)))
        {
            queryParameters = new Dictionary<string, object>();

            if (queries != null && queries.Any())
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

        if (permissions != null && permissions.Any())
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

    /// <summary>
    /// Create URL Attribute
    /// </summary>
    /// <para>Create a URL attribute.</para>
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
    /// <returns>AttributeUrl</returns>
    public async Task<AttributeUrl> CreateUrlAttribute(string databaseId,
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

        return await _databasesApi.CreateUrlAttribute(databaseId, collectionId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create Integer Attribute
    /// </summary>
    /// <para>Create an integer attribute. Optionally, minimum and maximum values can be provided.</para>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Collection ID. 
    /// You can create a new collection using the Create Collection API.
    /// </param>
    /// <param name="key">Attribute Key.</param>
    /// <param name="required">Is attribute required?</param>
    /// <param name="min">Minimum value to enforce on new documents</param>
    /// <param name="max">Maximum value to enforce on new documents</param>
    /// <param name="@default">Default value for attribute when not provided. Cannot be set when attribute is required.</param>
    /// <param name="array">Is attribute an array?</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>AttributeInteger</returns>
    public async Task<AttributeInteger> CreateIntegerAttribute(string databaseId,
        string collectionId,
        string key,
        bool required,
        int? min = null,
        int? max = null,
        int? @default = null,
        bool? array = null,
        CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "key", key },
            { "required", required }
        };

        if (min != null)
        {
            bodyParameters.Add("min", min);
        }

        if (max != null)
        {
            bodyParameters.Add("max", max);
        }

        if (@default != null)
        {
            bodyParameters.Add("default", @default);
        }

        if (array != null)
        {
            bodyParameters.Add("array", array);
        }

        return await _databasesApi.CreateIntegerAttribute(databaseId, collectionId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create Float Attribute
    /// </summary>
    /// <para>Create a float attribute. Optionally, minimum and maximum values can be provided.</para>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Collection ID. 
    /// You can create a new collection using the Create Collection API.
    /// </param>
    /// <param name="key">Attribute Key.</param>
    /// <param name="required">Is attribute required?</param>
    /// <param name="min">Minimum value to enforce on new documents</param>
    /// <param name="max">Maximum value to enforce on new documents</param>
    /// <param name="@default">Default value for attribute when not provided. Cannot be set when attribute is required.</param>
    /// <param name="array">Is attribute an array?</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>AttributeFloat</returns>
    public async Task<AttributeFloat> CreateFloatAttribute(string databaseId,
        string collectionId,
        string key,
        bool required,
        int? min = null,
        int? max = null,
        int? @default = null,
        bool? array = null,
        CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "key", key },
            { "required", required }
        };

        if (min != null)
        {
            bodyParameters.Add("min", min);
        }

        if (max != null)
        {
            bodyParameters.Add("max", max);
        }

        if (@default != null)
        {
            bodyParameters.Add("default", @default);
        }

        if (array != null)
        {
            bodyParameters.Add("array", array);
        }

        return await _databasesApi.CreateFloatAttribute(databaseId, collectionId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create Boolean Attribute
    /// </summary>
    /// <para>Create a boolean attribute.</para>
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
    /// <returns>AttributeBoolean</returns>
    public async Task<AttributeBoolean> CreateBooleanAttribute(string databaseId,
        string collectionId,
        string key,
        bool required,
        bool? @default = null,
        bool? array = null,
        CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "key", key },
            { "required", required }
        };

        if (@default != null)
        {
            bodyParameters.Add("default", @default);
        }

        if (array != null)
        {
            bodyParameters.Add("array", array);
        }

        return await _databasesApi.CreateBooleanAttribute(databaseId, collectionId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// Create DateTime Attribute
    /// </summary>
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
    /// <returns>AttributeDatetime</returns>
    public async Task<AttributeDatetime> CreateDatetimeAttribute(string databaseId,
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

        return await _databasesApi.CreateDatetimeAttribute(databaseId, collectionId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// List Attributes
    /// </summary>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Collection ID. 
    /// You can create a new collection using the Create Collection API.
    /// </param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>AttributeList</returns>
    public async Task<AttributeList> ListAttributes(string databaseId, string collectionId, CancellationToken cancellationToken = default)
    {
        return await _databasesApi.ListAttributes(databaseId, collectionId, cancellationToken);
    }

    /// <summary>
    /// Get Attribute
    /// </summary>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Collection ID. 
    /// You can create a new collection using the Create Collection API.
    /// </param>
    /// <param name="key">Attribute Key.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>object</returns>
    public async Task<object> GetAttribute(string databaseId, string collectionId, string key, CancellationToken cancellationToken = default)
    {
        return await _databasesApi.GetAttribute(databaseId, collectionId, key, cancellationToken);
    }

    /// <summary>
    /// Delete Attribute
    /// </summary>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Collection ID. 
    /// You can create a new collection using the Create Collection API.
    /// </param>
    /// <param name="key">Attribute Key.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns></returns>
    public async Task DeleteAttribute(string databaseId, string collectionId, string key, CancellationToken cancellationToken = default)
    {
        await _databasesApi.DeleteAttribute(databaseId, collectionId, key, cancellationToken);
    }

    /// <summary>
    /// Create Index
    /// </summary>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Collection ID. 
    /// You can create a new collection using the Create Collection API.
    /// </param>
    /// <param name="key">Attribute Key.</param>
    /// <param name="type">Index type.</param>
    /// <param name="attributes">Array of attributes to index. Maximum of 100 attributes are allowed, each 32 characters long.</param>
    /// <param name="orders">Array of index orders. Maximum of 100 orders are allowed.</param>
    /// <param name="cancellationToken">CancellationToken</param>
    /// <returns>Index</returns>
    public async Task<Models.Index> CreateIndex(string databaseId,
        string collectionId,
        string key,
        string type,
        IEnumerable<string> attributes,
        IEnumerable<string>? orders = null,
        CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "key", key },
            { "type", type },
            { "attributes", attributes }
        };

        if (orders != null && orders.Any())
        {
            bodyParameters.Add("orders", orders);
        }

        return await _databasesApi.CreateIndex(databaseId, collectionId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// List Indexes
    /// </summary>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Collection ID. 
    /// You can create a new collection using the Create Collection API.
    /// </param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>IndexList</returns>
    public async Task<IndexList> ListIndexes(string databaseId,
        string collectionId,
        CancellationToken cancellationToken = default)
    {
        return await _databasesApi.ListIndexes(databaseId, collectionId, cancellationToken);
    }

    /// <summary>
    /// Get Index
    /// </summary>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Collection ID. 
    /// You can create a new collection using the Create Collection API.
    /// </param>
    /// <param name="key">Index Key.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Index</returns>
    public async Task<Models.Index> GetIndex(string databaseId,
        string collectionId,
        string key,
        CancellationToken cancellationToken = default)
    {
        return await _databasesApi.GetIndex(databaseId, collectionId, key, cancellationToken);
    }

    /// <summary>
    /// Delete Index
    /// </summary>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Collection ID. 
    /// You can create a new collection using the Create Collection API.
    /// </param>
    /// <param name="key">Index Key.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns></returns>
    public async Task DeleteIndex(string databaseId,
        string collectionId,
        string key,
        CancellationToken cancellationToken = default)
    {
        await _databasesApi.DeleteIndex(databaseId, collectionId, key, cancellationToken);
    }

    /// <summary>
    /// Create Document
    /// </summary>
    /// <para>
    /// Create a new Document. 
    /// Before using this route, you should create a new collection resource 
    /// using either via Create Collection API or directly from your database console.
    /// </para>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Collection ID. 
    /// You can create a new collection using the Database service server integration. 
    /// Make sure to define attributes before creating documents.
    /// </param>
    /// <param name="documentId">
    /// Document ID. 
    /// Choose your own unique ID or pass the string ID.unique() to auto generate it. 
    /// Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. 
    /// Can't start with a special char. Max length is 36 chars.
    /// </param>
    /// <param name="data">Document data as JSON object.</param>
    /// <param name="permissions">
    /// An array of permissions strings. 
    /// By default the current user is granted with all permissions.
    /// </param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Document</returns>
    public async Task<Document> CreateDocument(string databaseId,
        string collectionId,
        string documentId,
        object data,
        IEnumerable<string>? permissions = null,
        CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "documentId", documentId },
            { "data", data }
        };

        if (permissions != null && permissions.Any())
        {
            bodyParameters.Add("permissions", permissions);
        }

        return await _databasesApi.CreateDocument(databaseId, collectionId, bodyParameters, cancellationToken);
    }

    /// <summary>
    /// List Documents
    /// </summary>
    /// <para>
    /// Get a list of all the user's documents in a given collection. 
    /// You can use the query params to filter your results.
    /// </para>
    /// <param name="databaseId">Database ID.</param>
    /// <param name="collectionId">
    /// Collection ID. 
    /// You can create a new collection using the Database service server integration.
    /// </param>
    /// <param name="queries">Array of query strings.Maximum of 100 queries are allowed, each 4096 characters long.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>DocumentList</returns>
    public async Task<DocumentList> ListDocuments(string databaseId,
        string collectionId,
        IEnumerable<string>? queries = null,
        CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> queryParameters = new Dictionary<string, object>
        {
            { "queries", queries }
        };

        return await _databasesApi.ListDocuments(databaseId, collectionId, queryParameters, cancellationToken);
    }
}
