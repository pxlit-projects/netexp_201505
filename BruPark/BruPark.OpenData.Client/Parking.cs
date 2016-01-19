using BruPark.OpenData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruPark.OpenData.Client
{
    public class Parking
    {
        public string AddressFR { get; set; }

        public string AddressNL { get; set; }

        public string Company { get; set; }

        public bool Disabled { get; set; }

        public Geometry Geometry { get; set; }

        public int Places { get; set; }

        public string RecordId { get; set; }
    }
}
