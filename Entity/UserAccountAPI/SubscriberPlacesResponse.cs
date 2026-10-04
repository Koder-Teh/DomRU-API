using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DomruAPI.Entity.UserAccountAPI
{
    public class SubscriberPlacesResponse
    {
        [JsonPropertyName("data")]
        public List<DataItem> Data { get; set; } = new();
    }

    public class DataItem
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("subscriberType")]
        public string SubscriberType { get; set; } = "";

        [JsonPropertyName("subscriberState")]
        public string SubscriberState { get; set; } = "";

        [JsonPropertyName("place")]
        public Place Place { get; set; } = new();

        [JsonPropertyName("subscriber")]
        public Subscriber Subscriber { get; set; } = new();

        [JsonPropertyName("guardCallOut")]
        public GuardCallOut GuardCallOut { get; set; } = new();

        [JsonPropertyName("payment")]
        public Payment Payment { get; set; } = new();

        [JsonPropertyName("provider")]
        public string Provider { get; set; } = "";

        [JsonPropertyName("blocked")]
        public bool Blocked { get; set; }
    }

    public class Place
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; } = new();

        [JsonPropertyName("location")]
        public Location Location { get; set; } = new();

        [JsonPropertyName("operatorId")]
        public int OperatorId { get; set; }

        [JsonPropertyName("autoArmingState")]
        public bool AutoArmingState { get; set; }

        [JsonPropertyName("autoArmingRadius")]
        public int AutoArmingRadius { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("index")]
        public string? Index { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; } = "";

        [JsonPropertyName("district")]
        public string? District { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; } = "";

        [JsonPropertyName("locality")]
        public string? Locality { get; set; }

        [JsonPropertyName("street")]
        public string Street { get; set; } = "";

        [JsonPropertyName("house")]
        public string House { get; set; } = "";

        [JsonPropertyName("building")]
        public string? Building { get; set; }

        [JsonPropertyName("apartment")]
        public string Apartment { get; set; } = "";

        [JsonPropertyName("visibleAddress")]
        public string VisibleAddress { get; set; } = "";

        [JsonPropertyName("groupName")]
        public string GroupName { get; set; } = "";
    }

    public class Location
    {
        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }
    }

    public class Subscriber
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("accountId")]
        public string AccountId { get; set; } = "";

        [JsonPropertyName("nickName")]
        public string? NickName { get; set; }
    }

    public class GuardCallOut
    {
        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; } = "";
    }

    public class Payment
    {
        [JsonPropertyName("useLink")]
        public bool UseLink { get; set; }
    }
}
