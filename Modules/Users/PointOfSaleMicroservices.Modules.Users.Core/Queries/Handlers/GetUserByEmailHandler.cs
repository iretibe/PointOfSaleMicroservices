using Microsoft.EntityFrameworkCore;
using PointOfSaleMicroservices.Modules.Users.Core.DAL;
using PointOfSaleMicroservices.Modules.Users.Core.DTO;
using PointOfSaleMicroservices.Shared.Abstractions.Queries;

namespace PointOfSaleMicroservices.Modules.Users.Core.Queries.Handlers
{
    internal sealed class GetUserByEmailHandler : IQueryHandler<GetUserByEmail, UserDetailsDto>
    {
        private readonly UsersDbContext _dbContext;

        public GetUserByEmailHandler(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserDetailsDto> HandleAsync(GetUserByEmail query, CancellationToken cancellationToken = default)
        {
            var user = await _dbContext.Users
                .AsNoTracking()
                .Include(x => x.Role)
                .SingleOrDefaultAsync(x => x.Email == query.Email, cancellationToken);

            return user?.AsDetailsDto();
        }
    }
}
