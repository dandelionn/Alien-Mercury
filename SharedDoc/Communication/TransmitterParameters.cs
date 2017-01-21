using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Communication
{
    public class TransmitterParameters
    {
        public int Port { get; set; }
        public IPHostEntry ipHostInfo { get; set; }
        public IPAddress ipAddress { get; set; }
        public IPEndPoint remoteEP { get; set; }
        public Socket sender { get; set; }

        public TransmitterParameters(int port, string ip)
        {
            Port = port;
            ipHostInfo = Dns.Resolve(ip);
            ipAddress = ipHostInfo.AddressList[0];
            remoteEP = new IPEndPoint(ipAddress, Port);
            sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void SetParameters(int port, string ip)
        {
            Port = port;
            ipHostInfo = Dns.Resolve(ip);
            ipAddress = ipHostInfo.AddressList[0];
            remoteEP = new IPEndPoint(ipAddress, Port);
            sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
    }
}
