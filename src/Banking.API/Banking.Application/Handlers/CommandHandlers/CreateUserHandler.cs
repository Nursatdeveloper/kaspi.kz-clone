using Banking.Application.Commands;
using Banking.Application.Responses;
using Banking.Application.Validators;
using Banking.Core.Entities;
using Banking.Infrastructure.Repositories;
using MediatR;

namespace Banking.Application.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreatedResponse<User>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserValidator _userValidator;

        public CreateUserHandler(IUserRepository userRepository, IUserValidator userValidator)
        {
            _userRepository = userRepository;
            _userValidator = userValidator;
        }
        public async Task<CreatedResponse<User>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if(!_userValidator.ValidateIIN(request.IIN))
            {
                CreatedResponse<User> invalidIINResponse = new()
                {
                    Id = 0,
                    Entity = null,
                    StatusCode = 400,
                    Message = "Invalid IIN!",
                    IsSuccess = false
                };
                return invalidIINResponse;
            }
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
                CreatedResponse<User> successResponse = new()
                {
                    Id = createdUser.Id,
                    Entity = createdUser,
                    StatusCode = 201,
                    IsSuccess = true,
                    Message = "User was successfully created!"
                };
                return successResponse;
            }
            else
            {
                CreatedResponse<User> failureResponse = new()
                {
                    Id = 0,
                    Entity = null,
                    IsSuccess = false,
                    StatusCode = 500,
                    Message = "Could not create user!"
                };
                return failureResponse;
            }
        }
    }
}
