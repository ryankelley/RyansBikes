using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BikeStore.Models;

namespace BikeStore.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
        {
            new Product() { Id = 1, Name = "Trek Superfly", Category = "Mountain Bike", Price=3000},
            new Product() { Id = 2, Name = "Trek Marlin", Category = "Mountain Bike", Price=700},
            new Product() { Id = 3, Name = "Yeti SB95C", Category = "Mountain Bike", Price=5000}
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}