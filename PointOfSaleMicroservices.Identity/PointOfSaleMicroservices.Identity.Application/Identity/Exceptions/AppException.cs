namespace PointOfSaleMicroservices.Identity.Application.Identity.Exceptions
{
    public abstract class AppException : Exception
    {
        public AppException(string message) : base(message)
        {

        }
    }
}
