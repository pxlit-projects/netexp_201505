using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruPark.OpenData.Models
{
    [JsonObject]
    public class Record
    {
        [JsonProperty(PropertyName = "datasetid")]
        public string DatasetId { get; set; }

        [JsonProperty(PropertyName = "fields")]
        public IDictionary<string, object> Fields { get; set; }

        [JsonProperty(PropertyName = "geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty(PropertyName = "recordid")]
        public string RecordId { get; set; }

        [JsonProperty(PropertyName = "record_timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
