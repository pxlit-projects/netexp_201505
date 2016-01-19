using BruPark.Persistence.Entities;
using System.Data.Entity;

namespace BruPark.Persistence.DataLayer
{
    public class BruParkContext : DbContext
    {
        public DbSet<ParkingPO> Parkings { get; set; }
    }
}
