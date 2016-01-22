using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BruPark.Persistence.Entities
{
    [Table("ADDRESSES")]
    public class AddressPO
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = false)]
        [MaxLength(255)]
        [Required]
        public string Street { get; set; }



        public override string ToString()
        {
            return Street;
        }
    }
}
