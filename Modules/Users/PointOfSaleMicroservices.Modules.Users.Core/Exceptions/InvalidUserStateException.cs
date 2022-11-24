using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Modules.Users.Core.Exceptions
{
    internal class InvalidUserStateException : PointOfSaleMicroservicesException
    {
        public string State { get; }

        public InvalidUserStateException(string state) : base($"User state is invalid: '{state}'.")
        {
            State = state;
        }
    }
}
