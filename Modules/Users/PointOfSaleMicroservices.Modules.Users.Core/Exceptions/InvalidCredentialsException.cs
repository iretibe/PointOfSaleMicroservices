using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Modules.Users.Core.Exceptions
{
    internal class InvalidCredentialsException : PointOfSaleMicroservicesException
    {
        public InvalidCredentialsException() : base("Invalid credentials.")
        {
        }
    }
}
