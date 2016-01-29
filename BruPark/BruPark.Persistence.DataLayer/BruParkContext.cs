using BruPark.Persistence.Entities;
using System.Data.Entity;

namespace BruPark.Persistence.DataLayer
{
    public class BruParkContext : DbContext
    {
        public IDbSet<AddressPO> Addresses { get; set; }

        public IDbSet<CompanyPO> Companies { get; set; }

        public IDbSet<LocationPO> Locations { get; set; }

        public IDbSet<ParkingPO> Parkings { get; set; }



        public BruParkContext() : base("BruPark") {}



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Increase the precision of geo location values
            modelBuilder.Entity<LocationPO>().Property(x => x.Latitude).HasPrecision(11, 8);
            modelBuilder.Entity<LocationPO>().Property(x => x.Longitude).HasPrecision(11, 8);
        }
    }
}
