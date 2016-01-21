using BruPark.Tools.RestClient;
using GoogleMaps.Commons;
using GoogleMaps.DistanceMatrix.Models;
using GoogleMaps.Geocoding.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
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

        private string CreateUrl(string api, IDictionary<string, string> parameters = null)
        {
            StringBuilder url = new StringBuilder(256).AppendFormat("https://maps.googleapis.com/maps/api/{0}/json?", api);

            bool separator = false;

            if (parameters != null)
            {
                foreach (string key in parameters.Keys)
                {
                    if (!"key".Equals(key))
                    {
                        string value = parameters[key];
                        
                        if (separator)
                        {
                            url.Append('&');
                        }
                        else
                        {
                            separator = true;
                        }

                        url.Append(key).Append('=').Append(value);
                    }
                }
            }

            if (separator)
            {
                url.Append('&');
            }

            url.Append("key=").Append(HttpUtility.UrlEncode(ApiKey, Encoding.UTF8));
            
            return url.ToString();
        }
        
        private static string FormatLocations(IList<GeoLocation> locations)
        {
            CultureInfo locale = CultureInfo.GetCultureInfo("en-GB");

            StringBuilder result = new StringBuilder(256);

            bool first = true;

            foreach (GeoLocation location in locations)
            {
                if (first)
                {
                    first = false;
                }
                else
                {
                    result.Append('|');
                }

                result.Append(location.Latitude.ToString(locale)).Append(',').Append(location.Longitude.ToString(locale));
            }

            return result.ToString();
        }

        public DistanceMatrixResponseRO RequestDistanceMatrix(IList<GeoLocation> origins, IList<GeoLocation> destinations, string mode = "driving")
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>(3);

            parameters.Add("destinations", FormatLocations(destinations));
            parameters.Add("mode", HttpUtility.UrlEncode(mode, Encoding.UTF8));
            parameters.Add("origins", FormatLocations(origins));

            string url = CreateUrl("distancematrix", parameters);
            Debug.WriteLine("url = " + url);

            return RestClient.Request<DistanceMatrixResponseRO>(url);
        }

        public GeocodingResponseRO RequestGeocoding(string address)
        {
            IDictionary<string, string> parameters = new Dictionary<string, string>(2);
            parameters.Add("address", HttpUtility.UrlEncode(address, Encoding.UTF8));
            parameters.Add("region", "be");

            string url = CreateUrl("geocode", parameters);
            Debug.WriteLine("url = " + url);

            return RestClient.Request<GeocodingResponseRO>(url);
        }
    }
}
