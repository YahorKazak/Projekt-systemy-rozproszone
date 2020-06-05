using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Collections.Generic;

namespace server

{
    class Program
    {
        static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static List<Socket> clients = new List<Socket>();
        static void Main(string[] args)
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, 2048));
            socket.Listen(2);

            socket.BeginAccept(AcceptCallBack,null);


            Console.ReadLine();
        }

        static void AcceptCallBack(IAsyncResult result)
        {
            Console.WriteLine("new");
            Socket client = socket.EndAccept(result);
            Thread thread = new Thread(HandleClient);
            thread.Start(client);

            clients.Add(client);

            socket.BeginAccept(AcceptCallBack, null);
        }
        static void HandleClient(object o)
        {
            Socket client = (Socket)o;
            MemoryStream ms = new MemoryStream(new byte[256],0,256,true,true);
            BinaryWriter bw = new BinaryWriter(ms);
            BinaryReader br = new BinaryReader(ms);

            while(true)
            {
                ms.Position = 0;
                try
                {
                    client.Receive(ms.GetBuffer());
                }
                catch 
                {
                    client.Shutdown(SocketShutdown.Both);
                    client.Disconnect(true);             
                    clients.Remove(client);
                    return;
                    
                }
               
                int code = br.ReadInt32();
                switch(code)
                {
                    case 0:
                        foreach (var c in clients)
                        {
                           
                                c.Send(ms.GetBuffer());
                            
                                                                                        
                        }
                    break;
                    case 1:
                        foreach (var c in clients)
                        {
                            c.Send(ms.GetBuffer());
                        }
                    break;
                    case 2:
                        foreach (var c in clients)
                        {
                            c.Send(ms.GetBuffer());
                        }
                    break;
                }
            }
        }
    }
}
