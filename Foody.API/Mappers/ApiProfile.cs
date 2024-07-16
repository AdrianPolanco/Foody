using AutoMapper;
using Foody.API.Requests;
using Foody.API.Requests.Dishes;
using Foody.API.Requests.Ingredient;
using Foody.API.Requests.Tables;
using Foody.API.Requests.Users;
using Foody.Core.Application.Features.Dishes.Create;
using Foody.Core.Application.Features.Dishes.Update;
using Foody.Core.Application.Features.Ingredients.Create;
using Foody.Core.Application.Features.Orders.Create;
using Foody.Core.Application.Features.Table.Create;
using Foody.Core.Application.Features.Tables.Update;
using Foody.Core.Domain.Enums;
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

            CreateMap<CreateDishRequest, CreateDishCommand>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.PeopleQuantity, opt => opt.MapFrom(src => src.PeopleQuantity))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Ingredients));

            CreateMap<UpdateDishRequest, UpdateDishCommand>()
                .ForCtorParam("Name", opt => opt.MapFrom(src => src.Name))
                .ForCtorParam("Price", opt => opt.MapFrom(src => src.Price))
                .ForCtorParam("PeopleQuantity", opt => opt.MapFrom(src => src.PeopleQuantity))
                .ForCtorParam("Ingredients", opt => opt.MapFrom(src => src.Ingredients))
                .ForCtorParam("Category", opt => opt.MapFrom(src => src.Category));

            CreateMap<CommandTableRequest, CreateTableCommand>()
                .ForCtorParam("Description", opt => opt.MapFrom(src => src.Description))
                .ForCtorParam("Seats", opt => opt.MapFrom(src => src.Seats));

            CreateMap<CommandTableRequest, UpdateTableCommand>()
                .ForCtorParam("Description", opt => opt.MapFrom(src => src.Description))
                .ForCtorParam("Seats", opt => opt.MapFrom(src => src.Seats));

            CreateMap<CreateOrderRequest, CreateOrderCommand>()
                .ForCtorParam("TableId", opt => opt.MapFrom(src => src.TableId))
                .ForCtorParam("DishesId", opt => opt.MapFrom(src => src.DishesId));
        }
    }
}
