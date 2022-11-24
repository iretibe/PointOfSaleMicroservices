using PointOfSaleMicroservices.Shared.Abstractions.Messaging;

namespace PointOfSaleMicroservices.Shared.Infrastructure.Messaging.Contexts
{
    public interface IMessageContextRegistry
    {
        void Set(IMessage message, IMessageContext context);
    }
}
