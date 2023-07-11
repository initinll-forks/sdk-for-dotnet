using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record SessionList
{
    [JsonPropertyName("total")]
    public long Total { get; init; }

    [JsonPropertyName("sessions")]
    public List<Session> Sessions { get; init; }
}
