using DataAccess.Persistence;
using DataAccess.Repositories.Contracts;
using Domain.Entities;

namespace DataAccess.Repositories.Implementations;

public class SpecialtyRepository : Repository<Specialty>, ISpecialtyRepository
{
    public SpecialtyRepository(ApplicationDbContext context) : base(context)
    {
    }
}
