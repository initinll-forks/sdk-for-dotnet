using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record BucketList
{
    [JsonPropertyName("total")]
    public long Total { get; init; }

    [JsonPropertyName("buckets")]
    public List<Bucket> Buckets { get; init; }
}
