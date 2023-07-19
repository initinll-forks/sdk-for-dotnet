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
}
