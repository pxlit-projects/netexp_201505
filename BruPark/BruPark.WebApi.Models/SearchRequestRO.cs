using Newtonsoft.Json;

namespace BruPark.WebApi.Models
{
    [JsonObject]
    public class SearchRequestRO
    {
        [JsonProperty(PropertyName = "address")]
        public AddressRO Address { get; set; }
        
        [JsonProperty(PropertyName = "disabled")]
        public bool Disabled { get; set; }
    }
}
