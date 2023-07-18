using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record DocumentList
{
    [JsonPropertyName("total")]
    public long Total { get; init; }

    [JsonPropertyName("documents")]
    public List<Document> Documents { get; init; }
}
