using PetShop.Domain.Configurations;
using PetShop.Domain.Entities;
using PetShop.Service.DTOs;
using System.Linq.Expressions;

namespace PetShop.Service.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateAsync(OrderForCreationDto dto);
        Task<Order> UpdateAsync(long id, OrderForCreationDto dto);
        Task<bool> DeleteAsync(Expression<Func<Order, bool>> expression);
        Task<Order> GetAsync(Expression<Func<Order, bool>> expression);
        Task<IEnumerable<Order>> GetAllAsync(Expression<Func<Order, bool>> expression = null);
    }
}
