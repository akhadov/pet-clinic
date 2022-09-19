using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repositories
{
#pragma warning disable
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

            protected readonly AppDbContext _context;
            protected readonly DbSet<T> _dbSet;

            public GenericRepository(AppDbContext dbContext)
            {
            this._context = dbContext;
                this._dbSet = _context.Set<T>();
            }

        public async Task<T> CreateAsync(T entity) =>
              (await _dbSet.AddAsync(entity)).Entity;



        public async Task<bool> DeleteAsync(Expression<Func<T, bool>> expression)
            {
                var entity = await _dbSet.FirstOrDefaultAsync(expression);

                if (entity is null)
                    return false;

                _dbSet.Remove(entity);

                return true;
            }

            public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
                => expression is null ? _dbSet : _dbSet.Where(expression);

            public async Task<T> GetAsync(Expression<Func<T, bool>> expression)
                => await _dbSet.FirstOrDefaultAsync(expression);

        public T UpdateAsync(T entity)
        => _dbSet.Update(entity).Entity;
    }
    }

