using DataAccess.Persistence;
using DataAccess.Repositories.Contracts;
using Domain.Entities;

namespace DataAccess.Repositories.Implementations;

public class VisitRepository : Repository<Visit>, IVisitRepository
{
    public VisitRepository(ApplicationDbContext context) : base(context)
    {
    }
}
