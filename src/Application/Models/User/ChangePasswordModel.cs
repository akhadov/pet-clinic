﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.User;

public class ChangePasswordModel
{
    public string OldPassword { get; set; }

    public string NewPassword { get; set; }
}