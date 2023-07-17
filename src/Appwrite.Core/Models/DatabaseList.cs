using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record DatabaseList
{
    [JsonPropertyName("total")]
    public long Total { get; private set; }

    [JsonPropertyName("databases")]
    public List<Database> Databases { get; private set; }
}
