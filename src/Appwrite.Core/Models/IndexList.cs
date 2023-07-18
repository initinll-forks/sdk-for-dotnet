using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record IndexList
{
    [JsonPropertyName("total")]
    public long Total { get; init; }

    [JsonPropertyName("indexes")]
    public List<Index> Indexes { get; init; }
}
