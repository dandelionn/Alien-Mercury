using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public class ReceiverParameters
    {
        public int Port { get; set; }
        public IPHostEntry ipHostInfo { get; set; }
        public IPAddress ipAddress { get; set; }
        public IPEndPoint localEndPoint { get; set; }
        public Socket listener { get; set; }

        public ReceiverParameters(int port)
        {
            Port = port;
            ipHostInfo = Dns.Resolve(Dns.GetHostName());

            foreach (IPAddress address in ipHostInfo.AddressList)
            {
                if (address.ToString().StartsWith("25."))
                {
                    ipAddress = address;
                    break;
                }
            }

            localEndPoint = new IPEndPoint(ipAddress, Port);
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void SetParameters(int port)
        {
            Port = port;
            ipHostInfo = Dns.Resolve(Dns.GetHostName());

            foreach (IPAddress address in ipHostInfo.AddressList)
            {
                if (address.ToString().StartsWith("25."))
                {
                    ipAddress = address;
                    break;
                }
            }

            localEndPoint = new IPEndPoint(ipAddress, Port);
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
    }
}
