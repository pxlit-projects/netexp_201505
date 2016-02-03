using Newtonsoft.Json;

namespace BruPark.WebApi.Models
{
    [JsonObject]
    public class FeedbackRequestRO
    {
        [JsonProperty(PropertyName = "feedback")]
        public bool Feedback { get; set; }
    }
}
