using GoogleMaps.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BruPark.Persistence.Entities
{
    [Table("LOCATIONS")]
    public class LocationPO : GeoLocation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Latitude { get; set; }

        [Required]
        public decimal Longitude { get; set; }
    }
}
