namespace BruPark.Jobs.OpenDataImporter.Templates
{
    public class ParkingTemplate
    {
        public string AddressFR { get; set; }

        public string AddressNL { get; set; }

        public string Company { get; set; }

        public bool Disabled { get; set; }

        public decimal[] Location { get; set; }

        public int Spaces { get; set; }

        public string RecordId { get; set; }
    }
}
