using BruPark.Persistence.DataLayer;
using System.Web.Http;

namespace BruPark.WebApi.Server.Controllers
{
    public abstract class AbstractController : ApiController
    {
        protected BruParkContext db = new BruParkContext();



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
    }
}
