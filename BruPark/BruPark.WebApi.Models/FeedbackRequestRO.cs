using Newtonsoft.Json;

namespace BruPark.WebApi.Models
{
    [JsonObject]
    public class FeedbackRequestRO
    {
        [JsonProperty(PropertyName = "available")]
        public bool Available { get; set; }
    }
}
