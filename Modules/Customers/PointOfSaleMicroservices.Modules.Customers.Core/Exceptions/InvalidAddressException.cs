using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Modules.Customers.Core.Exceptions
{
    internal class InvalidAddressException : PointOfSaleMicroservicesException
    {
        public string Address { get; }

        public InvalidAddressException(string address) : base($"Address: '{address}' is invalid.")
        {
            Address = address;
        }
    }
}
