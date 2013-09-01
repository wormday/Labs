using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace SocketServer
{
    class Program
    {

        static void Main(string[] args)
        {
            System.Net.IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8989);
            TcpListener listener = new TcpListener(ip);
            listener.Start();

            while (true)
            {
                new Server(listener.AcceptTcpClient());
            }
        }
    }
    public class Server
    {
        private TcpClient _TcpClient;
        private byte[] receiveBuffer;
        public Server(TcpClient tcpClient)
        {
            _TcpClient = tcpClient;
            receiveBuffer = new byte[_TcpClient.ReceiveBufferSize];

            _TcpClient.GetStream().BeginRead(receiveBuffer, 0, _TcpClient.ReceiveBufferSize,Receive, null);
        }
        public void Receive(IAsyncResult ir)
        {
            int i = _TcpClient.GetStream().EndRead(ir);
            if (i> 0)
            {
                string str=System.Text.ASCIIEncoding.ASCII.GetString(receiveBuffer,0,i);
                Console.WriteLine(str);
                _TcpClient.GetStream().BeginRead(receiveBuffer, 0, _TcpClient.ReceiveBufferSize, Receive, null);
            }
        }
    }
}
