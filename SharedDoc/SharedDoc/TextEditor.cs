using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedDoc
{
    public class TextEditor
    {
        public void PasteText(TabControlEx.TabControlEx tabControl)
        {
            RichTextBox richTextBox = GetRichTextBox(tabControl);
            richTextBox.Text = richTextBox.Text.Insert(richTextBox.SelectionStart, Clipboard.GetText());
        }

        public void CutText(TabControlEx.TabControlEx tabControl)
        {
            Clipboard.Clear();
            RichTextBox richTextBox = GetRichTextBox(tabControl);
            Clipboard.SetText(richTextBox.SelectedText);
            richTextBox.Text = richTextBox.Text.Remove(richTextBox.SelectionStart, richTextBox.SelectionLength);
        }

        public void CopyText(TabControlEx.TabControlEx tabControl)
        {
            Clipboard.Clear();
            RichTextBox richTextBox = GetRichTextBox(tabControl);
            Clipboard.SetText(richTextBox.SelectedText);
        }

        private RichTextBox GetRichTextBox(TabControlEx.TabControlEx tabControl)
        {
            return (tabControl.SelectedTab.Controls[0] as CodeEditor.CodeEditor).GetEditor();
        }
    }
}
