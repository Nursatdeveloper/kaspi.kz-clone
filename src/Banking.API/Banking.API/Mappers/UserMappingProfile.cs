using AutoMapper;
using Banking.API.ViewModels;
using Banking.Core.Entities;

namespace Banking.API.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
