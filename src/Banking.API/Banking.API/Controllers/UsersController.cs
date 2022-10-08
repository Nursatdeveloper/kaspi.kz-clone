using Banking.Application.Commands;
using Banking.Application.Queries;
using Banking.Application.Responses;
using Banking.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

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

        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var response = await _mediator.Send(
                new GetEntityByIdQuery<User, GetEntityResponse<User>>(id));
            if (response.IsSuccess)
            {
                return Ok(response.Entity);
            }
            return StatusCode(response.StatusCode, response.Message);
        }


        [HttpPost]
        [Route("create")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            if(command is null)
            {
                return BadRequest();
            }
            var response = await _mediator.Send(command, cancellationToken);
            if(response.IsSuccess)
            {
                return CreatedAtRoute("GetUserById", new { id = response.Id }, response.Entity);
            }
            return StatusCode(response.StatusCode, response.Message);
        }


    }
}
