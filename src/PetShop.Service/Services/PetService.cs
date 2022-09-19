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
    public class PetService : IPetService
    {

        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly AppDbContext context;
        public PetService()
        {
            this.context = new AppDbContext();
            this.unitOfWork = new UnitOfWork(context);
            this.mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();
        }

        public async Task<Pet> CreateAsync(PetForCreationDto dto)
        {
            var pet = await unitOfWork.Pets.GetAsync(p => p.Name == dto.Name && p.ItemState != ItemState.Deleted);
            if (pet is not null)
                throw new Exception("Object already exist");

            var mapped = mapper.Map<Pet>(dto);

            var result = await unitOfWork.Pets.CreateAsync(mapped);
            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Pet, bool>> expression)
        {
            var pet = await unitOfWork.Pets.GetAsync(expression);
            if (pet is null)
                throw new Exception("Object not found");

            await unitOfWork.Pets.DeleteAsync(expression);
            await unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Pet>> GetAllAsync(Expression<Func<Pet, bool>> expression = null)
        {
            var pets = unitOfWork.Pets.GetAll(expression);

            return pets;
        }

        public async Task<Pet> GetAsync(Expression<Func<Pet, bool>> expression)
        {
            var pet = await unitOfWork.Pets.GetAsync(expression);
            if (pet is null)
                throw new Exception("Object not found");

            return pet;
        }

        public async Task<Pet> UpdateAsync(long id, PetForCreationDto petForCreation)
        {
            var exist = await unitOfWork.Pets.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This object is not found!");

            exist = mapper.Map(petForCreation, exist);

            exist.Id = id;

            var result = unitOfWork.Pets.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
