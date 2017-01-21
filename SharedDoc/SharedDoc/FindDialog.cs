using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SharedDoc
{
    public partial class FindDialog : Form
    {
        private List<int> _positions;
        private RichTextBox _richTextBox;
        private int _currentPosition;
        private int _nrOfCompletedWorkers;
        List<BackgroundWorker> workers;

        public FindDialog(RichTextBox richTextBox)
        {
            _currentPosition = -1;
            _positions = new List<int>();
            _richTextBox = richTextBox;
            richTextBox.ReadOnly = true;

          
            InitializeComponent();

            CreateWorkers();
        }

        public void CreateWorkers()
        {
            workers = new List<BackgroundWorker>();
            for (int i = 0; i < GetNumberOfCores(); i++)
            {
                BackgroundWorker backgroundWorker = new BackgroundWorker();

                backgroundWorker.DoWork += new DoWorkEventHandler(BackgroundWorker_DoWork);
                backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorker_RunWorkerCompleted);

                workers.Add(backgroundWorker);             
            }
        }

        public int GetNumberOfCores()
        {
            int coreCount = 0;

            foreach (var item in new System.Management.ManagementObjectSearcher("Select NumberOfCores from Win32_Processor").Get())
            {
                coreCount += int.Parse(item["NumberOfCores"].ToString());
            }

            return coreCount;
        }

        public void FindText()
        {
            int nrOfCores = GetNumberOfCores();
            int sectionLength = _richTextBox.TextLength / nrOfCores;

            for (int i = 0; i < nrOfCores ; i++)
            {
                workers[i].RunWorkerAsync(BuildFindData(i, sectionLength));
            }
        }

        public FindData BuildFindData(int coreNumber, int sectionLength)
        {
            string text;
            int startIndex = coreNumber * sectionLength;

            if (_richTextBox.TextLength - startIndex < sectionLength)
            {
                startIndex -= (txtBoxFind.TextLength - 1);
                text = _richTextBox.Text.Substring(startIndex, _richTextBox.TextLength - startIndex);
            }
            else
            {
                if (startIndex >= txtBoxFind.TextLength - 1)
                {
                    startIndex -= (txtBoxFind.TextLength - 1);
                    text = _richTextBox.Text.Substring(startIndex, sectionLength + (txtBoxFind.TextLength - 1));
                }
                else
                {
                    text = _richTextBox.Text.Substring(startIndex, sectionLength);
                }
            }

            return new FindData(startIndex, text, txtBoxFind.Text);
        }

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            TextFinder textFinder = new TextFinder();
            FindData findData = e.Argument as FindData;
            List<int> positions = textFinder.Find(findData.TextToFind, findData.Text);

            for (int i = 0; i < positions.Count; i++)
            {
                positions[i] += findData.StartPosition;
            }

            foreach (int pos in positions)
            {
                Console.WriteLine(pos);    
            }

            e.Result = positions;
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _nrOfCompletedWorkers++;
            _positions = _positions.Union(e.Result as List<int>).ToList();
            _positions.Sort();

            if (_nrOfCompletedWorkers == workers.Count)
            {
                SelectPosition(++_currentPosition);
                _nrOfCompletedWorkers = 0;
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            _positions.Clear();
            _currentPosition = -1;
            _nrOfCompletedWorkers = 0;
           
            FindText();
        }

        private void SelectPosition(int index)
        {
            _richTextBox.Select(_positions[index], txtBoxFind.TextLength);
            this.Owner.Activate();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if(_currentPosition < _positions.Count - 1)
            {
                SelectPosition(++_currentPosition);
            }
            else
            {
                if (_currentPosition >= 0)
                {
                    SelectPosition(_positions.Count - 1);
                }
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (_currentPosition > 0)
            {
                SelectPosition(--_currentPosition);
            }
            else
            {
                if (_currentPosition >= 0)
                {
                    SelectPosition(0);
                }
            }
        }

        private void FindDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            _richTextBox.ReadOnly = false;
        }
    }
}
