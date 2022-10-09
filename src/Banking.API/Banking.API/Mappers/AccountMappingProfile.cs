using AutoMapper;
using Banking.API.ViewModels;
using Banking.Core.Entities;

namespace Banking.API.Mappers
{
    public class AccountMappingProfile : Profile
    {
        public AccountMappingProfile()
        {
            CreateMap<Account, AccountViewModel>();
        }
    }
}
