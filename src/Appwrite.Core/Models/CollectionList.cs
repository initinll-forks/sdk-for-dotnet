using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record CollectionList
{
    [JsonPropertyName("total")]
    public long Total { get; init; }

    [JsonPropertyName("collections")]
    public List<Collection> Collections { get; init; }
}
