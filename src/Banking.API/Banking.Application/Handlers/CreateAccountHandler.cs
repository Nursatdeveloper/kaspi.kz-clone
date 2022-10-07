using Banking.Application.Commands;
using Banking.Application.Responses;
using Banking.Core.Entities;
using Banking.Infrastructure.Repositories;
using MediatR;

namespace Banking.Application.Handlers
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, CreateResponse<Account>>
    {
        private readonly IUserRepository _userRepository;

        public CreateAccountHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        Task<CreateResponse<Account>> IRequestHandler<CreateAccountCommand, CreateResponse<Account>>.Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
