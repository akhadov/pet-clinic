using Domain.Common;

namespace Domain.Entities;

public class Visit : BaseAuditableEntity
{
    public DateTime VisitDate { get; set; }

    public string Description { get; set; }

    public long PetId { get; set; }

    public virtual Pet Pet { get; set; }
}
