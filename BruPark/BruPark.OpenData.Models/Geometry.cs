using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruPark.OpenData.Models
{
    [JsonObject]
    public class Geometry
    {
        [JsonProperty(PropertyName = "coordinates")]
        public decimal[] Coordinates { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
