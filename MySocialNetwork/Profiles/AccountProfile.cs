using AutoMapper;
using MySocialNetwork.Models;

namespace MySocialNetwork.Profiles
{

    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountRegisterModel, Account>();
        }
    }
}
