using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruPark.OpenData.Models
{
    [JsonObject]
    public class Parameters
    {
        [JsonProperty(PropertyName = "dataset")]
        public IList<string> Datasets { get; set; }

        [JsonProperty(PropertyName = "format")]
        public string Format { get; set; }

        [JsonProperty(PropertyName = "rows")]
        public int Rows { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }
    }
}
