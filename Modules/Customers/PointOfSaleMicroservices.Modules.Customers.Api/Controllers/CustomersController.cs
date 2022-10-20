using Microsoft.AspNetCore.Mvc;
using PointOfSaleMicroservices.Modules.Customers.Core.Commands;
using PointOfSaleMicroservices.Modules.Customers.Core.DTO;
using PointOfSaleMicroservices.Modules.Customers.Core.Queries;
using PointOfSaleMicroservices.Shared.Abstractions.Dispatchers;

namespace PointOfSaleMicroservices.Modules.Customers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    internal class CustomersController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public CustomersController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpGet("{customerId:guid}")]
        public async Task<ActionResult<CustomerDetailsDto>> Get(Guid customerId)
        {
            var custObj = await _dispatcher.QueryAsync(new GetCustomer
            {
                CustomerId = customerId
            });

            if (custObj is not null)
            {
                return Ok(custObj);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateCustomer command)
        {
            await _dispatcher.SendAsync(command);

            return NoContent();
        }
    }
}
