using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Modules.Customers.Core.Exceptions
{
    internal class InvalidCustomerNameException : PointOfSaleMicroservicesException
    {
        public Guid CustomerId { get; }

        public InvalidCustomerNameException(Guid customerId) : base($"Customer with ID: '{customerId}' has invalid name.")
        {
            CustomerId = customerId;
        }
    }
}
