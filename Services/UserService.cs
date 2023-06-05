using AutoMapper;
using PuYuan_net7.Models;

namespace PuYuan_net7.Services
{
    public class UserService: Profile
    {
        public UserService()
        {
            CreateMap<UserInfoViewModel, User>();
        }
    }
}