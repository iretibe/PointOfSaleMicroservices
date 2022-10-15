namespace PointOfSaleMicroservices.Shared.Abstractions.Exceptions
{
    public abstract class PointOfSaleMicroservicesException : Exception
    {
        protected PointOfSaleMicroservicesException(string message) : base(message)
        {

        }
    }
}
