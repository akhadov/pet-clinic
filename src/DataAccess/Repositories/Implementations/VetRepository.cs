using DataAccess.Persistence;
using DataAccess.Repositories.Contracts;
using Domain.Entities;

namespace DataAccess.Repositories.Implementations;

public class VetRepository : Repository<Vet>, IVetRepository
{
    public VetRepository(ApplicationDbContext context) : base(context)
    {
    }
}
