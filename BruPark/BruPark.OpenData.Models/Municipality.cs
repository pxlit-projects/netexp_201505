namespace BruPark.OpenData.Models
{
    public class Municipality
    {
        public string Name { get; set; }

        public int PostalCode { get; set; }



        public override string ToString()
        {
            return (PostalCode + "    " + Name);
        }
    }
}
