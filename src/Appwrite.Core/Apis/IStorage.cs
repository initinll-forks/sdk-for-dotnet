using Appwrite.Core.Models;

using Refit;

namespace Appwrite.Core.Apis;

internal interface IStorage
{
    [Post("/storage/buckets")]
    Task<Bucket> CreateBucket([Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);

    [Get("/storage/buckets")]
    Task<BucketList> ListBuckets([Query] IDictionary<string, object>? queryParameters = null, CancellationToken cancellationToken = default);

    [Get("/storage/buckets/{bucketId}")]
    Task<Bucket> GetBucket(string bucketId, CancellationToken cancellationToken = default);

    [Put("/storage/buckets/{bucketId}")]
    Task<Bucket> UpdateBucket(string bucketId, [Body(BodySerializationMethod.UrlEncoded)] IDictionary<string, object> bodyParameters, CancellationToken cancellationToken = default);
}
