using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record TeamList
{
    [JsonPropertyName("total")]
    public long Total { get; init; }

    [JsonPropertyName("teams")]
    public List<Team> Teams { get; init; }
}
