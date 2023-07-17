using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record Database
{
    [JsonPropertyName("$id")]
    public string Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("$createdAt")]
    public string CreatedAt { get; init; }

    [JsonPropertyName("$updatedAt")]
    public string UpdatedAt { get; init; }
}
