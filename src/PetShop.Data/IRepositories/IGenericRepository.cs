using PetShop.Domain.Common;
using System.Linq.Expressions;

namespace PetShop.Data.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<bool> DeleteAsync(Expression<Func<T, bool>> expression);
        Task<T> GetAsync(Expression<Func<T, bool>> expression);
        T UpdateAsync(T entity);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null);
    }
}
