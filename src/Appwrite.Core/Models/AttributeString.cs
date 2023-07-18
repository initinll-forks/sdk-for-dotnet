﻿using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record AttributeString
{
    [JsonPropertyName("key")]
    public string Key { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; }

    [JsonPropertyName("status")]
    public string Status { get; init; }

    [JsonPropertyName("required")]
    public bool Required { get; init; }

    [JsonPropertyName("array")]
    public bool? Array { get; init; }

    [JsonPropertyName("size")]
    public long Size { get; init; }

    [JsonPropertyName("default")]
    public string? Default { get; init; }
}