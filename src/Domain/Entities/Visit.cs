using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Visit : BaseAuditableEntity
{
    public DateTime VisitDate { get; set; }

    public string Description { get; set; }

    public long PetId { get; set; }

    public virtual Pet Pet { get; set; }
}
