using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
    public class CategoryService : ICategoryService
    {
        private readonly IMapper mapper;
        private readonly UnitOfWork unitOfWork; 
        public CategoryService(IMapper mapper, UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();
        }

        public async Task<Category> CreateAsync(CategoryForCreationDto dto)
        {
            var category = await unitOfWork.Customers.GetAsync(p => p.Name == dto.Name && p.ItemState != ItemState.Deleted);
            if (category is not null)
                throw new Exception("Object already exist");

            var mapped = mapper.Map<Category>(dto);

            var result = await unitOfWork.Categories.CreateAsync(mapped);
            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Category, bool>> expression)
        {
            var category = await unitOfWork.Categories.GetAsync(expression);
            if (category is null)
                throw new Exception("Object not found");

            await unitOfWork.Categories.DeleteAsync(expression);

            return true;
        }

        public async Task<IEnumerable<Category>> GetAllAsync(Expression<Func<Category, bool>> expression = null)
        {
            var categories = unitOfWork.Categories.GetAll(expression);

            return categories;
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> expression)
        {
            var category = await unitOfWork.Categories.GetAsync(expression);
            if (category is null)
                throw new Exception("Object not found");

            return category;
        }

        public async Task<Category> UpdateAsync(long id, CategoryForCreationDto categoryForCreation)
        {
            var exist = await unitOfWork.Categories.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This object is not found!");

            exist = mapper.Map(categoryForCreation, exist);

            exist.Id = id;

            var result = unitOfWork.Categories.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
