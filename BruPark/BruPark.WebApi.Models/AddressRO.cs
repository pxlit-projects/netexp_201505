using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruPark.WebApi.Models
{
    [JsonObject]
    public class AddressRO
    {
        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }
    }
}
