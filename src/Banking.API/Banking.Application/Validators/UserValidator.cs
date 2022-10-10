using Banking.Infrastructure.Repositories;
using System.Text.RegularExpressions;

namespace Banking.Application.Validators
{
    public class UserValidator : IUserValidator
    {
        private readonly IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }
        public bool ValidateIIN(string iin)
        {
            Regex regex = new Regex(@"^\d+$");
            if(iin.Length == 12  && regex.IsMatch(iin))
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ValidatePassword(int userId, string password)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if(BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return true;
            }
            return false;
        }
    }
}
