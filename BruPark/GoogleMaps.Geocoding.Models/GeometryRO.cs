using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMaps.Geocoding.Models
{
    [JsonObject]
    public class GeometryRO
    {
        [JsonProperty(PropertyName = "bounds")]
        public BoundsRO Bounds { get; set; }

        [JsonProperty(PropertyName = "location")]
        public GeoLocationRO Location { get; set; }

        [JsonProperty(PropertyName = "location_type")]
        public string LocationType { get; set; }

        [JsonProperty(PropertyName = "viewport")]
        public BoundsRO Viewport { get; set; }
    }
}
