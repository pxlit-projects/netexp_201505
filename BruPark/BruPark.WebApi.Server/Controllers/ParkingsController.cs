using BruPark.OpenData.Client;
using BruPark.Persistence.DataLayer;
using BruPark.Persistence.Entities;
using BruPark.WebApi.Models;
using GoogleMaps.Client;
using GoogleMaps.Commons;
using GoogleMaps.DistanceMatrix.Models;
using GoogleMaps.Geocoding.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace BruPark.WebApi.Server.Controllers
{
    [RoutePrefix("parkings")]
    public class ParkingsController : ApiController
    {
        private const double D2R = (Math.PI / 180D);

        private BruParkContext db = new BruParkContext();



        private static IList<DistanceMatrixElementRO> CalculateDistanceMatrix(GeoLocation location, IList<ParkingPO> parkings)
        {
            GoogleMapsClient client = new GoogleMapsClient();

            IList<GeoLocation> origins = new List<GeoLocation>(1);
            origins.Add(location);

            IList<GeoLocation> destinations = new List<GeoLocation>(parkings.Count);

            foreach (ParkingPO parking in parkings)
            {
                destinations.Add(parking.Location);
            }

            DistanceMatrixResponseRO response = client.RequestDistanceMatrix(origins, destinations);

            if ("OK".Equals(response.Status))
            {
                return response.Rows[0].Elements;
            }
            else
            {
                Debug.WriteLine("ERROR:  " + response.ErrorMessage);
                return null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private static GeoLocation Locate(AddressRO address)
        {
            GoogleMapsClient client = new GoogleMapsClient();

            GeocodingResponseRO response = client.RequestGeocoding(address.ToString());

            if (!"OK".Equals(response.Status))
            {
                return null;
            }

            IList<ResultRO> results = response.Results;

            if ((results == null) || (results.Count < 1))
            {
                return null;
            }

            return results[0].Geometry.Location;
        }

        [HttpPost]
        [Route("search")]
        public IHttpActionResult SearchParkings([FromBody] SearchRequestRO request)
        {
            SearchResponseRO response = new SearchResponseRO();

            IList<ParkingPO> parkings = (from p in db.Parkings where p.Disabled == request.Disabled select p).ToList();

            if (parkings.Count <= 0)
            {
                response.Error = "No parking spaces found with the specified parameters";

                return Content(HttpStatusCode.NotFound, response);
            }

            GeoLocation location = Locate(request.Address);

            if (location == null)
            {
                response.Error = "Failed to locate the address";

                return Content(HttpStatusCode.InternalServerError, response);
            }

            double lat0 = (D2R * (double)location.Latitude);
            double lng0 = (D2R * (double)location.Longitude);

            //  Do a rough sorting, by an estimated distance based on the GPS coordinates. (see https://en.wikipedia.org/wiki/Haversine_formula)
            //  Select only a few of the closest results.
            parkings = parkings.OrderBy(park =>
            {
                GeoLocation loc = park.Location;

                double lat1 = (D2R * (double)loc.Latitude);
                double lng1 = (D2R * (double)loc.Longitude);

                double sinLat = Math.Sin((lat1 - lat0) / 2D);
                double sinLng = Math.Sin((lng1 - lng0) / 2D);

                return Math.Asin(Math.Sqrt((sinLat * sinLat) + (Math.Cos(lng0) * Math.Cos(lng1) * sinLng * sinLng)));
            }).ToList().GetRange(0, Math.Min(parkings.Count, 30));
            
            IList<DistanceMatrixElementRO> matrix = CalculateDistanceMatrix(location, parkings);

            if (matrix == null)
            {
                response.Error = "Failed to calculate the distance matrix";

                return Content(HttpStatusCode.InternalServerError, response);
            }

            IList<ParkingRO> results = new List<ParkingRO>(parkings.Count);

            for (int i = 0; i < parkings.Count; i++)
            {
                DistanceMatrixElementRO data = matrix[i];
                ParkingPO parking = parkings[i];

                ParkingRO result = new ParkingRO();

                result.AddressFR = parking.AddressFrench.Street;
                result.AddressNL = parking.AddressDutch.Street;
                result.Disabled = parking.Disabled;
                result.Distance = data.Distance.Value;
                result.Duration = data.Duration.Value;
                result.Id = parking.Id;
                result.Spaces = parking.Spaces;
                result.SuccessRate = parking.SuccessRate;

                results.Add(result);
            }
            
            // Sort the remaining results by travel duration (ascending) and take (at most) the first 20 elements.
            results = results.OrderBy(x => x.Duration).ToList().GetRange(0, Math.Min(results.Count, 20));
            
            response.Results = results;

            return Ok<SearchResponseRO>(response);
        }

        [HttpPost]
        [Route("{id:int}/feedback")]
        public IHttpActionResult SubmitFeedback(int id)
        {
            Debug.WriteLine("Parking ID = " + id);

            return Ok();
        }
    }
}
