using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DomruAPI.Entity.AuthAPI
{
    public class Token
    {
        [JsonPropertyName("operatorId")]
        public int OperatorId { get; set; }

        [JsonPropertyName("operatorName")]
        public string OperatorName { get; set; } = string.Empty;

        [JsonPropertyName("tokenType")]
        public string TokenType { get; set; } = string.Empty;

        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; } = string.Empty;

        [JsonPropertyName("expiresIn")]
        public int? ExpiresIn { get; set; }

        [JsonPropertyName("refreshToken")]
        public string? RefreshToken { get; set; }

        [JsonPropertyName("refreshExpiresIn")]
        public int? RefreshExpiresIn { get; set; }
    }
}
