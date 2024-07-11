using AutoMapper;
using Foody.API.Requests;
using Foody.Infrastructure.Persistence.Models;

namespace Foody.API.Mappers
{
    public class ApiProfile : Profile
    {
        public ApiProfile() { 
            CreateMap<LoginRequest, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username));
        }
    }
}
