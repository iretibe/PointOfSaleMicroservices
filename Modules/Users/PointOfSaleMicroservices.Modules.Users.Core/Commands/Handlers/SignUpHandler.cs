﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using PointOfSaleMicroservices.Modules.Users.Core.Entities;
using PointOfSaleMicroservices.Modules.Users.Core.Exceptions;
using PointOfSaleMicroservices.Modules.Users.Core.Repositories;
using PointOfSaleMicroservices.Shared.Abstractions;
using PointOfSaleMicroservices.Shared.Abstractions.Commands;
using PointOfSaleMicroservices.Shared.Abstractions.Time;

namespace PointOfSaleMicroservices.Modules.Users.Core.Commands.Handlers
{
    internal sealed class SignUpHandler : ICommandHandler<SignUp>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IClock _clock;
        private readonly ILogger<SignUpHandler> _logger;

        public SignUpHandler(IUserRepository userRepository, IRoleRepository roleRepository,
            IPasswordHasher<User> passwordHasher, IClock clock, ILogger<SignUpHandler> logger)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _passwordHasher = passwordHasher;
            _clock = clock;
            _logger = logger;
        }

        public async Task HandleAsync(SignUp command, CancellationToken cancellationToken = default)
        {
            var email = command.Email.ToLowerInvariant();
            
            var provider = email.Split("@").Last();
            

            if (string.IsNullOrWhiteSpace(command.Password) || command.Password.Length is > 100 or < 6)
            {
                throw new InvalidPasswordException("not matching the criteria");
            }

            var user = await _userRepository.GetAsync(email);
            
            if (user is not null)
            {
                throw new EmailInUseException();
            }

            var roleName = string.IsNullOrWhiteSpace(command.Role) ? Role.Default : command.Role.ToLowerInvariant();
            
            var role = await _roleRepository.GetAsync(roleName)
                .NotNull(() => new RoleNotFoundException(roleName));

            var now = _clock.CurrentDate();
            
            var password = _passwordHasher.HashPassword(default, command.Password);
            
            user = new User
            {
                Id = command.UserId,
                Email = email,
                Password = password,
                Role = role,
                CreatedAt = now,
                State = UserState.Active,
            };
            
            await _userRepository.AddAsync(user);

            _logger.LogInformation($"User with ID: '{user.Id}' has signed up.");
        }
    }
}
