using ServerDemo.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDemo.Responces
{
    public class NotFoundResponse : Response
    {
        public NotFoundResponse() : base(StatusCode.NotFound)
        {
        }
    }
}
