using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMaps.Geocoding.Models
{
    [JsonObject]
    public class GeoLocationRO
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
