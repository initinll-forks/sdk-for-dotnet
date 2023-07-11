using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record MembershipList
{
    [JsonPropertyName("total")]
    public long Total { get; init; }

    [JsonPropertyName("memberships")]
    public List<Membership> Memberships { get; init; }
}
