using System.ComponentModel.DataAnnotations;

namespace BruPark.Persistence.Entities
{
    public class AddressPO
    {
        [Key]
        public int Id { get; set; }

        public string Street { get; set; }
    }
}
