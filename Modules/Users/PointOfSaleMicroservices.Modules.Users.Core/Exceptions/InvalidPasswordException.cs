using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Modules.Users.Core.Exceptions
{
    internal class InvalidPasswordException : PointOfSaleMicroservicesException
    {
        public string Reason { get; }

        public InvalidPasswordException(string reason) : base($"Invalid password: {reason}.")
        {
            Reason = reason;
        }
    }
}
