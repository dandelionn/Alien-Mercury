using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedDoc
{
    public static class DialogFormCreator
    {
        public static void CreateFindDialog(TabControlEx.TabControlEx tabControl, Form owner)
        {
            RichTextBox richTextBox = GetRichTextBox(tabControl);
            FindDialog findDialog = new FindDialog(richTextBox);
            findDialog.Location = new Point(richTextBox.Location.X + richTextBox.Width - findDialog.Width + 22,
                                            richTextBox.Location.Y + 98);

            findDialog.Owner = owner;

            findDialog.Show();
        }



        public static void CreateReplaceDialog(TabControlEx.TabControlEx tabControl)
        {
            RichTextBox richTextBox = (tabControl.SelectedTab.Controls[0] as CodeEditor.CodeEditor).GetEditor();
            ReplaceDialog replaceDialog = new ReplaceDialog(richTextBox);
            replaceDialog.Location = new Point(richTextBox.Location.X + richTextBox.Width - replaceDialog.Width + 22,
                                            richTextBox.Location.Y + 98);

            replaceDialog.Show();
        }


        public static string[] CreateOpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files|*.txt|Cpp Files|*.cpp|All files(*.*)| *.*";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileNames;
            }

            return null;          
        }

        public static string CreateSaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files|*.txt|Cpp Files|*.cpp|All files(*.*)| *.*";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }

            return null;
        }

        public static bool CreateSaveBeforeExitDialog()
        {
            DialogResult messageBoxResult = System.Windows.Forms.MessageBox.Show("Save file before exit?", "Application exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (messageBoxResult == DialogResult.Yes)
            {
                return true;    
            }

            return false;
        }

        private static RichTextBox GetRichTextBox(TabControlEx.TabControlEx tabControl)
        {
            return (tabControl.SelectedTab.Controls[0] as CodeEditor.CodeEditor).GetEditor();
        }
    }
}
