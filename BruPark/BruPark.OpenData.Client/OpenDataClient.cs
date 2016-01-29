using BruPark.OpenData.Models;
using BruPark.Tools.RestClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace BruPark.OpenData.Client
{
    public class OpenDataClient
    {
        public const string DATASET_DISABLED = "parking-spaces-for-disabled";

        public const string DATASET_PUBLIC = "public-parkings";

        public const string HOSTNAME = "opendata.brussel.be";



        private static object GetField(IDictionary<string, object> map, string key, object defaultValue)
        {
            if (map.ContainsKey(key))
            {
                return map[key];
            } else
            {
                return defaultValue;
            }
        }

        private static IList<Parking> SearchParkings(bool disabled, Range range = null)
        {
            string url = "http://opendata.brussel.be/api/records/1.0/search/?dataset=";

            url += (disabled ? DATASET_DISABLED : DATASET_PUBLIC);

            if (range != null)
            {
                url += string.Format("&geofilter.distance={0},{1},{2}", range.Latitude, range.Longitude, range.Distance);
            }

            SearchResult search;

            try {
                search = RestClient.Get<SearchResult>(url);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }

            if (search.Hits < 1)
            {
                return null;
            }

            IList<Record> records = search.Records;

            if ((records == null) || (records.Count < 1))
            {
                return null;
            }

            IList<Parking> parkings = new List<Parking>();

            foreach (Record record in records)
            {
                Parking parking = new Parking();

                IDictionary<string, object> fields = record.Fields;

                if (disabled)
                {
                    parking.AddressFR = Convert.ToString(GetField(fields, "adresse", "???"));
                    parking.AddressNL = Convert.ToString(GetField(fields, "adres", "???"));
                    parking.Company = "N/A";
                    parking.Places = Convert.ToInt32(GetField(fields, "nombre_d_emplacements", -1));
                }
                else
                {
                    parking.AddressFR = Convert.ToString(GetField(fields, "description", "???"));
                    parking.AddressNL = Convert.ToString(GetField(fields, "beschrinving", "???"));
                    parking.Company = Convert.ToString(GetField(fields, "societe_gestionnaire", "???"));
                    parking.Places = Convert.ToInt32(GetField(fields, "nombre_de_places", -1));
                }

                parking.Disabled = disabled;
                parking.Geometry = record.Geometry;
                parking.RecordId = record.RecordId;

                parkings.Add(parking);
            }

            if (parkings.Count > 0)
            {
                return parkings;
            }
            else
            {
                return null;
            }
        }

        public static IList<Parking> SearchParkingsDisabled(Range range = null)
        {
            return SearchParkings(true, range);
        }

        public static IList<Parking> SearchParkingsPublic(Range range = null)
        {
            return SearchParkings(false, range);
        }
    }
}
