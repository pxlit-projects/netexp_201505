using Newtonsoft.Json;

namespace BruPark.WebApi.Models
{
    [JsonObject]
    public class LocationRO
    {
        [JsonProperty(PropertyName = "latitude")]
        public decimal Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public decimal Longitude { get; set; }
    }
}
