using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PointOfSaleMicroservices.Modules.Users.Core.DAL
{
    internal class ApplicationDbContextFactory : IDesignTimeDbContextFactory<UsersDbContext>
    {
        public UsersDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UsersDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-BMD4TBB\\SQL2019;Database=PointOfSale;User ID=sa;Password=YEso!@12;Trusted_Connection=False;MultipleActiveResultSets=True;TrustServerCertificate=True");

            return new UsersDbContext(optionsBuilder.Options);
        }
    }
}
