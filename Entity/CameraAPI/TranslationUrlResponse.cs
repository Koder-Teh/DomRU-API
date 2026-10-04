using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DomruAPI.Entity.CameraAPI
{
    public class TranslationUrlResponse
    {
        [JsonPropertyName("data")]
        public UrlStream Data;

    }

    public class UrlStream
    {
        [JsonPropertyName("URL")]
        public string? URL;
    }
}
