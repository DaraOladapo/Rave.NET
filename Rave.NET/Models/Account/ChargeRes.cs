using System;
using System.Collections.Generic;
using System.Text;
using Rave.NET.API;
using Rave.NET.Models.Account;

namespace Rave.NET.Models.Account
{
    public class ChargeRes<T> : RaveResponse<T> where T : ResponseData
    {
    }
}
