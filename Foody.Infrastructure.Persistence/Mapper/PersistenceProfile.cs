
using AutoMapper;
using Foody.Core.Domain.Entities;
using Foody.Infrastructure.Persistence.Models;

namespace Foody.Infrastructure.Persistence.Mapper
{
    public class PersistenceProfile : Profile
    {
        public PersistenceProfile()
        {
            CreateMap<ApplicationUser, User>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Lastname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
