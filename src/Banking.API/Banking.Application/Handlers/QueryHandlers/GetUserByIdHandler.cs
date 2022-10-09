using Banking.Application.Queries;
using Banking.Application.Responses;
using Banking.Core.Entities;
using Banking.Infrastructure.Repositories;
using Banking.Infrastructure.Repositories.Base;
using MediatR;
using System.Collections.Generic;

namespace Banking.Application.Handlers.QueryHandlers
{
    public class GetUserByIdHandler : IRequestHandler<GetEntityByIdQuery<User, GetEntityResponse<User>>, GetEntityResponse<User>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountRepository _accountRepository;

        public GetUserByIdHandler(IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _userRepository = userRepository;
            _accountRepository = accountRepository;
        }

        public async Task<GetEntityResponse<User>> Handle(GetEntityByIdQuery<User, GetEntityResponse<User>> request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetUserById(request.Id);
            if(user is null)
            {
                GetEntityResponse<User> userNotFoundResponse = new()
                {
                    Entity = null,
                    IsSuccess = false,
                    StatusCode = 404,
                    Message = $"User with id: {request.Id} not found!"
                };
                return userNotFoundResponse;
            }

            GetEntityResponse<User> successResponse = new()
            {
                Entity = user,
                IsSuccess = true,
                StatusCode = 200,
                Message = "User was found!"
            };
            return successResponse;
        }
    }
}
