using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.User;

public class ConfirmEmailModel
{
    public string UserId { get; set; }

    public string Token { get; set; }
}

public class ConfirmEmailResponseModel
{
    public bool Confirmed { get; set; }
}