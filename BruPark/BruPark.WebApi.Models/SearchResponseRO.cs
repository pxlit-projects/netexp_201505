using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruPark.WebApi.Models
{
    [JsonObject]
    public class SearchResponseRO
    {
        [JsonProperty(PropertyName = "error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "results")]
        public IList<object> Results { get; set; }
    }
}
