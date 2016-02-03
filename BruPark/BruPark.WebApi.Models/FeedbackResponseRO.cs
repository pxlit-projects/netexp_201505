using Newtonsoft.Json;

namespace BruPark.WebApi.Models
{
    [JsonObject]
    public class FeedbackResponseRO
    {
        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "success_rate")]
        public int SuccessRate { get; set; }
    }
}
