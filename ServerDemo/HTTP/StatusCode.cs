using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDemo.HTTP
{
    public enum StatusCode
    {
        OK = 200,
        Found = 302,
        BadRequest = 400,
        Unauthorized = 401,
        NotFount = 404
    }
}
