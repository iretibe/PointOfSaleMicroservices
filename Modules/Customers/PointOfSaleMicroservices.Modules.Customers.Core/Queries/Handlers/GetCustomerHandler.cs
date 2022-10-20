using Microsoft.EntityFrameworkCore;
using PointOfSaleMicroservices.Modules.Customers.Core.DAL;
using PointOfSaleMicroservices.Modules.Customers.Core.DTO;
using PointOfSaleMicroservices.Shared.Abstractions.Queries;

namespace PointOfSaleMicroservices.Modules.Customers.Core.Queries.Handlers
{
    internal sealed class GetCustomerHandler : IQueryHandler<GetCustomer, CustomerDetailsDto>
    {
        private readonly CustomersDbContext _context;

        public GetCustomerHandler(CustomersDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerDetailsDto> HandleAsync(GetCustomer query, CancellationToken cancellationToken = default)
        {
            var customer = await _context.Customers
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == query.CustomerId, cancellationToken);

            return customer?.AsDetailsDto();
        }
    }
}
