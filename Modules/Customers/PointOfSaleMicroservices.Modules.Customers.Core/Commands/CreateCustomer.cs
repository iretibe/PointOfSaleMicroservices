using PointOfSaleMicroservices.Shared.Abstractions.Commands;

namespace PointOfSaleMicroservices.Modules.Customers.Core.Commands
{
    internal record CreateCustomer(string Email) : ICommand;
}
