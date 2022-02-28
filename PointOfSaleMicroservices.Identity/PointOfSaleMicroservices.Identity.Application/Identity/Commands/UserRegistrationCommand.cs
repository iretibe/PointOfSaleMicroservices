using Convey.CQRS.Commands;

namespace PointOfSaleMicroservices.Identity.Application.Identity.Commands
{
    public record UserRegistrationCommand(string FirstName, string LastName, 
        string UserName, string Email, string PhoneNumber, string Password, string ConfirmPassword) : ICommand;
}
