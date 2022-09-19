using PetShop.Domain.Configurations;
using PetShop.Domain.Entities;
using PetShop.Service.DTOs;
using System.Linq.Expressions;

namespace PetShop.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<Customer> CreateAsync(CustomerForCreationDto customerForCreation);
        Task<Customer> UpdateAsync(long id, CustomerForCreationDto customerForCreation);
        Task<bool> DeleteAsync(Expression<Func<Customer, bool>> expression);
        Task<Customer> GetAsync(Expression<Func<Customer, bool>> expression);
        Task<IEnumerable<Customer>> GetAllAsync(Expression<Func<Customer, bool>> expression = null);
    }
}
