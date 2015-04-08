using Microsoft.AspNet.Identity.EntityFramework;

namespace BikeStore.Models
{
    public class BikeContext : IdentityDbContext<IdentityUser>
    {
        public BikeContext() : base("BikeContext")
        {
        }
    }
}