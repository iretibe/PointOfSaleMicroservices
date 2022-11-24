using PointOfSaleMicroservices.Shared.Abstractions.Contexts;

namespace PointOfSaleMicroservices.Shared.Abstractions.Messaging
{
    public interface IMessageContext
    {
        public Guid MessageId { get; }
        public IContext Context { get; }
    }
}
