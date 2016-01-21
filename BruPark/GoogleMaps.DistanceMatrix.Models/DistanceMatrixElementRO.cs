using Newtonsoft.Json;

namespace GoogleMaps.DistanceMatrix.Models
{
    [JsonObject]
    public class DistanceMatrixElementRO
    {
        [JsonProperty(PropertyName = "distance")]
        public DistanceMatrixDataRO Distance { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public DistanceMatrixDataRO Duration { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
