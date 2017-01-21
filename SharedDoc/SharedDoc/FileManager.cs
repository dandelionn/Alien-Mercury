using System;
using System.IO;
using System.Windows.Forms;

namespace SharedDoc
{
    public class FileManager
    {
        TabModifier _tabModifier;
        FileOperator _fileOperator;
        
        public FileManager()
        {
            _tabModifier = new TabModifier();
            _fileOperator = new FileOperator();
        }

        private RichTextBox GetRichTextBox(TabControlEx.TabControlEx tabControl)
        {
            return (tabControl.SelectedTab.Controls[0] as CodeEditor.CodeEditor).GetEditor();
        }

        private RichTextBox GetRichTextBox(TabPage tabPage)
        {
            return (tabPage.Controls[0] as CodeEditor.CodeEditor).GetEditor();
        }

        public void SaveAllFiles(TabControlEx.TabControlEx tabControl)
        {
            for (int i = 0; i < tabControl.TabPages.Count - 1; i++)
            {
                RichTextBox richTextBox = GetRichTextBox(tabControl.TabPages[i]);

                CreateFilePath(tabControl.TabPages[i]);


                _fileOperator.WriteToFile((string)tabControl.TabPages[i].Tag, richTextBox.Text);
            }
        }

        public void CreateFilePath(TabPage tabPage)
        {
            if (tabPage.Tag == null)
            {
                string saveDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Saved Files\");
                Directory.CreateDirectory(saveDirectory);

                string filename = "untitled.txt";
                int number = 0;

                while (File.Exists(saveDirectory + filename))
                {
                    filename = "untitled" + number.ToString() + ".txt";
                    number++;
                }

                tabPage.Tag = saveDirectory + filename;
            }
        }

        public bool SaveFile(TabPage tabPage, string fileName)
        {
            RichTextBox richTextBox = GetRichTextBox(tabPage);

            if (fileName != null)
            {
                string text = fileName.Substring(fileName.LastIndexOf('\\') + 1);
                tabPage.Text = _tabModifier.CreateTabTitle(text, 15, tabPage.Parent.Font);
                tabPage.Tag = fileName;

                _fileOperator.WriteToFile((string)tabPage.Tag, richTextBox.Text);
                return true;
            }
            else
            {
                if (tabPage.Tag != null)
                {
                    _fileOperator.WriteToFile((string)tabPage.Tag, richTextBox.Text);
                    return true;
                }
            }

            return false;
        }

        public void OpenFiles(TabControlEx.TabControlEx tabControl, string[] fileNames)
        {
            if (fileNames != null)
            {
                TabPage tabPage;
                string content;

                for (int i = 0; i < fileNames.Length; i++)
                {
                    tabPage = _tabModifier.AddNewTabPage(tabControl);
                    string text = fileNames[i].Substring(fileNames[i].LastIndexOf('\\') + 1);
                    tabPage.Text = _tabModifier.CreateTabTitle(text, 15, tabControl.Font);
                    tabPage.Tag = fileNames[i];

                    content = _fileOperator.ReadFile(fileNames[i]);
                    (tabPage.Controls[0] as CodeEditor.CodeEditor).GetEditor().Text = content;
                }
            }
        }
    }
}
