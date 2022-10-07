namespace Banking.Application.Helpers
{
    public interface IAccountHelper
    {
        Task<string> GenerateIBAN(string type);
    }
}
