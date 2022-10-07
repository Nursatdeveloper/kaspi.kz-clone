using Banking.Application.Commands;
using Banking.Core.Entities;
using Banking.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateAccountCommand command, 
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);
            if (response.IsSuccess)
            {
                return StatusCode(response.StatusCode, response.Message);
            }
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
