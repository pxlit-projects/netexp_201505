using BruPark.OpenData.Client;
using BruPark.Persistence.DataLayer;
using BruPark.WebApi.Models;
using GoogleMaps.Client;
using GoogleMaps.Geocoding.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace BruPark.WebApi.Server.Controllers
{
    [RoutePrefix("parkings")]
    public class ParkingsController : ApiController
    {
        private static GeoLocationRO Locate(AddressRO address)
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

        private static IList<Parking> Search(SearchRequestRO request)
        {
            if (request.Disabled)
            {
                return OpenDataClient.SearchParkingsDisabled();
            }
            else
            {
                return OpenDataClient.SearchParkingsPublic();
            }
        }

        [HttpPost]
        [Route("search")]
        public IHttpActionResult SearchParkings([FromBody] SearchRequestRO request)
        {
            SearchResponseRO response = new SearchResponseRO();

            GeoLocationRO location = Locate(request.Address);

            if (location == null)
            {
                return NotFound();
            }

            IList<Parking> search = Search(request);

            if (search == null)
            {
                return NotFound();
            }

            IList<ParkingRO> results = Translate(search);

            response.Results = results;

            return Ok<SearchResponseRO>(response);
        }

        [HttpPost]
        [Route("{id:int}/feedback")]
        public IHttpActionResult SubmitFeedback(int id)
        {
            return Ok();
        }

        private static IList<ParkingRO> Translate(IList<Parking> inputs)
        {
            IList<ParkingRO> outputs = new List<ParkingRO>(inputs.Count);

            using (BruParkContext db = new BruParkContext())
            {
                foreach (Parking input in inputs)
                {
                    // TODO:  Interaction with database
                    

                    ParkingRO output = new ParkingRO();

                    output.AddressFR = input.AddressFR;
                    output.AddressNL = input.AddressNL;
                    output.Disabled = input.Disabled;
                    output.Id = 12345;
                    output.Places = input.Places;

                    outputs.Add(output);
                }
            }
            
            return outputs;
        }
    }
}
