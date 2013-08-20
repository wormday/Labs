using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;

namespace SocketAgent
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.Sockets.TcpClient agentClient = new TcpClient("192.168.80.10", 5008);

            System.Net.Sockets.TcpListener agentServer = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Any, 5008);

            agentServer.Start();

            while (true)
            {
                TcpClient client = agentServer.AcceptTcpClient();

                Byte[] bytesSend = new Byte[1024];
                String dataSend = null;

                Byte[] bytesReceive = new Byte[1024];
                String dataReceive = null;

                NetworkStream stream = client.GetStream();
                NetworkStream streams = agentClient.GetStream();
                int i;
                // Loop to receive all the data sent by the client.
                while ((i = stream.Read(bytesSend, 0, bytesSend.Length)) != 0)
                {
                    // Translate data bytes to a ASCII string.
                    dataSend = System.Text.Encoding.UTF8.GetString(bytesSend, 0, i);
                    Output("C-S", bytesSend, i);
                    Output("C-S", dataSend);


                    NetworkStream streamAgent = agentClient.GetStream();
                    // Send the message to the connected TcpServer.
                    streamAgent.Write(bytesSend, 0, i);
                    int j = streamAgent.Read(bytesReceive, 0, bytesReceive.Length);

                    dataReceive = System.Text.Encoding.UTF8.GetString(bytesReceive, 0, j);
                    Output("S-C", bytesReceive, j);
                    Output("S-C", dataReceive);
                    stream.Write(bytesReceive, 0, j);

                }
                // Shutdown and end connection
                client.Close();
            }
        }
        private static void Output(string type, string str)
        {
            Console.WriteLine(type +":"+ str);
        }
        private static void Output(string type, byte[] data,int length)
        {
            Console.Write(type + ":");
            for (int i = 0; i < length; i++)
            {
                Console.Write(string.Format("{0}|",data[i]));
            }
            Console.WriteLine();
        }
    }
}
