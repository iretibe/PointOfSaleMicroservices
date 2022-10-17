using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Modules.Customers.Core.Exceptions
{
    internal class CannotCompleteCustomerException : PointOfSaleMicroservicesException
    {
        public Guid CustomerId { get; }

        public CannotCompleteCustomerException(Guid customerId) : base($"Customer with ID: '{customerId}' cannot be completed.")
        {
            CustomerId = customerId;
        }
    }
}
