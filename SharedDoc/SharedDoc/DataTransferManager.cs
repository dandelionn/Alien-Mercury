using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedDoc
{
    public class DataTransferManager
    {
        ChatBox.ChatBox _chatBox;
        RichTextBox _richTextBox;
        Mutex _mutex;

        Communication.Transmitter transmitter;
        Communication.Receiver receiver;
        List<string> _dataBuffer;

        public DataTransferManager(ChatBox.ChatBox chatBox, RichTextBox richTextBox)
        {
            _mutex = chatBox.GetMutex();
            _chatBox = chatBox;
            _richTextBox = richTextBox;

            _dataBuffer = new List<string>();
            //transmitter = new Communication.Transmitter(1030, "25.51.103.170");
            //receiver = new Communication.Receiver(1030, UpdateControl);

            transmitter = new Communication.Transmitter(1030, "25.56.151.57");
            receiver = new Communication.Receiver(1030, UpdateControl);
           
            StartReceiver();
        }

        private void StartReceiver()
        {
            Thread thread = new Thread(x => receiver.StartListening());
            thread.Start();
        }

        public void EstablishConnections()
        {
            Thread clientMainThread = new Thread(x => transmitter.StartClient());
            clientMainThread.Start();           
        }

        public void CloseConnections()
        {
            transmitter.CloseConnection();
            receiver.CloseConnections();
        }

        private void UpdateControl(string data)
        {
            
            string chatBoxFlag = "<--ChatBox-->";
            string richTextBoxFlag = "<--RichTextBox-->";
            string eof = "<EOF>";

            data = data.Replace(eof, "");
            data = data.Replace(chatBoxFlag, " ");

            Console.WriteLine(data);

            if(data != String.Empty)
                UpdateChatBox(data);

            //System.Windows.Forms.MessageBox.Show(data);

            //if (data.StartsWith(chatBoxFlag))
            //{
            //    System.Windows.Forms.MessageBox.Show("AJUNGE");
            //    data = data.Substring(chatBoxFlag.Length);
            //    UpdateChatBox(data);
            //}
            //else
            //{
            //    if (data.StartsWith(richTextBoxFlag))
            //    {
            //        data = data.Substring(chatBoxFlag.Length);
            //        UpdateRichTextBox(data);
            //    }
            //} 
        }

        public void UpdateChatBox(string data)
        {
            _chatBox.PostMessage(data);
        }

        public void UpdateRichTextBox(string data)
        {

        }

        public void SendData(string data)
        {
            if (transmitter.isConnected())
            {
                try
                {
                    SendBufferedData();

                    transmitter.SendData(data);
                }
                catch(Exception)
                {
                    _dataBuffer.Add(data);
                }
            }
            else
            {
                //MessageBox.Show("Your partner is not connected.");
            }
        }

        public void SendBufferedData()
        {
            while (_dataBuffer.Count > 0)
            {
                transmitter.SendData(_dataBuffer[0]);
                _dataBuffer.RemoveAt(0);
            }
        }
    }
}
