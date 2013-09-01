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
            while (true)
            {
                TcpClient client = agentServer.AcceptTcpClient();
                TcpClient agentClient = new TcpClient("192.168.80.10", 5008);
                NetworkStream streamAgent = agentClient.GetStream();
                stream = client.GetStream();
                stream.BeginRead(bytesSend, 0, bytesSend.Length, Callback, streamAgent);
            }
        }
        private static void Callback(IAsyncResult ar)
        {

            String dataSend = null;

            Byte[] bytesReceive = new Byte[1024];
            String dataReceive = null;
            int i;
            if ((i = stream.EndRead(ar)) != 0)
            {
                dataSend = System.Text.Encoding.UTF8.GetString(bytesSend, 0, i);
                Output("C-S", bytesSend, i);
                Output("C-S", dataSend);
                NetworkStream streamAgent = (NetworkStream)ar.AsyncState;


                // Send the message to the connected TcpServer.
                streamAgent.Write(bytesSend, 0, i);
                int j = streamAgent.Read(bytesReceive, 0, bytesReceive.Length);

                dataReceive = System.Text.Encoding.UTF8.GetString(bytesReceive, 0, j);
                Output("S-C", bytesReceive, j);
                Output("S-C", dataReceive);
                stream.Write(bytesReceive, 0, j);
                stream.BeginRead(bytesSend, 0, bytesSend.Length, Callback, streamAgent);
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
