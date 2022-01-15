using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDemo.HTTP
{
    public class Responce
    {

        public Responce(StatusCode _statusCode)
        {
            StatusCode = _statusCode;

            this.Headers.Add("Server", "My Web Server");
            this.Headers.Add("Date", $"{DateTime.UtcNow:r}");
        }

        public StatusCode StatusCode { get; init; }
        public HeaderCollection Headers { get;} = new HeaderCollection();
        public string Body { get; set; }

    }
}
