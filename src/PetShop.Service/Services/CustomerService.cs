using AutoMapper;
using PetShop.Data.Contexts;
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
    public class CustomerService : ICustomerService
    {

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly AppDbContext context;
        public CustomerService()
        {
            this.context = new AppDbContext();
            this.unitOfWork = new UnitOfWork(context);
            this.mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();
        }

        public async Task<Customer> CreateAsync(CustomerForCreationDto dto)
        {
            var category = await unitOfWork.Customers.GetAsync(p => p.Phone == dto.Phone && p.ItemState != ItemState.Deleted);
            if (category is not null)
                throw new Exception("Object already exist");

            var mapped = mapper.Map<Customer>(dto);

            var result = await unitOfWork.Customers.CreateAsync(mapped);
            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Customer, bool>> expression)
        {
            var category = await unitOfWork.Customers.GetAsync(expression);
            if (category is null)
                throw new Exception("Object not found");

            await unitOfWork.Customers.DeleteAsync(expression);

            return true;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(Expression<Func<Customer, bool>> expression = null)
        {
            var categories = unitOfWork.Customers.GetAll(expression);

            return categories;
        }

        public async Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression)
        {
            var category = await unitOfWork.Customers.GetAsync(expression);
            if (category is null)
                throw new Exception("Object not found");

            return category;
        }

        public async Task<Customer> UpdateAsync(long id, CustomerForCreationDto customerForCreation)
        {
            var exist = await unitOfWork.Customers.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This object is not found!");

            exist = mapper.Map(customerForCreation, exist);

            exist.Id = id;

            var result = unitOfWork.Customers.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
