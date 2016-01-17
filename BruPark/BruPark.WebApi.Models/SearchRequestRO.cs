using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
