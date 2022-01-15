using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHTTPServer
{
    public class HttpServer
    {
        private readonly IPAddress ipAddress;
        private readonly int port;
        private readonly TcpListener serverListener;

        public HttpServer(string _ipAddress,int _port)
        {
            ipAddress = IPAddress.Parse(_ipAddress);
            port = _port;
        }

        public void Start()
        {
            this.serverListener.Start();
            Console.WriteLine("Server listening...");

            while (true)
            { 
                var connection = serverListener.AcceptTcpClient();

                var networkStream = connection.GetStream();

                WriteResponce(networkStream, "Hello from the other side.");


                connection.Close();
            }

        }

        private void WriteResponce(NetworkStream networkStream, string message)
        {

            var content = "Hello from the other side";
            var contentLength = Encoding.UTF8.GetByteCount(content);

            var response = $@"HTTP/1.1 200 OK
Content-Type: text/plain; charset=UTF-8
Content-Length: {contentLength}

{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);

            networkStream.Write(responseBytes);

        }
    }


}
