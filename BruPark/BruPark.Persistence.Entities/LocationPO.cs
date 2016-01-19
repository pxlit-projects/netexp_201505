using System.ComponentModel.DataAnnotations;

namespace BruPark.Persistence.Entities
{
    public class LocationPO
    {
        [Key]
        public int Id { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }
    }
}
