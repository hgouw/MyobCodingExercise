using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Myob.BusinessLayer;
using static Myob.DataAccessLayer.InputOuput;

namespace Myob.Client
{
    public partial class frmMyob : Form
    {
        public frmMyob()
        {
            InitializeComponent();
        }

        private void btnPayslip_Click(object sender, EventArgs e)
        {
            this.dlgOpenFile.Filter = "CSV files (*.csv)|*.csv";
            this.dlgOpenFile.FilterIndex = 1;
            this.dlgOpenFile.RestoreDirectory = false;

            if (this.dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                var filenames = from f in this.dlgOpenFile.FileNames
                                select f;
                foreach (string filename in filenames)
                {
                    var employees = ReadCsv(filename);
                }
            }
        }
    }
}