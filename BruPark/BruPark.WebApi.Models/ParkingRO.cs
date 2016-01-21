using Newtonsoft.Json;

namespace BruPark.WebApi.Models
{
    [JsonObject]
    public class ParkingRO
    {
        [JsonProperty(PropertyName = "address_fr")]
        public string AddressFR { get; set; }

        [JsonProperty(PropertyName = "address_nl")]
        public string AddressNL { get; set; }

        [JsonProperty(PropertyName = "disabled")]
        public bool Disabled { get; set; }

        [JsonProperty(PropertyName = "distance")]
        public long Distance { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public long Duration { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "spaces")]
        public int Spaces { get; set; }

        [JsonProperty(PropertyName = "success_rate")]
        public int SuccessRate { get; set; }
    }
}
