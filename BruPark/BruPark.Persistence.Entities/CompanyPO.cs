using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BruPark.Persistence.Entities
{
    [Table("COMPANIES")]
    public class CompanyPO
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(255)]
        [Required]
        public string Name { get; set; }
    }
}
