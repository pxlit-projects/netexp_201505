using System.ComponentModel.DataAnnotations;

namespace BruPark.Persistence.Entities
{
    public class CompanyPO
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
