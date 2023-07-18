using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record Document
{
    [JsonPropertyName("$id")]
    public string Id { get; init; }

    [JsonPropertyName("$collectionId")]
    public string CollectionId { get; init; }

    [JsonPropertyName("$databaseId")]
    public string DatabaseId { get; init; }

    [JsonPropertyName("$createdAt")]
    public string CreatedAt { get; init; }

    [JsonPropertyName("$updatedAt")]
    public string UpdatedAt { get; init; }

    [JsonPropertyName("$permissions")]
    public List<object> Permissions { get; init; }

    public Dictionary<string, object> Data { get; init; }
}
