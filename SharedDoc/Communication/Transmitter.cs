using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Communication
{
    public class Transmitter: TransmitterParameters
    {
        public Transmitter(int port, string ip) :base(port, ip)
        {
        
        }

        public void StartClient()
        {
            try
            {
                sender.Connect(remoteEP);
            }
            catch (ArgumentNullException ane)
            {
                MessageBox.Show("ArgumentNullException : " + ane.ToString());
            }
            catch (SocketException se)
            {
                MessageBox.Show("SocketException : " + se.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show("Unexpected exception : " + e.ToString());
            }
        }

        public void CloseConnection()
        {
            if (sender != null && sender.Connected == true)
            {
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();
            }
        }

        public void SendData(string data)
        {
            byte[] msg = Encoding.ASCII.GetBytes(data + "<EOF>");
            int bytesSent = sender.Send(msg);

            if (bytesSent == 0)
            {
                SendData(data);
            }
        }

        public bool isConnected()
        {
            return sender.Connected;
        }
    }
}
