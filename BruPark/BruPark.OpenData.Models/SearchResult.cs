using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruPark.OpenData.Models
{
    [JsonObject]
    public class SearchResult
    {
        [JsonProperty(PropertyName = "nhits")]
        public int Hits { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        public Parameters Parameters { get; set; }

        [JsonProperty(PropertyName = "records")]
        public IList<Record> Records { get; set; }
    }
}
