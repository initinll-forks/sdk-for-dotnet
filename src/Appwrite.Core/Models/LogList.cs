using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record LogList
{
    [JsonPropertyName("total")]
    public long Total { get; init; }

    [JsonPropertyName("logs")]
    public List<Log> Logs { get; init; }
}
