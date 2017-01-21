using System;
using System.IO;

namespace SharedDoc
{
    public class FileOperator
    {
        public void WriteToFile(string filename, string contents)
        {
            try
            {
                File.WriteAllText(filename, PrepareText(contents));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: Could not write to the specified file. Original error: " + ex.Message);
            }
        }

        private string PrepareText(string contents)
        {
            contents = contents.Replace("\r", "");
            contents = contents.Replace("\n", Environment.NewLine);

            return contents;
        }

        public string ReadFile(string filename)
        {
            try
            {
                return File.ReadAllText(filename);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }

            return "";
        }

        public string[] ReadAllLines(string filename)
        {
            try
            {
                return File.ReadAllLines(filename);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }

            return null;
        }
    }
}
