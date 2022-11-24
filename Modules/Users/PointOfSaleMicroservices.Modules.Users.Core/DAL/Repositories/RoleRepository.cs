using Microsoft.EntityFrameworkCore;
using PointOfSaleMicroservices.Modules.Users.Core.Entities;
using PointOfSaleMicroservices.Modules.Users.Core.Repositories;

namespace PointOfSaleMicroservices.Modules.Users.Core.DAL.Repositories
{
    internal class RoleRepository : IRoleRepository
    {
        private readonly UsersDbContext _context;
        private readonly DbSet<Role> _roles;

        public RoleRepository(UsersDbContext context)
        {
            _context = context;
            _roles = context.Roles;
        }

        public async Task AddAsync(Role role)
        {
            await _roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Role>> GetAllAsync() => await _roles.ToListAsync();

        public Task<Role> GetAsync(string name) => _roles.SingleOrDefaultAsync(x => x.Name == name);
    }
}
