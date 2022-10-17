using PointOfSaleMicroservices.Shared.Abstractions.Exceptions

namespace PointOfSaleMicroservices.Shared.Abstractions.Kernel.Exceptions
{
    public class UnsupportedNationalityException : PointOfSaleMicroservicesException
    {
        public string Nationality { get; }

        public UnsupportedNationalityException(string nationality) : base($"Nationality: '{nationality}' is unsupported.")
        {
            Nationality = nationality;
        }
    }
}
