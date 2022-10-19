using Microsoft.AspNetCore.Mvc;
using PointOfSaleMicroservices.Modules.Customers.Core.Commands;
using PointOfSaleMicroservices.Shared.Abstractions.Commands;

namespace PointOfSaleMicroservices.Modules.Customers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class CustomersController : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public CustomersController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateCustomer command)
        {
            await _commandDispatcher.SendAsync(command);

            return NoContent();
        }
    }
}
