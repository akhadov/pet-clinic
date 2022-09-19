using AutoMapper;
using PetShop.Domain.Entities;
using PetShop.Service.DTOs;

namespace PetShop.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryForCreationDto>().ReverseMap();
            CreateMap<Customer, CustomerForCreationDto>().ReverseMap();
            CreateMap<Payment, PaymentForCreationDto>().ReverseMap();
            CreateMap<Pet, PetForCreationDto>().ReverseMap();
            CreateMap<OrderPet, OrderForCreationDto>().ReverseMap();
            CreateMap<Order, OrderForCreationDto>().ReverseMap();
        }
    }
}
