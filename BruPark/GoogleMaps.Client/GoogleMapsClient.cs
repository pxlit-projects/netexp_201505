using BruPark.Tools.RestClient;
using GoogleMaps.Geocoding.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GoogleMaps.Client
{
    public class GoogleMapsClient
    {
        public const string API_KEY = "AIzaSyAn4GtU5ixCBSiaR1rXQPIEIyvhhD0hDfg";

        private string apiKey;



        public GoogleMapsClient(string apiKey = API_KEY)
        {
            this.apiKey = apiKey;
        }



        public string ApiKey
        {
            get
            {
                return apiKey;
            }
        }

        public GeocodingResponseRO RequestGeocoding(string address)
        {
            string url = String.Format("https://maps.googleapis.com/maps/api/geocode/json?key={0}&region=be&address={1}", ApiKey, HttpUtility.UrlEncode(address));
            Debug.WriteLine("url = " + url);

            return RestClient.Request<GeocodingResponseRO>(url);
        }
    }
}
