using ServerDemo.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDemo.Responces
{
    internal class UnauthorizedResponse : Response
    {
        public UnauthorizedResponse() : base(StatusCode.Unauthorized)
        {
        }
    }
}
