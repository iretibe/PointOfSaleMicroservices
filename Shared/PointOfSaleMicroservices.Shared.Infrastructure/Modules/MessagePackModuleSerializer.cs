using MessagePack;

namespace PointOfSaleMicroservices.Shared.Infrastructure.Modules
{
    internal class MessagePackModuleSerializer : IModuleSerializer
    {
        private readonly MessagePackSerializerOptions _options =
            MessagePack.Resolvers.ContractlessStandardResolverAllowPrivate.Options;

        public T Deserialize<T>(byte[] value) => MessagePackSerializer.Deserialize<T>(value, _options);

        public object Deserialize(byte[] value, Type type) => MessagePackSerializer.Deserialize(type, value, _options);

        public byte[] Serialize<T>(T value) => MessagePackSerializer.Serialize(value, _options);
    }
}
