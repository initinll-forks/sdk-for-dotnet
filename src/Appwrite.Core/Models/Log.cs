using System.Text.Json.Serialization;

namespace Appwrite.Core.Models;

public record Log
{
    [JsonPropertyName("event")]
    public string Event { get; init; }

    [JsonPropertyName("userId")]
    public string UserId { get; init; }

    [JsonPropertyName("userEmail")]
    public string UserEmail { get; init; }

    [JsonPropertyName("userName")]
    public string UserName { get; init; }

    [JsonPropertyName("mode")]
    public string Mode { get; init; }

    [JsonPropertyName("ip")]
    public string Ip { get; init; }

    [JsonPropertyName("time")]
    public string Time { get; init; }

    [JsonPropertyName("osCode")]
    public string OsCode { get; init; }

    [JsonPropertyName("osName")]
    public string OsName { get; init; }

    [JsonPropertyName("osVersion")]
    public string OsVersion { get; init; }

    [JsonPropertyName("clientType")]
    public string ClientType { get; init; }

    [JsonPropertyName("clientCode")]
    public string ClientCode { get; init; }

    [JsonPropertyName("clientName")]
    public string ClientName { get; init; }

    [JsonPropertyName("clientVersion")]
    public string ClientVersion { get; init; }

    [JsonPropertyName("clientEngine")]
    public string ClientEngine { get; init; }

    [JsonPropertyName("clientEngineVersion")]
    public string ClientEngineVersion { get; init; }

    [JsonPropertyName("deviceName")]
    public string DeviceName { get; init; }

    [JsonPropertyName("deviceBrand")]
    public string DeviceBrand { get; init; }

    [JsonPropertyName("deviceModel")]
    public string DeviceModel { get; init; }

    [JsonPropertyName("countryCode")]
    public string CountryCode { get; init; }

    [JsonPropertyName("countryName")]
    public string CountryName { get; init; }
}
