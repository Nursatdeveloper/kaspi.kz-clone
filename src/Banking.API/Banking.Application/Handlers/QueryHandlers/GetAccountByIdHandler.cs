using Banking.Application.Queries;
using Banking.Application.Responses;
using Banking.Core.Entities;
using Banking.Infrastructure.Repositories;
using MediatR;

namespace Banking.Application.Handlers.QueryHandlers
{
    public class GetAccountByIdHandler : IRequestHandler<GetEntityByIdQuery<Account, GetEntityResponse<Account>>, GetEntityResponse<Account>>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountByIdHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<GetEntityResponse<Account>> Handle(GetEntityByIdQuery<Account, GetEntityResponse<Account>> request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var account = await _accountRepository.GetByIdAsync(request.Id); 
            if(account is null)
            {
                GetEntityResponse<Account> accountNotFoundResponse = new()
                {
                    IsSuccess = false,
                    Entity = null,
                    StatusCode = 404,
                    Message = $"Account with id: {request.Id} was not found!"
                };
                return accountNotFoundResponse;
            }

            GetEntityResponse<Account> successResponse = new()
            {
                IsSuccess = true,
                Entity = account,
                StatusCode = 200,
                Message = $"Account was found"
            };
            return successResponse;


        }
    }
}
