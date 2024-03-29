﻿using GoogleMaps.Commons;
using Newtonsoft.Json;
using System;

namespace GoogleMaps.Geocoding.Models
{
    [JsonObject]
    public class GeoLocationRO : GeoLocation
    {
        [JsonProperty(PropertyName = "lat")]
        public decimal Latitude { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public decimal Longitude { get; set; }

        public override string ToString()
        {
            return String.Format("({0}, {1})", Latitude, Longitude);
        }
    }
}
