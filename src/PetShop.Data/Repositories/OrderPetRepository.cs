using PetShop.Data.Contexts;
using PetShop.Data.IRepositories;
using PetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repositories
{
    public class OrderPetRepository : GenericRepository<OrderPet>, IOrderPetRepository
    {
        public OrderPetRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
