using Newtonsoft.Json;
using System.Collections.Generic;

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
