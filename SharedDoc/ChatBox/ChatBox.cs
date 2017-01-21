using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace ChatBox
{
    public partial class ChatBox: UserControl
    {
        Mutex mutex = new Mutex();

        public delegate void PostMessageExternal(string data);

        public Mutex GetMutex()
        {
            return mutex;
        }

        public void SetMessageSender(PostMessageExternal function)
        {
            PostMessageOut = function;
        }

        PostMessageExternal PostMessageOut;

        ContentModifier _contentModifier;
  
        public ChatBox()
        {
            InitializeComponent();

            _contentModifier = new ContentModifier(messageBox.GetEditor(), editMessageBox);       
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            PostMessageOut?.Invoke(editMessageBox.Text);
            PostMessage(editMessageBox.Text);

            editMessageBox.Text = String.Empty;
        }

        private void editMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                string chatBoxFlag = "<--ChatBox-->";

                PostMessageOut?.Invoke(chatBoxFlag + editMessageBox.Text);
                PostMessage(editMessageBox.Text);

                editMessageBox.Text = String.Empty;
            }
        }

        public void PostMessage(string editedText)
        {
            //mutex.WaitOne();

            _contentModifier.PostMessage(editedText);

            //mutex.ReleaseMutex();
        }
    }
}
