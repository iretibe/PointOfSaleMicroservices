using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Modules.Customers.Core.Exceptions
{
    internal class InvalidNameException : PointOfSaleMicroservicesException
    {
        public string Name { get; }

        public InvalidNameException(string name) : base($"Name: '{name}' is invalid.")
        {
            Name = name;
        }
    }
}
