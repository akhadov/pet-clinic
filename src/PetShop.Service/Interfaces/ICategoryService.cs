using PetShop.Domain.Configurations;
using PetShop.Domain.Entities;
using PetShop.Service.DTOs;
using System.Linq.Expressions;

namespace PetShop.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> CreateAsync(CategoryForCreationDto categoryForCreation);
        Task<Category> UpdateAsync(long id, CategoryForCreationDto categoryForCreation);
        Task<bool> DeleteAsync(Expression<Func<Category, bool>> expression);
        Task<Category> GetAsync(Expression<Func<Category, bool>> expression);
        Task<IEnumerable<Category>> GetAllAsync(Expression<Func<Category, bool>> expression = null);
    }
}
