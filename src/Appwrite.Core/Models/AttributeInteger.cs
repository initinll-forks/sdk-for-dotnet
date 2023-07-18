using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record AttributeInteger
{
    [JsonPropertyName("key")]
    public string Key { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; }

    [JsonPropertyName("status")]
    public string Status { get; init; }

    [JsonPropertyName("required")]
    public bool Required { get; init; }

    [JsonPropertyName("array")]
    public bool? Array { get; init; }

    [JsonPropertyName("min")]
    public long? Min { get; init; }

    [JsonPropertyName("max")]
    public long? Max { get; init; }

    [JsonPropertyName("default")]
    public long? Default { get; init; }
}
