using Newtonsoft.Json;

namespace GoogleMaps.DistanceMatrix.Models
{
    [JsonObject]
    public class DistanceMatrixDataRO
    {
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "value")]
        public long Value { get; set; }
    }
}
