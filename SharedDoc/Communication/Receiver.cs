using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Communication
{
    public class Receiver: ReceiverParameters
    {
        private static Mutex mutex = new Mutex();
        public delegate void UpdateObject(string data);
        UpdateObject Function;

        List<Socket> sockets;

        public Receiver(int port, UpdateObject function): base(port)
        {
            sockets = new List<Socket>();
            Function = function;
        }

        public void StartListening()
        {
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                sockets.Add(listener);

                while (true)
                {
                    Socket handler = listener.Accept();
                    sockets.Add(handler);

                    Thread thread = new Thread(x => DoWork(handler));
                    thread.Start();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DoWork(Socket handler)
        {
            try
            {
                while (handler.Connected == true)
                {
                    byte[] bytes = new byte[1024];
                    string data = null;

                    while (handler.Connected == true)
                    {
                        bytes = new byte[1024];

                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                    }

                    UpdateObjectOnMainThread(data);
                }
            }
            catch(Exception)
            {
                //throw new Exception("Application closed when handler is still in receiving state");
            }      
        }

        public void UpdateObjectOnMainThread(string data)
        {
            mutex.WaitOne();
            Function.Invoke(data);
            mutex.ReleaseMutex();
        }

        public void CloseConnection(string ip)
        {
            IPHostEntry ipHostInfo = Dns.Resolve(ip);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, Port);
            
            foreach (Socket socket in sockets)
            {
               
                if (socket.RemoteEndPoint ==  remoteEP)
                {
                    if (socket != null && socket.Connected == true)
                    {
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();

                        break;
                    }
                }
            }
        }

        public void CloseConnections()
        {
            foreach (Socket socket in sockets)
            {
                if (socket != null)
                {
                    if (socket.Connected == true)
                    {
                        socket.Shutdown(SocketShutdown.Both);  
                    }
                    socket.Close();
                }
            }
        }
    }
}
