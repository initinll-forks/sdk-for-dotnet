using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record Bucket
{
    [JsonPropertyName("$id")]
    public string Id { get; init; }

    [JsonPropertyName("$createdAt")]
    public string CreatedAt { get; init; }

    [JsonPropertyName("$updatedAt")]
    public string UpdatedAt { get; init; }

    [JsonPropertyName("$permissions")]
    public List<object> Permissions { get; init; }

    [JsonPropertyName("fileSecurity")]
    public bool FileSecurity { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("enabled")]
    public bool Enabled { get; init; }

    [JsonPropertyName("maximumFileSize")]
    public long MaximumFileSize { get; init; }

    [JsonPropertyName("allowedFileExtensions")]
    public List<object> AllowedFileExtensions { get; init; }

    [JsonPropertyName("compression")]
    public string Compression { get; init; }

    [JsonPropertyName("encryption")]
    public bool Encryption { get; init; }

    [JsonPropertyName("antivirus")]
    public bool Antivirus { get; init; }
}
