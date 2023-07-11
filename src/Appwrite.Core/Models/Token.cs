using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record Token
{
    [JsonPropertyName("$id")]
    public string Id { get; init; }

    [JsonPropertyName("$createdAt")]
    public string CreatedAt { get; init; }

    [JsonPropertyName("userId")]
    public string UserId { get; init; }

    [JsonPropertyName("secret")]
    public string Secret { get; init; }

    [JsonPropertyName("expire")]
    public string Expire { get; init; }
}
