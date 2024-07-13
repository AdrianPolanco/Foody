using AutoMapper;
using Foody.API.Requests;
using Foody.API.Requests.Ingredient;
using Foody.API.Requests.Users;
using Foody.Core.Application.Features.Ingredients.Create;
using Foody.Infrastructure.Persistence.Models;

namespace Foody.API.Mappers
{
    public class ApiProfile : Profile
    {
        public ApiProfile() { 
            CreateMap<LoginRequest, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username));

            CreateMap<SignUpUserRequest, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Lastname));

            CreateMap<CreateIngredientRequest, CreateIngredientCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
