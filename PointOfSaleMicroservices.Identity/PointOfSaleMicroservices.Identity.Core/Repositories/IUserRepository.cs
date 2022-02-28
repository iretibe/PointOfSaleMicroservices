using PointOfSaleMicroservices.Identity.Core.Models;

namespace PointOfSaleMicroservices.Identity.Core.Repositories
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetAsync(Guid id);
        Task<ApplicationUser> GetAsync(string email);
        Task AddAsync(ApplicationUser user);
    }
}
