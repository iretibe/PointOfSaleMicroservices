using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Modules.Users.Core.Exceptions
{
    internal class SignUpDisabledException : PointOfSaleMicroservicesException
    {
        public SignUpDisabledException() : base("Sign up is disabled.")
        {
        }
    }
}
