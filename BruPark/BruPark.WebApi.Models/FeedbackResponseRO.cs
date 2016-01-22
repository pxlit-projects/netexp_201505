using Newtonsoft.Json;

namespace BruPark.WebApi.Models
{
    [JsonObject]
    public class FeedbackResponseRO
    {
        [JsonProperty(PropertyName = "error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }
    }
}
