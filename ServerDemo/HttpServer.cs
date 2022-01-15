using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerDemo
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
            serverListener = new TcpListener(ipAddress,port);
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

                var requestText = this.ReadRequest(networkStream);

                Console.WriteLine(requestText);

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

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;

            var buffer = new byte[bufferLength];

            var totalBytes = 0;

            var requestBuilder = new StringBuilder();

            do
            {

                var bytesRead = networkStream.Read(buffer, 0, bufferLength);

                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {throw new InvalidOperationException("Request too large!");}

                requestBuilder.Append(Encoding.UTF8.GetString(buffer,0,bytesRead));

            } while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }

    }


}
