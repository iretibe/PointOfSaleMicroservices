using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Modules.Customers.Core.Exceptions
{
    internal class CustomerNotActiveException : PointOfSaleMicroservicesException
    {
        public Guid CustomerId { get; }

        public CustomerNotActiveException(Guid customerId) : base($"Customer with ID: '{customerId}' is not active.")
        {
            CustomerId = customerId;
        }
    }
}
