using PetShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.IRepositories
{
    public interface IPetRepository : IGenericRepository<Pet>
    {
    }
}
