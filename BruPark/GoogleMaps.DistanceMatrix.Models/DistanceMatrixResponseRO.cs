using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoogleMaps.DistanceMatrix.Models
{
    [JsonObject]
    public class DistanceMatrixResponseRO
    {
        [JsonProperty(PropertyName = "destination_addresses")]
        public IList<string> DestinationAddresses { get; set; }

        [JsonProperty(PropertyName = "error_message")]
        public string ErrorMessage { get; set; }

        [JsonProperty(PropertyName = "origin_addresses")]
        public IList<string> OriginAddresses { get; set; }

        [JsonProperty(PropertyName = "rows")]
        public IList<DistanceMatrixRowRO> Rows { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}
