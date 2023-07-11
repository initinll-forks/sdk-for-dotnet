using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record UserList
{
    [JsonPropertyName("total")]
    public long Total { get; init; }

    [JsonPropertyName("users")]
    public List<User> Users { get; init; }
}
