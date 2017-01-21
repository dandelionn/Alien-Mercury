using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChatBox
{
    public partial class ChatBox: UserControl
    {
        public delegate int PostMessageExternal(string data);

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
            PostMessage();
        }

        private void editMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PostMessage();
            }
        }

        private void PostMessage()
        {
            PostMessageOut?.Invoke(editMessageBox.Text);

            _contentModifier.PostMessage();
        }
    }
}
