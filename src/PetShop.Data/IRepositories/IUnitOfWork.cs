using PetShop.Domain.Entities;
using System.ComponentModel;

namespace PetShop.Data.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        ICustomerRepository Customers { get; }
        IOrderPetRepository OrderPets { get; }
        IOrderRepository Orders { get; }
        IPaymentRepository Payments { get; }
        IPetRepository Pets { get; }
        Task SaveChangesAsync();
    }
}
