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
    public class PetRepository : GenericRepository<Pet>, IPetRepository
    {
        public PetRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
