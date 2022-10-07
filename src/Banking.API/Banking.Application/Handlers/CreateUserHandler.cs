using Banking.Application.Commands;
using Banking.Application.Responses;
using Banking.Core.Entities;
using Banking.Infrastructure.Repositories;
using BCrypt.Net;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Application.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User user = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                QuickAccessCode = BCrypt.Net.BCrypt.HashPassword(request.QuickAccessCode),
                BirthDate = request.BirthDate,
                Telephone = request.Telephone,
                IIN = request.IIN,
                Role = "Customer",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                Accounts = new List<Account>()
            };

            var createdUser = await _userRepository.CreateAsync(user);
            if(createdUser is not null)
            {
                CreateUserResponse successResponse = new()
                {
                    UserId = createdUser.Id,
                    CreatedUser = createdUser,
                    IsSuccess = true,
                    Message = "User was successfully created!"
                };
                return successResponse;
            }
            else
            {
                CreateUserResponse failureResponse = new()
                {
                    UserId = 0,
                    CreatedUser = null,
                    IsSuccess = false,
                    Message = "Could not create user!"
                };
                return failureResponse;
            }
        }
    }
}
