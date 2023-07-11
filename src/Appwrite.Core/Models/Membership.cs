using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record Membership
{
    [JsonPropertyName("$id")]
    public string Id { get; init; }

    [JsonPropertyName("$createdAt")]
    public string CreatedAt { get; init; }

    [JsonPropertyName("$updatedAt")]
    public string UpdatedAt { get; init; }

    [JsonPropertyName("userId")]
    public string UserId { get; init; }

    [JsonPropertyName("userName")]
    public string UserName { get; init; }

    [JsonPropertyName("userEmail")]
    public string UserEmail { get; init; }

    [JsonPropertyName("teamId")]
    public string TeamId { get; init; }

    [JsonPropertyName("teamName")]
    public string TeamName { get; init; }

    [JsonPropertyName("invited")]
    public string Invited { get; init; }

    [JsonPropertyName("joined")]
    public string Joined { get; init; }

    [JsonPropertyName("confirm")]
    public bool Confirm { get; init; }

    [JsonPropertyName("roles")]
    public List<object> Roles { get; init; }
}
