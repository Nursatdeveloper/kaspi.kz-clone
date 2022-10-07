using Banking.Infrastructure.Repositories;
using System.Text;

namespace Banking.Application.Helpers
{
    public class AccountHelper : IAccountHelper
    {
        private readonly IAccountRepository _accountRepository;

        public AccountHelper(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<string> GenerateIBAN(string type)
        {
            StringBuilder iban = new StringBuilder();
            iban.Append("KZ");
            Random random = new Random();
            iban.Append(random.Next(10000, 99999).ToString());
            iban.Append(type);
            for(int i = 0; i < 12; i++)
            {
                iban.Append(random.Next(9).ToString());
            }
            
            bool ibanExist = await _accountRepository.Exist(a => a.IBAN == iban.ToString());
            if (ibanExist)
            {
                await GenerateIBAN(type);
            }
            return iban.ToString();
            
        }
    }
}
