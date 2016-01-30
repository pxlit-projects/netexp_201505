
using BruPark.Extensions;
using BruPark.Persistence.Entities;
using BruPark.Tools.RestClient;
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
    public class ParkingsController : AbstractController
    {
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

            Response<DistanceMatrixResponseRO> response = client.RequestDistanceMatrix(origins, destinations);

            if (response.Failure)
            {
                Debug.WriteLine("ERROR:  " + response.Error);
                return null;
            }

            DistanceMatrixResponseRO output = response.Body;

            if ("OK".Equals(output.Status))
            {
                return output.Rows[0].Elements;
            }
            else
            {
                Debug.WriteLine("ERROR:  " + output.ErrorMessage);
                return null;
            }
        }

        /// <summary>
        /// This method uses part of the Haversine formula to calculate an estimated weight for the distance between two geo locations.
        /// </summary>
        /// <see cref="https://en.wikipedia.org/wiki/Haversine_formula"/>
        /// <param name="a">The first geo location</param>
        /// <param name="b">The second geo location</param>
        /// <returns>An estimated weight for the distance between A and B</returns>
        private static double CalculateHaversineWeight(GeoLocation a, GeoLocation b)
        {
            double lat0 = a.Latitude.DegreesToRadians();
            double lng0 = a.Longitude.DegreesToRadians();

            double lat1 = b.Latitude.DegreesToRadians();
            double lng1 = b.Longitude.DegreesToRadians();

            double sinLat = Math.Sin((lat1 - lat0) / 2D);
            double sinLng = Math.Sin((lng1 - lng0) / 2D);

            return Math.Asin(Math.Sqrt((sinLat * sinLat) + (Math.Cos(lng0) * Math.Cos(lng1) * sinLng * sinLng)));
        }
        
        private static GeoLocation Locate(AddressRO address)
        {
            GoogleMapsClient client = new GoogleMapsClient();

            Response<GeocodingResponseRO> response = client.RequestGeocoding(address.ToString());

            if (response.Failure)
            {
                Debug.WriteLine("ERROR:  " + response.Error);
                return null;
            }

            GeocodingResponseRO output = response.Body;

            if (!"OK".Equals(output.Status))
            {
                return null;
            }

            IList<ResultRO> results = output.Results;

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

            //  Fetch the parkings that match the search criteria from the database.

            IList<ParkingPO> parkings = (from p in db.Parkings where p.Disabled == request.Disabled select p).ToList();

            if (parkings.Count <= 0)
            {
                response.Error = "No parking spaces found with the specified parameters";

                return Content(HttpStatusCode.NotFound, response);
            }

            //  Translate the current address to a geo location.

            GeoLocation location = Locate(request.Address);

            if (location == null)
            {
                response.Error = "Failed to locate the address";

                return Content(HttpStatusCode.InternalServerError, response);
            }
            
            //  Sort the matched parkings by estimated distance (ascending) and select only the first 30.
            //  The number of parkings should be limited to avoid abusing the Google Maps API in the next step.

            parkings = SortByDistance(parkings, location).Limit(30);
            
            //  Request the distance matrix from the Google Maps API.

            IList<DistanceMatrixElementRO> matrix = CalculateDistanceMatrix(location, parkings);

            if (matrix == null)
            {
                response.Error = "Failed to calculate the distance matrix";

                return Content(HttpStatusCode.InternalServerError, response);
            }

            //  Combine the stored data with the distance matrix to generate the list of potential results.

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

            //  Sort the results by travel duration (ascending) and select only the first 20.
            
            results = SortByDuration(results).Limit(20);
            
            //  Send the response.

            response.Results = results;

            return Ok(response);
        }

        private static List<ParkingPO> SortByDistance(IList<ParkingPO> parkings, GeoLocation location)
        {
            return parkings.OrderBy(parking => CalculateHaversineWeight(location, parking.Location)).ToList();
        }

        private static List<ParkingRO> SortByDuration(IList<ParkingRO> parkings)
        {
            return parkings.OrderBy(parking => parking.Duration).ToList();
        }
    }
}
