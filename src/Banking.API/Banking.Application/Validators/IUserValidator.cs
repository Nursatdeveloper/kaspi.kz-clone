namespace Banking.Application.Validators
{
    public interface IUserValidator
    {
        bool ValidateIIN(string iin);
        Task<bool> ValidatePassword(int userId, string password);
    }
}
