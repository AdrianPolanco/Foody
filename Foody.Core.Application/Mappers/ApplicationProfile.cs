

using AutoMapper;
using Foody.Core.Application.Dtos;
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

            CreateMap<Dish, DishDto>()
                .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
                .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name))
                .ForCtorParam("Price", opt => opt.MapFrom(src => src.Price))
                .ForCtorParam("PeopleQuantity", opt => opt.MapFrom(src => src.PeopleQuantity))
                .ForCtorParam("Category", opt => opt.MapFrom(src => src.Category));


            CreateMap<DinnerTable, TableDto>()
                .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
                .ForCtorParam("Name", opt => opt.MapFrom(src => src.Description))
                .ForCtorParam("Capacity", opt => opt.MapFrom(src => src.Capacity))
                .ForCtorParam("State", opt => opt.MapFrom(src => src.State));

            CreateMap<Order, OrderDto>()
                .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
                .ForCtorParam("Table", opt => opt.MapFrom(src => src.Table))
                .ForCtorParam("Dishes", opt => opt.MapFrom(src => src.Dishes))
                .ForCtorParam("Subtotal", opt => opt.MapFrom(src => src.Subtotal))
                .ForCtorParam("State", opt => opt.MapFrom(src => src.State))
                .ForCtorParam("CreatedAt", opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<Order, PlainOrderDto>()
                .ForCtorParam("Id", opt => opt.MapFrom(src => src.Id))
                .ForCtorParam("Dishes", opt => opt.MapFrom(src => src.Dishes))
                .ForCtorParam("Subtotal", opt => opt.MapFrom(src => src.Subtotal))
                .ForCtorParam("State", opt => opt.MapFrom(src => src.State))
                .ForCtorParam("CreatedAt", opt => opt.MapFrom(src => src.CreatedAt));
        }
    }
}
