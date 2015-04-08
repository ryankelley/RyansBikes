using System.Diagnostics.Eventing.Reader;
using BikeStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BikeStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BikeStore.Models.BikeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private bool AddUser(BikeContext context)
        {
            IdentityResult identityResult;
            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            var user = new IdentityUser() {UserName = "admin"};
            if (userManager.FindByName(user.UserName) != null)
                return true;

            identityResult = userManager.Create(user, "password");
            return identityResult.Succeeded;
        }

        protected override void Seed(BikeStore.Models.BikeContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            AddUser(context);
        }
    }
}
