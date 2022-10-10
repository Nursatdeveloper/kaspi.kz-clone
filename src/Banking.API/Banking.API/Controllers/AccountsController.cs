using AutoMapper;
using Banking.API.ViewModels;
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
    public class AccountsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AccountsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetAccountById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetEntityByIdQuery<Account, GetEntityResponse<Account>>(id), cancellationToken);
            if(response.IsSuccess)
            {
                AccountViewModel viewModel = _mapper.Map<AccountViewModel>(response.Entity); 
                return Ok(viewModel);
            }
            return StatusCode(response.StatusCode, response.Message);
        }

        [HttpPost]
        [Route("create")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] CreateAccountCommand command, 
            CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(command, cancellationToken);
            if (response.IsSuccess)
            {
                return CreatedAtRoute("GetAccountById", new { id = response.Id }, response.Entity);
            }
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
