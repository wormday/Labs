using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace SocketAgent
{
    class Program
    {
        private static NetworkStream stream;
        private static Byte[] bytesSend = new Byte[1024];
        static void Main(string[] args)
        {
            System.Net.Sockets.TcpListener agentServer = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Any, 350);
            agentServer.Start();
            int i = 0;
            while (true)
            {
                new Server(agentServer.AcceptTcpClient(),i);
                i++;
            }
        }
        public class Server
        {
            private TcpClient _TcpClient;
            private TcpClient agentClient = new TcpClient("192.168.80.10", 5008);
            private byte[] receiveBuffer;
            private int _ID;
            public Server(TcpClient tcpClient,int id)
            {
                _ID = id;
                _TcpClient = tcpClient;
                receiveBuffer = new byte[_TcpClient.ReceiveBufferSize];
                _TcpClient.GetStream().BeginRead(receiveBuffer, 0, _TcpClient.ReceiveBufferSize, Receive, null);
                
            }
            public void Receive(IAsyncResult ir)
            {
                int i = _TcpClient.GetStream().EndRead(ir);
                if (i > 0)
                {
                    string str = System.Text.ASCIIEncoding.ASCII.GetString(receiveBuffer, 0, i);
                    Console.WriteLine(string.Format("{0}|{1}|{2}",_ID,"CA",str));
                    agentClient.GetStream().BeginWrite(receiveBuffer, 0, i, Send, null);
                    Console.WriteLine(string.Format("{0}|{1}|{2}", _ID, "AS", ""));
                    
                }
            }
            public void Send(IAsyncResult ir)
            {
                agentClient.GetStream().EndWrite(ir);
                agentClient.GetStream().BeginRead(receiveBuffer, 0, _TcpClient.ReceiveBufferSize, Receive2, null);
            }
            public void Receive2(IAsyncResult ir)
            {
                int i = agentClient.GetStream().EndRead(ir);
                if (i > 0)
                {
                    string str = System.Text.ASCIIEncoding.ASCII.GetString(receiveBuffer, 0, i);
                    Console.WriteLine(string.Format("{0}|{1}|{2}", _ID, "SA", str));
                    _TcpClient.GetStream().BeginWrite(receiveBuffer, 0, i, Send2, null);
                    Console.WriteLine(string.Format("{0}|{1}|{2}", _ID, "AC", ""));
                }
            }
            public void Send2(IAsyncResult ir)
            {
                _TcpClient.GetStream().EndWrite(ir);
                _TcpClient.GetStream().BeginRead(receiveBuffer, 0, _TcpClient.ReceiveBufferSize, Receive, null);
            }
        }
        private static void Output(string type, string str)
        {
            Console.WriteLine(type + ":" + str);
        }
        private static void Output(string type, byte[] data, int length)
        {
            Console.Write(type + ":");
            for (int i = 0; i < length; i++)
            {
                Console.Write(string.Format("{0}|", data[i]));
            }
            Console.WriteLine();
        }
    }
}
