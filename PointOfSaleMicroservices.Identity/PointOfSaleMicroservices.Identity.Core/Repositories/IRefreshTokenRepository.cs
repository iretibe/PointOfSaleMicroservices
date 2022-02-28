using PointOfSaleMicroservices.Identity.Core.Entities;

namespace PointOfSaleMicroservices.Identity.Core.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken> GetAsync(string token);
        Task AddAsync(RefreshToken token);
        Task UpdateAsync(RefreshToken token);
    }
}
