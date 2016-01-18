using Newtonsoft.Json;
using System;

namespace BruPark.WebApi.Models
{
    [JsonObject]
    public class AddressRO
    {
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }
        
        public override string ToString()
        {
            string secondary = null;

            if (!String.IsNullOrWhiteSpace(PostalCode))
            {
                secondary = PostalCode;
            }

            if (!String.IsNullOrWhiteSpace(City))
            {
                if (secondary == null)
                {
                    secondary = City;
                }
                else
                {
                    secondary = (secondary + ' ' + City);
                }
            }

            if (String.IsNullOrWhiteSpace(secondary))
            {
                return Street;
            }
            else
            {
                return (Street + ", " + secondary);
            }
        }
    }
}
