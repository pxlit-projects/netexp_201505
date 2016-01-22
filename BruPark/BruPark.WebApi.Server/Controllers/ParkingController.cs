using BruPark.Persistence.Entities;
using BruPark.WebApi.Models;
using System.Net;
using System.Web.Http;

namespace BruPark.WebApi.Server.Controllers
{
    [RoutePrefix("parkings/{id:int}")]
    public class ParkingController : AbstractController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetParkingDetails(int id)
        {
            if (!IsValidParkingId(id))
            {
                return Content(HttpStatusCode.BadRequest, ("Invalid parking ID:  " + id));
            }

            ParkingPO parking = db.Parkings.Find(id);

            if (parking == null)
            {
                return Content(HttpStatusCode.NotFound, ("Unknown parking ID:  " + id));
            }

            ParkingRO result = new ParkingRO();

            result.AddressFR = parking.AddressFrench.ToString();
            result.AddressNL = parking.AddressDutch.ToString();
            result.Disabled = parking.Disabled;
            result.Distance = -1;
            result.Duration = -1;
            result.Id = parking.Id;
            result.Spaces = parking.Spaces;
            result.SuccessRate = parking.SuccessRate;

            return Ok(result);
        }

        protected bool IsValidParkingId(int id)
        {
            return (id > 0);
        }

        [HttpPost]
        [Route("feedback")]
        public IHttpActionResult SubmitFeedback(int id, [FromBody] FeedbackRequestRO request)
        {
            FeedbackResponseRO response = new FeedbackResponseRO();

            //  Validate the parking ID

            if (!IsValidParkingId(id))
            {
                response.Error = ("Invalid parking ID:  " + id);

                return Content(HttpStatusCode.BadRequest, response);
            }

            //  Fetch the parking from the database.

            ParkingPO parking = db.Parkings.Find(id);

            if (parking == null)
            {
                response.Error = ("No parking exists with the following ID:  " + id);

                return Content(HttpStatusCode.NotFound, response);
            }

            //  Add the feedback to the parking.

            FeedbackPO feedback = new FeedbackPO();

            feedback.Available = request.Available;

            parking.FeedbackList.Add(feedback);

            //  Commit the transaction.

            db.SaveChanges();

            //  Send the response.

            response.Error = parking.AddressDutch.Street;

            return Ok(response);
        }
    }
}
