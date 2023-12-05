using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Owner : BaseEntity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Address { get; set; }

    public string City { get; set; }

    public string Telephone { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();

}
