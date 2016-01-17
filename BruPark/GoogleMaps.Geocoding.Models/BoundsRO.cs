using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMaps.Geocoding.Models
{
    [JsonObject]
    public class BoundsRO
    {
        [JsonProperty(PropertyName = "northeast")]
        public GeoLocationRO NorthEast { get; set; }

        [JsonProperty(PropertyName = "southwest")]
        public GeoLocationRO SouthWest { get; set; }
    }
}
