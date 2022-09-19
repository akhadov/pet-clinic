using PetShop.Domain.Configurations;
using PetShop.Domain.Entities;
using PetShop.Service.DTOs;
using System.Linq.Expressions;

namespace PetShop.Service.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> CreateAsync(PaymentForCreationDto paymentForCreation);
        Task<Payment> UpdateAsync(long id, PaymentForCreationDto paymentForCreation);
        Task<bool> DeleteAsync(Expression<Func<Payment, bool>> expressions);
        Task<Payment> GetAsync(Expression<Func<Payment, bool>> expression);
        Task<IEnumerable<Payment>> GetAllAsync(Expression<Func<Payment, bool>> expression = null);
    }
}
