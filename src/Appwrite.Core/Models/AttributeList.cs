using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record AttributeList
{
    [JsonPropertyName("total")]
    public long Total { get; init; }

    [JsonPropertyName("attributes")]
    public List<object> Attributes { get; init; }
}
