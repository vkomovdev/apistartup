using AutoMapper;
using MySocialNetwork.Models;

namespace MySocialNetwork.Profiles
{

    public class SubscribeProfile : Profile
    {
        public SubscribeProfile()
        {
            CreateMap<SubscribeRegisterModel, SubscribeModel>();
        }
    }
}
