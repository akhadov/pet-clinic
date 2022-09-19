using PetShop.Domain.Configurations;
using PetShop.Domain.Entities;
using PetShop.Service.DTOs;
using System.Linq.Expressions;

namespace PetShop.Service.Interfaces
{
    public interface IPetService
    {
        Task<Pet> CreateAsync(PetForCreationDto petForCreation);
        Task<Pet> UpdateAsync(long id, PetForCreationDto petForCreation);
        Task<bool> DeleteAsync(Expression<Func<Pet, bool>> expression);
        Task<Pet> GetAsync(Expression<Func<Pet, bool>> expression);
        Task<IEnumerable<Pet>> GetAllAsync(Expression<Func<Pet, bool>> expression = null);
    }
}
