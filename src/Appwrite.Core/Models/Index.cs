using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record Index
{
    [JsonPropertyName("key")]
    public string Key { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; }

    [JsonPropertyName("status")]
    public string Status { get; init; }

    [JsonPropertyName("attributes")]
    public List<object> Attributes { get; init; }

    [JsonPropertyName("orders")]
    public List<object>? Orders { get; init; }
}
