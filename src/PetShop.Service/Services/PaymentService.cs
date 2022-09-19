using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
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
    public class PaymentService : IPaymentService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly AppDbContext context;
        public PaymentService()
        {
            this.context = new AppDbContext();
            this.unitOfWork = new UnitOfWork(context);
            this.mapper = new MapperConfiguration(p =>
            {
                p.AddProfile<MappingProfile>();
            }).CreateMapper();
        }
        public async Task<Payment> CreateAsync(PaymentForCreationDto dto)
        {
            var category = await unitOfWork.Payments.GetAsync(p => p.Pet.Id == dto.PetId && p.ItemState != ItemState.Deleted);
            if (category is not null)
                throw new Exception("Object already exist");

            var mapped = mapper.Map<Payment>(dto);

            var result = await unitOfWork.Payments.CreateAsync(mapped);
            await unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Payment, bool>> expressions)
        {
            var category = await unitOfWork.Payments.GetAsync(expressions);
            if (category is null)
                throw new Exception("Object not found");

            await unitOfWork.Payments.DeleteAsync(expressions);

            return true;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync(Expression<Func<Payment, bool>> expression = null)
        {
            var payments = unitOfWork.Payments.GetAll(expression);

            return payments;
        }

        public async Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression)
        {
            var payment = await unitOfWork.Payments.GetAsync(expression);
            if (payment is null)
                throw new Exception("Object not found");

            return payment;
        }

        public async Task<Payment> UpdateAsync(long id, PaymentForCreationDto paymentForCreation)
        {
            var exist = await unitOfWork.Payments.GetAsync(a => a.Id == id);

            if (exist is null || exist.ItemState == ItemState.Deleted)
                throw new Exception("This object is not found!");

            exist = mapper.Map(paymentForCreation, exist);

            exist.Id = id;

            var result = unitOfWork.Payments.UpdateAsync(exist);

            await unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}
