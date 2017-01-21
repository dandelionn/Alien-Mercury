using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace SharedDoc
{
    public partial class SharedDoc : Form
    {

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        Controller _controller;
        private DataTransferManager _dataTransferManager;

        public SharedDoc()
        {
            _controller = new Controller();

            LoginDialog loginDialog = new LoginDialog(_controller.GetLoginData());
            loginDialog.ShowDialog();

            InitializeComponent();


            MakeInitialSettings();
        }

        private void MakeInitialSettings()
        {
            
            _controller.SetCmbFontFamilies(cmbBoxFontFamily);
            _controller.SetCmbFontSize(cmbBoxFontSize);

            tabControl.OnRemoveTabPage = OnRemoveTabPage;
            tabControl.AddTabPage = _controller.CreateNewFile;

            _dataTransferManager = new DataTransferManager(chatBox, null);

            semaphoreBar1.SetDataTransferManager(_dataTransferManager);

            chatBox.SetMessageSender(_dataTransferManager.SendData);
        }

        private bool OnRemoveTabPage(int index)
        {
                return SaveFile();
        }
        
        private void buttonFind_Click(object sender, EventArgs e)
        {
            if (tabControl.Controls.Count > 1)
            {
                DialogFormCreator.CreateFindDialog(tabControl, this);
            }
        }

        private void buttonSaveAll_Click(object sender, EventArgs e)
        {
            if (tabControl.Controls.Count > 1)
            {
                _controller.SaveAllFiles(tabControl);
            }
        }

        private bool SaveFile()
        {
            TabPage tabPage = tabControl.SelectedTab;

            string fileName = null;

            if (tabPage.Tag == null)
            {
                fileName = DialogFormCreator.CreateSaveFileDialog();
            }

            RichTextBox richTextBox = (tabControl.SelectedTab.Controls[0] as CodeEditor.CodeEditor).GetEditor();
            _controller.SaveFileIntoDatabase(tabPage.Text, richTextBox.Text);





































            return _controller.SaveFile(tabPage, fileName);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (tabControl.Controls.Count > 1)
            {
                SaveFile();
            }
        }

        private void FileOpen()
        {
            string[] fileNames = DialogFormCreator.CreateOpenFileDialog();
            _controller.OpenFiles(tabControl, fileNames);
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            FileOpen();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            _controller.CreateNewFile(tabControl);
        }
     
        public void SaveBeforeExitDialog()
        {
            bool value = DialogFormCreator.CreateSaveBeforeExitDialog();
            if (value == true)
            {
                buttonSaveAll_Click(null, null);////watch what happens here  file with no path at tag won't be saved
            }
        }

        private void SharedDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            _dataTransferManager.CloseConnections();
            if (tabControl.Controls.Count > 1)
            {
                SaveBeforeExitDialog();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileOpen();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.Controls.Count > 1)
            {
                SaveFile();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.Controls.Count > 1)
            {
                _controller.CreateNewFile(tabControl);
            }
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.Controls.Count > 1)
            {
                _controller.SaveAllFiles(tabControl);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.Controls.Count > 1)
            {
                tabControl.CloseTab(tabControl.SelectedIndex);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
  
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.Controls.Count > 1)
            {
                DialogFormCreator.CreateFindDialog(tabControl, this);
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.Controls.Count > 1)
            {
                _controller.CutText(tabControl);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.Controls.Count > 1)
            {
                _controller.CopyText(tabControl);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.Controls.Count > 1)
            {
                _controller.PasteText(tabControl);
            }
        }

        private void replaceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (tabControl.Controls.Count > 1)
            {
                DialogFormCreator.CreateReplaceDialog(tabControl);
            }
        }

        private void cmbBoxFontFamily_TextChanged(object sender, EventArgs e)
        {
            _controller.ChangeFont(tabControl, cmbBoxFontFamily, cmbBoxFontSize);
        }

        private void cmbBoxFontSize_TextChanged(object sender, EventArgs e)
        {
            _controller.ChangeFont(tabControl, cmbBoxFontFamily, cmbBoxFontSize);
        }

        public void UnregisterEvents()
        {
            cmbBoxFontFamily.TextChanged -= cmbBoxFontFamily_TextChanged;
            cmbBoxFontSize.TextChanged -= cmbBoxFontSize_TextChanged;
        }

        public void RegisterEvents()
        {
            cmbBoxFontFamily.TextChanged += cmbBoxFontFamily_TextChanged;
            cmbBoxFontSize.TextChanged += cmbBoxFontSize_TextChanged;
        }

        private void tabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if(e.TabPage == tabControl.PlusButton)
            {
                e.Cancel = true;
            }
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl.Controls.Count > 1)
            {
                UnregisterEvents();

                _controller.UpdateFontCmbBoxes(tabControl, cmbBoxFontFamily, cmbBoxFontSize);

                RegisterEvents();
            }
        }

        private void tabControl_ControlAdded(object sender, ControlEventArgs e)
        {
            if (tabControl.Controls.Count > 1)
            {
                UnregisterEvents();

                _controller.UpdateFontCmbBoxes(tabControl, cmbBoxFontFamily, cmbBoxFontSize);

                RegisterEvents();
            }
        }
    }
}
