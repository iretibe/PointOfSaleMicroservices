using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Shared.Abstractions.Kernel.Exceptions
{
    public class InvalidEmailException : PointOfSaleMicroservicesException
    {
        public string Email { get; }

        public InvalidEmailException(string email) : base($"Email: '{email}' is invalid.")
        {
            Email = email;
        }
    }
}
