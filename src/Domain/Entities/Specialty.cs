using Domain.Common;

namespace Domain.Entities;

public class Specialty : BaseEntity
{
    public string Name { get; set; }

    protected virtual ICollection<Vet> Vets { get; set; }
}
