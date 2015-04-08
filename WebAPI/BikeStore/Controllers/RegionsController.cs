using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BikeStore.Models;
using Microsoft.Owin.Security;

namespace BikeStore.Controllers
{
    [RoutePrefix("api/regions")]
    public class RegionsController : ApiController
    {
        private BikeContext db { get; set; }

        public RegionsController()
        {
            db = new BikeContext();
        }

        [Authorize]
        [Route("summary")]
        public IHttpActionResult GetSummary()
        {
            // Get all regions
            return Ok(db.Regions.ToList().Select(x => new RegionSalesSummaryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                SalesDirector = x.SalesDirector.FullName,
                GrossSales = x.GrossSales,
                GrossSalesTarget = x.SalesTarget
            }).ToList());

        }

        /// <summary>
        /// Releases managed and unmanaged resources based on parameters
        /// </summary>
        /// <param name="disposing">
        /// True: release managed and unamaged resources,
        /// False: release only unmanaged resources
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of our datastore access context
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}