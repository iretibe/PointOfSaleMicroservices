using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Modules.Users.Core.Exceptions
{
    internal class InvalidEmailException : PointOfSaleMicroservicesException
    {
        public string Email { get; }

        public InvalidEmailException(string email) : base($"State is invalid: '{email}'.")
        {
            Email = email;
        }
    }
}
