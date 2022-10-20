using Microsoft.EntityFrameworkCore;
using PointOfSaleMicroservices.Modules.Customers.Core.Domain.Entities;
using PointOfSaleMicroservices.Modules.Customers.Core.Domain.Repositories;

namespace PointOfSaleMicroservices.Modules.Customers.Core.DAL.Repositories
{
    internal class CustomersRepository : ICustomerRepository
    {
        private readonly CustomersDbContext _context;
        private readonly DbSet<Customer> _customers;

        public CustomersRepository(CustomersDbContext context)
        {
            _context = context;
            _customers = context.Customers;
        }

        public async Task AddAsync(Customer customer)
        {
            await _customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public Task<bool> ExistsAsync(string name) => _customers.AnyAsync(x => x.Name == name);

        public Task<Customer> GetAsync(Guid id) => _customers.SingleOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(Customer customer)
        {
            _customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
