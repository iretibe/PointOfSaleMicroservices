using Convey.CQRS.Commands;
using Microsoft.AspNetCore.Identity;
using PointOfSaleMicroservices.Identity.Application.Identity.Exceptions;
using PointOfSaleMicroservices.Identity.Core.Core;
using PointOfSaleMicroservices.Identity.Core.Models;

namespace PointOfSaleMicroservices.Identity.Application.Identity.Commands.Handlers
{
    internal class UserRegistrationCommandHandler : ICommandHandler<UserRegistrationCommand>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRegistrationCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task HandleAsync(UserRegistrationCommand command, CancellationToken cancellationToken = default)
        {
            var appUser = new ApplicationUser
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                UserName = command.UserName,
                Email = command.Email,                
                PhoneNumber = command.PhoneNumber,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var identityResult = await _userManager.CreateAsync(appUser, command.Password);
            var roleResult = await _userManager.AddToRoleAsync(appUser, Constants.Role.User);

            if (identityResult.Succeeded == false)
                throw new RegisterIdentityUserException(string.Join(',', identityResult.Errors.Select(e => e.Description)));
            
            if (roleResult.Succeeded == false)
                throw new RegisterIdentityUserException(string.Join(',', roleResult.Errors.Select(e => e.Description)));
        }
    }
}
