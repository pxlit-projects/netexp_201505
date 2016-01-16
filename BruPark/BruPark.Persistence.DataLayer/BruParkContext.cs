using BruPark.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruPark.Persistence.DataLayer
{
    public class BruParkContext : DbContext
    {

        public DbSet<Parking> Parkings { get; set; }

    }
}
