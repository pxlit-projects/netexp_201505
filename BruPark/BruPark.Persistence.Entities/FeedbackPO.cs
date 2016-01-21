using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BruPark.Persistence.Entities
{
    [Table("FEEDBACKS")]
    public class FeedbackPO
    {
        public bool Available { get; set; }

        [Key]
        public int Id { get; set; }

        [ForeignKey("ParkingId")]
        [Required]
        public virtual ParkingPO Parking { get; set; }

        public int ParkingId { get; set; }
    }
}
