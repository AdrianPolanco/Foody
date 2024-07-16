

using AutoMapper;
using Foody.Core.Application.Features.Dishes.Create;
using Foody.Core.Application.Features.Dishes.Update;
using Foody.Core.Application.Features.Ingredients.Create;
using Foody.Core.Application.Features.Table.Create;
using Foody.Core.Domain.Entities;

namespace Foody.Core.Application.Mappers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<CreateIngredientCommand, Ingredient>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Ingredient, CreateIngredientCommandResult>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<CreateDishCommand, Dish>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.PeopleQuantity, opt => opt.MapFrom(src => src.PeopleQuantity))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.DishesIngredients, opt => opt.Ignore())
                .ForMember(dest => dest.Ingredients, opt => opt.Ignore());
                
            CreateMap<UpdateDishCommand, Dish>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.PeopleQuantity, opt => opt.MapFrom(src => src.PeopleQuantity))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.DishesIngredients, opt => opt.Ignore())
                .ForMember(dest => dest.Ingredients, opt => opt.Ignore());

            CreateMap<CreateTableCommand, DinnerTable>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Seats))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State));
        }
    }
}
