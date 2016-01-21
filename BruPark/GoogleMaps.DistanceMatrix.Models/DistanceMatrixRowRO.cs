using Newtonsoft.Json;
using System.Collections.Generic;

namespace GoogleMaps.DistanceMatrix.Models
{
    [JsonObject]
    public class DistanceMatrixRowRO
    {
        [JsonProperty(PropertyName = "elements")]
        public IList<DistanceMatrixElementRO> Elements { get; set; }
    }
}
