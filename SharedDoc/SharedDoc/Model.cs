using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedDoc
{
    public class Model
    {
        FileManager _fileManager;
        DatabaseConnector _databaseConnector;

        public Model()
        {
            _fileManager = new FileManager();
            _databaseConnector = new DatabaseConnector();
        }

        public void SaveFileIntoDatabase(string fileName, string text)
        {
            _databaseConnector.SaveFileIntoDatabase(fileName, text);
        }
        public void SaveAllFiles(TabControlEx.TabControlEx tabControl)
        {
            _fileManager.SaveAllFiles(tabControl);
        }

        public bool SaveFile(TabPage tabPage, string fileName)
        {
            return _fileManager.SaveFile(tabPage, fileName);
        }

        public void OpenFiles(TabControlEx.TabControlEx tabControl, string[] fileNames)
        {
            _fileManager.OpenFiles(tabControl, fileNames);
        }

        public LoginData GetLoginData()
        {
            return _databaseConnector.GetLoginData();
        }
    }
}
