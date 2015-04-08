using System.Collections.Generic;
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

        /// <summary>
        /// Add some default sales data to the databse
        /// </summary>
        /// <param name="context">A datastore access context</param>
        private void AddSales(BikeContext context)
        {
            // Grab some default regions
            Region northAmerica = context.Regions.Single(r => r.Name == "North America");
            Region europe = context.Regions.Single(r => r.Name == "Europe");
            // Create some default sales (amounts need to be unique)
            List<Sale> sales = new List<Sale> {
                new Sale {
                    RegionId = northAmerica.Id,
                    Amount = 500m
                },
                new Sale {
                    RegionId = northAmerica.Id,
                    Amount = 200.58m
                },
                new Sale {
                    RegionId = northAmerica.Id,
                    Amount = 300.75m
                },
                new Sale {
                    RegionId = northAmerica.Id,
                    Amount = 1300.45m
                },
                new Sale {
                    RegionId = northAmerica.Id,
                    Amount = 5000.75m
                },
                new Sale {
                    RegionId = northAmerica.Id,
                    Amount = 800.46m
                },
                new Sale {
                    RegionId = northAmerica.Id,
                    Amount = 400.10m
                },
                new Sale {
                    RegionId = northAmerica.Id,
                    Amount = 1070.67m
                },
                new Sale {
                    RegionId = northAmerica.Id,
                    Amount = 657.25m
                },
                new Sale {
                    RegionId = northAmerica.Id,
                    Amount = 142.25m
                },
                new Sale {
                    RegionId = europe.Id,
                    Amount = 1000.46m
                },
                new Sale {
                    RegionId = europe.Id,
                    Amount = 102.15m
                },
                new Sale {
                    RegionId = europe.Id,
                    Amount = 500.46m
                },
                new Sale {
                    RegionId = europe.Id,
                    Amount = 400.00m
                },
                new Sale {
                    RegionId = europe.Id,
                    Amount = 360.00m
                },
                new Sale {
                    RegionId = europe.Id,
                    Amount = 780.00m
                },
                new Sale {
                    RegionId = europe.Id,
                    Amount = 605.67m
                },
                new Sale {
                    RegionId = europe.Id,
                    Amount = 455.42m
                }
            };
            // Add the sales to the database (unless the amount exists)
            sales.ForEach(sale => context.Sales.AddOrUpdate(s => s.Amount, sale));
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

            // Define some default regions
            List<Region> regions = new List<Region> {
                new Region {
                    Name = "North America",
                    SalesTarget = 9000m
                },
                new Region
                {
                    Name = "Europe",
                    SalesTarget = 6000m
                }
            };
            // Add them to the context, unless they already exist
            regions.ForEach(region => context.Regions.AddOrUpdate(r => r.Name, region));
            // Then save them to the database
            context.SaveChanges();
            // Now grab the database versions
            Region northAmerica = context.Regions.Single(r => r.Name == "North America");
            Region europe = context.Regions.Single(r => r.Name == "Europe");
            // Define some default employees
            List<Employee> employees = new List<Employee> {
                new Employee
                {
                    FirstName = "Sarah",
                    LastName = "Doe",
                    RegionId = northAmerica.Id
                },
                new Employee
                {
                    FirstName = "John Q.",
                    LastName = "Public",
                    RegionId = europe.Id
                }
            };
            // Add them to the context, unless they already exist
            employees.ForEach(employee => context.Employees.AddOrUpdate(e => e.LastName, employee));
            // Then save them to the database
            context.SaveChanges();
            // Now grab the database versions
            Employee sarahDoe = context.Employees.Single(e => e.FirstName == "Sarah" && e.LastName == "Doe");
            Employee johnPublic = context.Employees.Single(e => e.FirstName == "John Q." && e.LastName == "Public");
            // And make them sales directors
            northAmerica.SalesDirector = sarahDoe;
            europe.SalesDirector = johnPublic;
            // Save their "promotions" to the database
            context.SaveChanges();
            // if there aren't any sales in the database currently, add some
            if (context.Sales.Count() == 0)
            {
                AddSales(context);
            }
            // save any sales that were added
            context.SaveChanges();
        }
    }
}
