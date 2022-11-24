using Microsoft.EntityFrameworkCore;
using PointOfSaleMicroservices.Modules.Users.Core.Entities;
using PointOfSaleMicroservices.Modules.Users.Core.Repositories;

namespace PointOfSaleMicroservices.Modules.Users.Core.DAL.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly UsersDbContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(UsersDbContext context)
        {
            _context = context;
            _users = _context.Users;
        }

        public async Task AddAsync(User user)
        {
            await _users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public Task<User> GetAsync(Guid id)
            => _users.Include(x => x.Role).SingleOrDefaultAsync(x => x.Id == id);

        public Task<User> GetAsync(string email)
            => _users.Include(x => x.Role).SingleOrDefaultAsync(x => x.Email == email);

        public async Task UpdateAsync(User user)
        {
            _users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
