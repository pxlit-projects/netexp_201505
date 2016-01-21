using Newtonsoft.Json;

namespace BruPark.WebApi.Models
{
    [JsonObject]
    public class LocationRO
    {
        public LocationRO() {}

        public LocationRO(decimal latitude, decimal longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }



        [JsonProperty(PropertyName = "latitude")]
        public decimal Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public decimal Longitude { get; set; }
    }
}
