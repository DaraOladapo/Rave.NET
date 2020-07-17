using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Rave.NET.API
{

    internal interface IRaveRequest<T1, T2> where T1 : RaveResponse<T2>, new() where T2 : class 
    {
        Task<T1> Request(HttpRequestMessage requestBody);
        Task<T0> Request<T0>(HttpRequestMessage requestBody);
    }
}
