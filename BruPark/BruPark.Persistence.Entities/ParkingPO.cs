using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BruPark.Persistence.Entities
{
    [Table("PARKINGS")]
    public class ParkingPO
    {
        [ForeignKey("AddressDutchId")]
        public virtual AddressPO AddressDutch { get; set; }

        public int? AddressDutchId { get; set; }
        
        [ForeignKey("AddressFrenchId")]
        public virtual AddressPO AddressFrench { get; set; }

        public int? AddressFrenchId { get; set; }

        [ForeignKey("CompanyId")]
        public virtual CompanyPO Company { get; set; }

        public int? CompanyId { get; set; }

        [Required]
        public bool Disabled { get; set; }

        public virtual IList<FeedbackPO> FeedbackList { get; set; }

        [Key]
        public int Id { get; set; }

        [ForeignKey("LocationId")]
        [Required]
        public virtual LocationPO Location { get; set; }

        public int LocationId { get; set; }
        
        [Index(IsUnique = true)] // Indexed for faster lookup
        [MaxLength(255)]
        [Required]
        public string RecordId { get; set; }

        public int Spaces { get; set; }

        [NotMapped]
        public int SuccessRate {
            get
            {
                IList<FeedbackPO> feedbacks = FeedbackList;

                if (feedbacks.Count <= 0)
                {
                    return -1;
                }

                int count = 0;

                foreach (FeedbackPO feedback in feedbacks)
                {
                    if (feedback.Available)
                    {
                        count++;
                    }
                }

                return (100 * count / feedbacks.Count);
            }
        }
    }
}
