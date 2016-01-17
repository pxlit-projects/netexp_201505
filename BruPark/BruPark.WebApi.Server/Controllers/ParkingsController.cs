using BruPark.WebApi.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace BruPark.WebApi.Server.Controllers
{
    [RoutePrefix("parkings")]
    public class ParkingsController : ApiController
    {
        [HttpPost]
        [Route("search")]
        public string SearchParkings([FromBody] SearchRequestRO request)
        {
            return "Hello, world!";
        }

        [HttpPost]
        [Route("{id:int}/feedback")]
        public IHttpActionResult SubmitFeedback(int id)
        {
            return Ok();
        }
    }
}
