using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Pet : BaseAuditableEntity
{
    public string Name { get; set; }

    public DateTime BirthDate { get; set; }

    public long PetTypeId { get; set; }

    public virtual PetType PetType { get; set; }

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();

    public long OwnerId { get; set; }

    public virtual Owner Owner { get; set; }
}
