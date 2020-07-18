using System;
using System.Collections.Generic;
using System.Text;
using Rave.NET.API;

namespace Rave.NET.Models.Card
{
    public class ChargeRes<T> : RaveResponse<T> where T : ResponseData
    {
        public override T Data { get ;  set ; }
    }
}
