using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record User
{
    [JsonPropertyName("$id")]
    public string Id { get; init; }

    [JsonPropertyName("$createdAt")]
    public string CreatedAt { get; init; }

    [JsonPropertyName("$updatedAt")]
    public string UpdatedAt { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("password")]
    public string? Password { get; init; }

    [JsonPropertyName("hash")]
    public string? Hash { get; init; }

    [JsonPropertyName("hashOptions")]
    public object? HashOptions { get; init; }

    [JsonPropertyName("registration")]
    public string Registration { get; init; }

    [JsonPropertyName("status")]
    public bool Status { get; init; }

    [JsonPropertyName("passwordUpdate")]
    public string PasswordUpdate { get; init; }

    [JsonPropertyName("email")]
    public string Email { get; init; }

    [JsonPropertyName("phone")]
    public string Phone { get; init; }

    [JsonPropertyName("emailVerification")]
    public bool EmailVerification { get; init; }

    [JsonPropertyName("phoneVerification")]
    public bool PhoneVerification { get; init; }

    [JsonPropertyName("prefs")]
    public Preferences Prefs { get; init; }
}
