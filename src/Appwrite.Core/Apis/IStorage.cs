using Appwrite.Core.Models;

using Refit;

namespace Appwrite.Core.Apis;

internal interface IStorage
{
    [Post("/storage/buckets")]
    Task<Bucket> CreateBucket([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);
}
