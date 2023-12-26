using DataAccess.Persistence;
using DataAccess.Repositories.Contracts;
using Domain.Entities;

namespace DataAccess.Repositories.Implementations;

public class PetTypeRepository : Repository<PetType>, IPetTypeRepository
{
    public PetTypeRepository(ApplicationDbContext context) : base(context)
    {
    }
}
