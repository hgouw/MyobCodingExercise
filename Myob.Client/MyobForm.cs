﻿using System;
using System.Collections.Generic;
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
            dlgOpenFile.Filter = "CSV files (input.csv)|input.csv";
            dlgOpenFile.FilterIndex = 1;
            dlgOpenFile.RestoreDirectory = false;

            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                var filename = dlgOpenFile.FileNames.Select(f => f).First();
                var employees = ReadCsv(filename);
                var payslips = new List<PaySlip> { };
                foreach (var employee in employees)
                {
                    var payslip = new PaySlip { Employee = employee };
                    payslip.Process();
                    payslips.Add(payslip);
                }
                WriteCsv(payslips, filename.ToLower().Replace("input", "output"));
            }
        }
    }
}