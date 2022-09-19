using AutoMapper;
using Mapster;
using Microsoft.EntityFrameworkCore;
using PetShop.Data.IRepositories;
using PetShop.Data.Repositories;
using PetShop.Domain.Configurations;
using PetShop.Domain.Entities;
using PetShop.Domain.Enums;
using PetShop.Service.DTOs;
using PetShop.Service.Extentions;
using PetShop.Service.Interfaces;
using PetShop.Service.Mappers;
using System.Linq.Expressions;

namespace PetShop.Service.Services
{
#pragma warning disable
    public class OrderService : IOrderService
    {
        private readonly IMapper mapper;
        private readonly UnitOfWork unitOfWork;
        public OrderService(IMapper mapper, UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();  
        }

        public async Task<Order> CreateAsync(OrderForCreationDto dto)
        {
            var order = await unitOfWork.Orders.GetAsync(p => p.CustomerId == dto.CustomerId && p.ItemState != ItemState.Deleted);
            if (order is not null)
                throw new Exception("Object already exist");

            var mapped = mapper.Map<Order>(dto);

            var result = await unitOfWork.Orders.CreateAsync(mapped);
            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression)
        {
            var order = await unitOfWork.Orders.GetAsync(expression);
            if (order is null)
                throw new Exception("Object not found");

            await unitOfWork.Orders.DeleteAsync(expression);

            return true;
        }

        public async Task<IEnumerable<Order>> GetAllAsync(Expression<Func<Order, bool>> expression = null)
        {
            var orders = unitOfWork.Orders.GetAll(expression);

            return orders;
        }

        public async Task<Order> GetAsync(Expression<Func<Order, bool>> expression)
        {
            var order = await unitOfWork.Orders.GetAsync(expression);
            if (order is null)
                throw new Exception("Object not found");

            return order;
        }

        public async Task<Order> UpdateAsync(long id, OrderForCreationDto orderForCreation)
        {
            var exist = await unitOfWork.Orders.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This object is not found!");

            exist = mapper.Map(orderForCreation, exist);

            exist.Id = id;

            var result = unitOfWork.Orders.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
