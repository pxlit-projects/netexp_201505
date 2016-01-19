using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BruPark.Persistence.Entities
{
    public class ParkingPO
    {
        [Required]
        public virtual AddressPO AddressDutch { get; set; }

        public int AddressDutchId { get; set; }

        [Required]
        public virtual AddressPO AddressFrench { get; set; }

        public int AddressFrenchId { get; set; }

        public virtual CompanyPO Company { get; set; }

        public int CompanyId { get; set; }

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual LocationPO Location { get; set; }

        public int LocationId { get; set; }
        
        [Index] // Index for faster lookup
        [Required]
        public string RecordId { get; set; }

        public int Spaces { get; set; }
    }
}
