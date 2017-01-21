using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedDoc
{
    public partial class SemaphoreBar: UserControl
    {
        public void SetDataTransferManager(DataTransferManager dataTransferManager)
        {
            _dataTransferManager = dataTransferManager;
        }
        private DataTransferManager _dataTransferManager;

        public SemaphoreBar()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            _dataTransferManager.EstablishConnections();
        }

        private void buttonUnlock_Click(object sender, EventArgs e)
        {

        }

        private void buttonLock_Click(object sender, EventArgs e)
        {

        }
    }
}
