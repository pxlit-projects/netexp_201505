using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMaps.Geocoding.Models
{
    [JsonObject]
    public class GeocodingResponseRO
    {
        [JsonProperty(PropertyName = "results")]
        public IList<ResultRO> Results { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
