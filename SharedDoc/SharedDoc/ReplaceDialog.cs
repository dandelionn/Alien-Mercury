using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedDoc
{
    public partial class ReplaceDialog : Form
    {
        private RichTextBox _richTextBox;

        public ReplaceDialog(RichTextBox richTextBox)
        {
            _richTextBox = richTextBox;
            _richTextBox.ReadOnly = true;

            InitializeComponent();
        }

        private void buttonFindAndReplace_Click(object sender, EventArgs e)
        {
            _richTextBox.Text = _richTextBox.Text.Replace(txtBoxFind.Text, txtBoxReplace.Text);
        }

        private void ReplaceDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            _richTextBox.ReadOnly = false;
        }
    }
}
