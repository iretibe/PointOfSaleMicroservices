using Convey;
using Convey.CQRS.Commands;

namespace PointOfSaleMicroservices.Identity.Application
{
    public static class Extensions
    {
        public static IConveyBuilder AddApplication(this IConveyBuilder builder)
            =>
                builder
                    .AddCommandHandlers();
    }
}
