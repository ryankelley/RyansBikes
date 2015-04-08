using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BikeStore.Models
{
    public class BikeContext : IdentityDbContext<IdentityUser>
    {
        public BikeContext() : base("BikeContext")
        {
        }

        /// <summary>
        /// Geographical regions for sales tracking purposes
        /// </summary>
        public virtual DbSet<Region> Regions { get; set; }
        /// <summary>
        /// Corporate employees
        /// </summary>
        public virtual DbSet<Employee> Employees { get; set; }
        /// <summary>
        /// Sales tracked at a regional level
        /// </summary>
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // allow the base we are overriding to work
            base.OnModelCreating(modelBuilder);

            // Each region has 0-many sales but each sale MUST have a region
            // If region is deleted it will cascade delete sales
            modelBuilder.Entity<Region>()
                .HasMany<Sale>(r => r.Sales)
                .WithRequired(s => s.Region)
                .WillCascadeOnDelete(true);

            // Each employee belongs to a region but regions are unaware of dependent employees
            modelBuilder.Entity<Employee>()
                .HasRequired(e => e.Region)
                .WithMany()
                .HasForeignKey(r => r.RegionId)
                .WillCascadeOnDelete(false);

        }
    }
}