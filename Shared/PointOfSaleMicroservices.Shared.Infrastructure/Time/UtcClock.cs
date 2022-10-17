using PointOfSaleMicroservices.Shared.Abstractions.Time;

namespace PointOfSaleMicroservices.Shared.Infrastructure.Time
{
    public class UtcClock : IClock
    {
        public DateTime CurrentDate() => DateTime.UtcNow;
    }
}
