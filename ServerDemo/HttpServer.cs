using ServerDemo.HTTP;
using ServerDemo.Routing;
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

        private readonly RoutingTable routingTable;

        public HttpServer(string _ipAddress,int _port,Action<IRoutingTable> routingTableConfiguration)
        {
            ipAddress = IPAddress.Parse(_ipAddress);
            port = _port;
            serverListener = new TcpListener(ipAddress,port);

            routingTableConfiguration(this.routingTable = new RoutingTable());
        }

        public HttpServer(int _port, Action<IRoutingTable> routingTable)
            :this("127.0.0.1",_port, routingTable)
        {
        }

        public HttpServer(Action<IRoutingTable> routingTable)
            : this(2505, routingTable)
        {
        }


        public void Start()
        {
            this.serverListener.Start();
            Console.WriteLine("Server listening...");

            while (true)
            { 
                var connection = serverListener.AcceptTcpClient();

                var networkStream = connection.GetStream();

                var requestText = this.ReadRequest(networkStream);

                Console.WriteLine(requestText);

                var request = Request.Parse(requestText);

                var response = this.routingTable.MatchRequest(request);

                WriteResponce(networkStream, response);

                connection.Close();
            }

        }

        private void WriteResponce(NetworkStream networkStream, Response response)
        {

            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

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
