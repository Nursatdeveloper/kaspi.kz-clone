using Banking.Application.Commands;
using Banking.Application.Helpers;
using Banking.Application.Responses;
using Banking.Application.Validators;
using Banking.Core.Entities;
using Banking.Infrastructure.Repositories;
using MediatR;

namespace Banking.Application.Handlers
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, CreatedResponse<Account>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountHelper _accountHelper;

        public CreateAccountHandler(
            IUserRepository userRepository, 
            IAccountRepository accountRepository, 
            IAccountHelper accountHelper)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
            _accountHelper = accountHelper;
        }

        public async Task<CreatedResponse<Account>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByIdAsync(request.UserId);

            if(user is null)
            {
                CreatedResponse<Account> userNotFoundResponse = new()
                {
                    Id = 0,
                    Entity = null,
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = $"User with id {request.UserId} is not found!"
                };
                return userNotFoundResponse;
            }


            Account account = new()
            {
                Balance = 0.0,
                Currency = request.Currency,
                IIN = user.IIN,
                Customer = $"{user.FirstName} {user.LastName}",
                UserId = request.UserId,
                BankName = "AO Kaspi Bank",
                BIC = "CASPKZKA",
                IBAN = await _accountHelper.GenerateIBAN(request.Type ?? "C")
            };

            var createdAccount = await _accountRepository.CreateAsync(account);
            if (createdAccount is null)
            {
                CreatedResponse<Account> createFailedResponse = new()
                {
                    Id = 0,
                    Entity = null,
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = "Cound not create an account!"
                };
                return createFailedResponse;
            }
            user.Accounts.Add(createdAccount);
            _userRepository.Update(user);
            CreatedResponse<Account> createSuccessResponse = new()
            {
                Id = createdAccount.Id,
                Entity = createdAccount,
                IsSuccess = true,
                StatusCode = 201,
                Message = "Account was created successfully!"
            };
            return createSuccessResponse;



        }
    }
}
