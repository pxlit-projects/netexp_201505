using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruPark.Persistence.Entities
{
    public class Feedback
    {

        public bool Available { get; set; }

        public virtual Parking Parking { get; set; }

        public int ParkingId { get; set; }

    }
}
