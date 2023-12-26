﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.User;

public class CreateUserModel
{
    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
}

public class CreateUserResponseModel : BaseResponseModel { }
