using Microsoft.Extensions.Logging;
using PointOfSaleMicroservices.Modules.Users.Core.Entities;
using PointOfSaleMicroservices.Modules.Users.Core.Exceptions;
using PointOfSaleMicroservices.Modules.Users.Core.Repositories;
using PointOfSaleMicroservices.Shared.Abstractions;
using PointOfSaleMicroservices.Shared.Abstractions.Commands;

namespace PointOfSaleMicroservices.Modules.Users.Core.Commands.Handlers
{
    internal sealed class SignInHandler : ICommandHandler<SignIn>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<SignInHandler> _logger;

        public SignInHandler(IUserRepository userRepository, ILogger<SignInHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task HandleAsync(SignIn command, CancellationToken cancellationToken = default)
        {
            var user = await _userRepository.GetAsync(command.Email.ToLowerInvariant())
                .NotNull(() => new InvalidCredentialsException());

            if (user.State != UserState.Active)
            {
                throw new UserNotActiveException(user.Id);
            }

            var claims = new Dictionary<string, IEnumerable<string>>
            {
                ["permissions"] = user.Role.Permissions
            };

            _logger.LogInformation($"User with ID: '{user.Id}' has signed in.");
        }
    }
}
