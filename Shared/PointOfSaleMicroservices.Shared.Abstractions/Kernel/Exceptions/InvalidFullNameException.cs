using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Shared.Abstractions.Kernel.Exceptions
{
    public class InvalidFullNameException : PointOfSaleMicroservicesException
    {
        public string FullName { get; }

        public InvalidFullNameException(string fullName) : base($"Full name: '{fullName}' is invalid.")
        {
            FullName = fullName;
        }
    }
}
