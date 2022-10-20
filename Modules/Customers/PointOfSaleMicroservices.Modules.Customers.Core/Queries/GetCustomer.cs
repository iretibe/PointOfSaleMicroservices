using PointOfSaleMicroservices.Modules.Customers.Core.DTO;
using PointOfSaleMicroservices.Shared.Abstractions.Queries;

namespace PointOfSaleMicroservices.Modules.Customers.Core.Queries
{
    internal class GetCustomer :IQuery<CustomerDetailsDto>
    {
        public Guid CustomerId { get; set; }
    }
}
