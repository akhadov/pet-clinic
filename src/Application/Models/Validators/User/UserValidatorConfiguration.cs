﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Validators.User;

public static class UserValidatorConfiguration
{
    public const int MinimumUsernameLength = 5;

    public const int MaximumUsernameLength = 20;

    public const int MinimumPasswordLength = 6;

    public const int MaximumPasswordLength = 128;
}
