using System.Net.Sockets;
using System;
using System.Net;
using System.Net.Sockets;

namespace TankServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            int port = 1234;
            IPEndPoint address = new IPEndPoint(ip,port);
            serverSocket.Bind(address);

            serverSocket.Listen(1024);

            Console.WriteLine("Server start to listen");

            while(true)
            {
                Socket client = serverSocket.Accept();
                Console.WriteLine("Receive to client");

                byte[] recvBuf = new byte[1024];
                int count = client.Receive(recvBuf);
                string str = System.Text.Encoding.UTF8.GetString(recvBuf,0,count);
                Console.WriteLine(str);

                byte[] sendBuf = System.Text.Encoding.Default.GetBytes("server echo :"+str);
                client.Send(sendBuf);
            }
        }
    }
}
