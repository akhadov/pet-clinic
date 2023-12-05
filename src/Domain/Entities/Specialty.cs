﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Specialty : BaseEntity
{
    public string Name { get; set; }

    protected virtual ICollection<Vet> Vets { get; set; }
}