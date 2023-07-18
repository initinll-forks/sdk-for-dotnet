using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record AttributeEnum
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

    [JsonPropertyName("elements")]
    public List<object> Elements { get; init; }

    [JsonPropertyName("format")]
    public string Format { get; init; }

    [JsonPropertyName("default")]
    public string? Default { get; init; }
}
