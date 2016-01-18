using Newtonsoft.Json;
using System.Runtime.Serialization;

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

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "places")]
        public int Places { get; set; }
    }
}
