using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Categories { get; }

        public ICustomerRepository Customers { get; }

        public IOrderPetRepository OrderPets { get; }

        public IOrderRepository Orders { get; }

        public IPaymentRepository Payments { get; }

        public IPetRepository Pets  { get; }

        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            Categories = new CategoryRepository(dbContext);
            Customers = new CustomerRepository(dbContext);
            OrderPets = new OrderPetRepository(dbContext);
            Orders = new OrderRepository(dbContext);
            Payments = new PaymentRepository(dbContext);
            Pets = new PetRepository(dbContext);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
