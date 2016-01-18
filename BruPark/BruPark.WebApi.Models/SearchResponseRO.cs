using Newtonsoft.Json;
using System.Collections.Generic;

namespace BruPark.WebApi.Models
{
    [JsonObject]
    public class SearchResponseRO
    {
        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "results", NullValueHandling = NullValueHandling.Ignore)]
        public IList<ParkingRO> Results { get; set; }
    }
}
