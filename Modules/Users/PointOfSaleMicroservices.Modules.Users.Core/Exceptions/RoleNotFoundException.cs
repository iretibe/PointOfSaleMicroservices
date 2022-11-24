using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Modules.Users.Core.Exceptions
{
    internal class RoleNotFoundException : PointOfSaleMicroservicesException
    {
        public RoleNotFoundException(string role) : base($"Role: '{role}' was not found.")
        {
        }
    }
}
