using Newtonsoft.Json;

namespace BruPark.OpenData.Models
{
    [JsonObject]
    public class Geometry
    {
        [JsonProperty(PropertyName = "coordinates")]
        public decimal[] Coordinates { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
