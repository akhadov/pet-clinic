using DataAccess.Persistence;
using DataAccess.Repositories.Contracts;
using Domain.Entities;

namespace DataAccess.Repositories.Implementations;

public class PetRepository : Repository<Pet>, IPetRepository
{
    public PetRepository(ApplicationDbContext context) : base(context)
    {
    }
}
