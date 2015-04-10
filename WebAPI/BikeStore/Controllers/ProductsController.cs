using System.Collections;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web.Http;
using BikeStore.Models;

namespace BikeStore.Controllers
{
    public class ProductsController : ApiController
    {
        private BikeContext db { get; set; }

        public ProductsController()
        {
            db = new BikeContext();
        }

        public IEnumerable<Product> GetAllProducts()
        {
           return db.Products.Take(100).ToList();
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}