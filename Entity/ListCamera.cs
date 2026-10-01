using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DomruAPI.Model
{
    public class ListCamera
    {
        [JsonPropertyName("data")]
        public List<DataCamera> Data { get; set; }
        
        public ListCamera() { }
    }

    public class DataCamera
    {
        [JsonPropertyName("ID")]
        public long ID { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("IsActive")]
        public int IsActive { get; set; }

        [JsonPropertyName("IsSound")]
        public int IsSound { get; set; }

        [JsonPropertyName("RecordType")]
        public int RecordType { get; set; }

        [JsonPropertyName("Quota")]
        public long Quota { get; set; }

        [JsonPropertyName("MaxBandwidth")]
        public string? MaxBandwidth { get; set; }

        [JsonPropertyName("HomeMode")]
        public int HomeMode { get; set; }

        [JsonPropertyName("Devices")]
        public string? Devices { get; set; }

        [JsonPropertyName("State")]
        public int State { get; set; }

        [JsonPropertyName("TimeZone")]
        public long TimeZone { get; set; }

        [JsonPropertyName("MotionDetectorMode")]
        public string MotionDetectorMode { get; set; }

        [JsonPropertyName("ParentID")]
        public string ParentID { get; set; }
    }
}
