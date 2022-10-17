using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Modules.Customers.Core.Exceptions
{
    internal class InvalidIdentityException : PointOfSaleMicroservicesException
    {
        public string Type { get; }

        public InvalidIdentityException(string type, string series)
            : base($"Identity type: '{type}', series: '{series}' is invalid.")
        {
            Type = type;
        }
    }
}
