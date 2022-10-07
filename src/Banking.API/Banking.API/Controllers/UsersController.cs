using Banking.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banking.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            if(command is null)
            {
                return BadRequest();
            }
            var response = await _mediator.Send(command, cancellationToken);
            if(response.IsSuccess)
            {
                return Created("", response.CreatedUser);
            }
            return StatusCode(StatusCodes.Status500InternalServerError, response.Message);
        }


    }
}
