using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DomruAPI.Entity.CameraAPI
{
    public class ServerTime
    {
        [JsonPropertyName("ServerTime")]
        public string? serverTime;

        [JsonPropertyName("TimeOffset")]
        public long timeOffset;

        public override string ToString()
        {
            return $"ServerTime: {serverTime},\n" +
                $"TimeOffset: {timeOffset}";
        }
    }
}
