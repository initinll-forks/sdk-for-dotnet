using Appwrite.Core.Apis;
using Appwrite.Core.Helpers;
using Appwrite.Core.Models;

namespace Appwrite.Core.Services;

public class Storage : HttpClientProvider
{
    private readonly IStorage _storageApi;

    public Storage(Client client)
    {
        _storageApi = base.GetRestService<IStorage>(client);
    }

    /// <summary>
    /// Create bucket
    /// </summary>
    /// <para>Create a new storage bucket.</para>
    /// <param name="bucketId">
    /// Unique Id. 
    /// Choose your own unique ID or pass the string ID.unique() to auto generate it. 
    /// Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. 
    /// Can't start with a special char. Max length is 36 chars.
    /// </param>
    /// <param name="name">Bucket name</param>
    /// <param name="permissions">An array of permission strings. By default no user is granted with any permissions.</param>
    /// <param name="fileSecurity">
    /// Enables configuring permissions for individual file. 
    /// A user needs one of file or bucket level permissions to access a file.
    /// </param>
    /// <param name="enabled">Is bucket enabled?</param>
    /// <param name="maximumFileSize">
    /// Maximum file size allowed in bytes. 
    /// Maximum allowed value is 30MB. 
    /// For self-hosted setups you can change the max limit by changing the _APP_STORAGE_LIMIT environment variable.
    /// </param>
    /// <param name="allowedFileExtensions">
    /// Allowed file extensions. 
    /// Maximum of 100 extensions are allowed, each 64 characters long.
    /// </param>
    /// <param name="compression">
    /// Compression algorithm choosen for compression. 
    /// Can be one of none, gzip, or zstd, For file size above 20MB compression is skipped even if it's enabled
    /// </param>
    /// <param name="encryption">
    /// Is encryption enabled? For file size above 20MB encryption is skipped even if it's enabled
    /// </param>
    /// <param name="antivirus">
    /// Is virus scanning enabled? For file size above 20MB AntiVirus scanning is skipped even if it's enabled
    /// </param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>Bucket</returns>
    public async Task<Bucket> CreateBucket(string bucketId,
        string name,
        IEnumerable<string>? permissions = null,
        bool? fileSecurity = null,
        bool? enabled = null,
        int? maximumFileSize = null,
        IEnumerable<string>? allowedFileExtensions = null,
        string? compression = null,
        bool? encryption = null,
        bool? antivirus = null,
        CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> bodyParameters = new Dictionary<string, object>
        {
            { "bucketId", bucketId },
            { "name", name }
        };

        if (permissions != null && permissions.Any())
        {
            bodyParameters.Add("permissions", permissions);
        }

        if (fileSecurity != null)
        {
            bodyParameters.Add("fileSecurity", fileSecurity);
        }

        if (enabled != null)
        {
            bodyParameters.Add("enabled", enabled);
        }

        if (maximumFileSize != null)
        {
            bodyParameters.Add("maximumFileSize", maximumFileSize);
        }

        if (allowedFileExtensions != null && allowedFileExtensions.Any())
        {
            bodyParameters.Add("allowedFileExtensions", allowedFileExtensions);
        }

        if (!string.IsNullOrEmpty(compression))
        {
            bodyParameters.Add("compression", compression);
        }

        if (encryption != null)
        {
            bodyParameters.Add("encryption", encryption);
        }

        if (antivirus != null)
        {
            bodyParameters.Add("antivirus", antivirus);
        }

        return await _storageApi.CreateBucket(bodyParameters, cancellationToken);
    }

    /// <summary>
    /// List buckets
    /// </summary>
    /// <para>Get a list of all the storage buckets. You can use the query params to filter your results.</para>
    /// <param name="queries">
    /// Array of query strings generated using the Query class provided by the SDK.
    /// Maximum of 100 queries are allowed, each 4096 characters long. You may filter 
    /// on the following attributes: enabled, name, fileSecurity, maximumFileSize, encryption, antivirus
    /// </param>
    /// <param name="search">Search term to filter your list results. Max length: 256 chars.</param>
    /// <param name="cancellationToken">Cancellation Token</param>
    /// <returns>BucketList</returns>
    public async Task<BucketList> ListBuckets(IEnumerable<string>? queries = null,
        string? search = null,
        CancellationToken cancellationToken = default)
    {
        IDictionary<string, object> queryParameters = null;

        if ((queries != null && queries.Any()) || !string.IsNullOrEmpty(search))
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

        return await _storageApi.ListBuckets(queryParameters, cancellationToken);
    }
}
