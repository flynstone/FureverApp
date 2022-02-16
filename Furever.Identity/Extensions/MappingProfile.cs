using AutoMapper;
using WebApp.Identity.Models;
using WebApp.Identity.Models.ViewModels;

namespace WebApp.Identity.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationModel, User>().ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
