using PointOfSaleMicroservices.Shared.Abstractions.Commands;

namespace PointOfSaleMicroservices.Modules.Users.Core.Commands
{
    internal record SignOut(Guid UserId) : ICommand;
}
