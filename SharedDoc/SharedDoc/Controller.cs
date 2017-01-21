
using System.Windows.Forms;

namespace SharedDoc
{
    public class Controller
    {
        FontModifier _fontModifier;
        Model _model;
        TextEditor _textEditor;
        TabModifier _tabModifier;


        public Controller()
        {
            _fontModifier = new FontModifier();
            _model = new Model();
            _textEditor = new TextEditor();
            _tabModifier = new TabModifier();
        }

        public LoginData GetLoginData()
        {
            return _model.GetLoginData();
        }

        public void SaveFileIntoDatabase(string fileName, string text)
        {
            _model.SaveFileIntoDatabase(fileName, text);
        }
     
        public void CreateNewFile(TabControlEx.TabControlEx tabControl)
        {
            _tabModifier.AddEmptyTabPage(tabControl);
        }

        public void SaveAllFiles(TabControlEx.TabControlEx tabControl)
        {
            _model.SaveAllFiles(tabControl);
        }

        public bool SaveFile(TabPage tabPage, string fileName)
        {
            return _model.SaveFile(tabPage, fileName);
        }

        public void OpenFiles(TabControlEx.TabControlEx tabControl, string[] fileNames)
        {
            _model.OpenFiles(tabControl, fileNames);
        }

        public void CutText(TabControlEx.TabControlEx tabControl)
        {
            _textEditor.CutText(tabControl);
        }

        public void CopyText(TabControlEx.TabControlEx tabControl)
        {
            _textEditor.CopyText(tabControl);
        }

        public void PasteText(TabControlEx.TabControlEx tabControl)
        {
            _textEditor.PasteText(tabControl);
        }

        public void SetCmbFontFamilies(ToolStripComboBox comboBox)
        {
            _fontModifier.SetCmbFontFamilies(comboBox);
        }

        public void SetCmbFontSize(ToolStripComboBox comboBox)
        {
            _fontModifier.SetCmbFontSize(comboBox);
        }

        public void ChangeFont(TabControl tabControl, ToolStripComboBox cmbBoxFontFamily, ToolStripComboBox cmbBoxFontSize)
        {
            _fontModifier.ChangeFont(tabControl, cmbBoxFontFamily, cmbBoxFontSize);
        }

        public void UpdateFontCmbBoxes(TabControlEx.TabControlEx tabControl, ToolStripComboBox cmbBoxFontFamily, ToolStripComboBox cmbBoxFontSize)
        {
            _fontModifier.UpdateFontCmbBoxes(tabControl, cmbBoxFontFamily, cmbBoxFontSize);
        }
    }
}
