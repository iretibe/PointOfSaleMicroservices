using PointOfSaleMicroservices.Shared.Abstractions.Commands;
using System.ComponentModel.DataAnnotations;

namespace PointOfSaleMicroservices.Modules.Users.Core.Commands
{
    internal record SignIn([Required][EmailAddress] string Email, [Required] string Password) : ICommand
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
