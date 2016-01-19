using System.ComponentModel.DataAnnotations;

namespace BruPark.Persistence.Entities
{
    public class FeedbackPO
    {
        public bool Available { get; set; }

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual ParkingPO Parking { get; set; }

        public int ParkingId { get; set; }
    }
}
