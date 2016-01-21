namespace BruPark.Jobs.OpenDataImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            using (OpenDataImporter importer = new OpenDataImporter())
            {
                importer.Import();
            }
        }
    }
}
