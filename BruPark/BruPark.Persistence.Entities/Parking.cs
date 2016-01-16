using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruPark.Persistence.Entities
{
    public class Parking
    {

        public virtual Address Address { get; set; }

        public int AddressId { get; set; }

        public virtual Company Company { get; set; }

        public int CompanyId { get; set; }

        public virtual Location Location { get; set; }

        public int LocationId { get; set; }
        
        public string RecordId { get; set; }

        public int Spaces { get; set; }

    }
}
