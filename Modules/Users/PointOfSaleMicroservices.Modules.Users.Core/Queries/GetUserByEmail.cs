using PointOfSaleMicroservices.Modules.Users.Core.DTO;
using PointOfSaleMicroservices.Shared.Abstractions.Queries;

namespace PointOfSaleMicroservices.Modules.Users.Core.Queries
{
    internal class GetUserByEmail : IQuery<UserDetailsDto>
    {
        public string Email { get; set; }
    }
}
