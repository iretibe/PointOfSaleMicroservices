using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Modules.Users.Core.Exceptions
{
    internal class EmailInUseException : PointOfSaleMicroservicesException
    {
        public EmailInUseException() : base("Email is already in use.")
        {
        }
    }
}
