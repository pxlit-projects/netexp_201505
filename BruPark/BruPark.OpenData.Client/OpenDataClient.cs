using BruPark.OpenData.Models;
using BruPark.Tools.RestClient;

namespace BruPark.OpenData.Client
{
    public class OpenDataClient
    {
        public const string HOSTNAME = "opendata.brussel.be";



        public SearchResult SearchParkings()
        {
            return RestClient.Request<SearchResult>("http://opendata.brussel.be/api/records/1.0/search/?dataset=public-parkings");
        }
    }
}
