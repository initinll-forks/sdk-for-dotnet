
using System;
using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Appwrite.Models
{
    public class AttributeEnum
    {
        [JsonProperty("key")]
        public string Key { get; private set; }

        [JsonProperty("type")]
        public string Type { get; private set; }

        [JsonProperty("status")]
        public string Status { get; private set; }

        [JsonProperty("required")]
        public bool Required { get; private set; }

        [JsonProperty("array")]
        public bool? Array { get; private set; }

        [JsonProperty("elements")]
        public List<object> Elements { get; private set; }

        [JsonProperty("format")]
        public string Format { get; private set; }

        [JsonProperty("default")]
        public string? Default { get; private set; }

        public AttributeEnum(
            string key,
            string type,
            string status,
            bool required,
            bool? array,
            List<object> elements,
            string format,
            string? xdefault
        ) {
            Key = key;
            Type = type;
            Status = status;
            Required = required;
            Array = array;
            Elements = elements;
            Format = format;
            Default = xdefault;
        }

        public static AttributeEnum From(Dictionary<string, object> map) => new AttributeEnum(
            key: map["key"].ToString(),
            type: map["type"].ToString(),
            status: map["status"].ToString(),
            required: (bool)map["required"],
            array: (bool?)map["array"],
            elements: ((JArray)map["elements"]).ToObject<List<object>>(),
            format: map["format"].ToString(),
            xdefault: map["default"]?.ToString()
        );

        public Dictionary<string, object?> ToMap() => new Dictionary<string, object?>()
        {
            { "key", Key },
            { "type", Type },
            { "status", Status },
            { "required", Required },
            { "array", Array },
            { "elements", Elements },
            { "format", Format },
            { "default", Default }
        };
    }
}