using PointOfSaleMicroservices.Shared.Abstractions.Auth;

namespace PointOfSaleMicroservices.Modules.Users.Core.Services
{
    internal interface IUserRequestStorage
    {
        void SetToken(Guid commandId, JsonWebToken jwt);
        JsonWebToken GetToken(Guid commandId);
    }
}
