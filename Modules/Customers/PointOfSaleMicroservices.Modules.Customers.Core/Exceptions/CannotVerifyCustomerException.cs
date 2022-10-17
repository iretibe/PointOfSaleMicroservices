using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Modules.Customers.Core.Exceptions
{
    internal class CannotVerifyCustomerException : PointOfSaleMicroservicesException
    {
        public Guid CustomerId { get; }

        public CannotVerifyCustomerException(Guid customerId) : base($"Customer with ID: '{customerId}' cannot be verified.")
        {
            CustomerId = customerId;
        }
    }
}
