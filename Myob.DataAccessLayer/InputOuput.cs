﻿using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Myob.BusinessLayer;

namespace Myob.DataAccessLayer
{
    /// <summary>
    /// Input/Ouput
    /// </summary>
    public static class InputOuput
    {
        /// <summary>
        /// Read the list of Employees Details from the given filename
        /// </summary>
        /// <returns></returns>
        public static List<Employee> ReadCsv(string filename)
        {
            var employees = new List<Employee> { };
            FileStream fileStream = new FileStream(filename, FileMode.Open);
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    string[] data = line.Split(',');
                    var employee = new Employee
                    {
                        Name = new Name { FirstName = data[0], LastName = data[1] },
                        AnnualSalary = decimal.Parse(data[2]),
                        SuperRate = float.Parse(data[3].TrimEnd(CultureInfo.CurrentCulture.NumberFormat.PercentSymbol.ToCharArray())) / 100f,
                        PaymentPeriod = data[4]
                    };
                    employees.Add(employee);
                    line = streamReader.ReadLine();
                };
            }
            return employees;
        }

        /// <summary>
        /// Write the list of Employee Payslips into the given filename
        /// </summary>
        public static void WriteCsv(List<PaySlip> payslips, string filename)
        {
            FileStream fileStream = new FileStream(filename, FileMode.OpenOrCreate);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            foreach (var payslip in payslips)
            {
                streamWriter.WriteLine(payslip.ToCsv());
            }
            streamWriter.Close();
        }
    }
}