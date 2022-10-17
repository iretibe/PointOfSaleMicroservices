using PointOfSaleMicroservices.Shared.Abstractions.Exceptions;

namespace PointOfSaleMicroservices.Shared.Abstractions.Kernel.Exceptions
{
    public class InvalidNationalityException : PointOfSaleMicroservicesException
    {
        public string Nationality { get; }

        public InvalidNationalityException(string nationality) : base($"Nationality: '{nationality}' is invalid.")
        {
            Nationality = nationality;
        }
    }
}
