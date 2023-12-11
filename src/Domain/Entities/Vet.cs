using Domain.Common;

namespace Domain.Entities;

public class Vet : BaseEntity
{
    public virtual ICollection<Specialty> Specialties { get; set; } = new List<Specialty>();
}
