using Microsoft.EntityFrameworkCore;
using PointOfSaleMicroservices.Modules.Customers.Core.Domain.Entities;

namespace PointOfSaleMicroservices.Modules.Customers.Core.DAL
{
    internal class CustomersDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomersDbContext(DbContextOptions<CustomersDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Customers");
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
