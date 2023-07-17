using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record Collection
{
    [JsonPropertyName("$id")]
    public string Id { get; init; }

    [JsonPropertyName("$createdAt")]
    public string CreatedAt { get; init; }

    [JsonPropertyName("$updatedAt")]
    public string UpdatedAt { get; init; }

    [JsonPropertyName("$permissions")]
    public List<object> Permissions { get; init; }

    [JsonPropertyName("databaseId")]
    public string DatabaseId { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("enabled")]
    public bool Enabled { get; init; }

    [JsonPropertyName("documentSecurity")]
    public bool DocumentSecurity { get; init; }

    [JsonPropertyName("attributes")]
    public List<object> Attributes { get; init; }

    [JsonPropertyName("indexes")]
    public List<Index> Indexes { get; init; }
}
