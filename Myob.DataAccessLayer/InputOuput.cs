using System.Collections.Generic;
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
        /// Return the list of Employees Details from the Input Csv file
        /// </summary>
        /// <returns></returns>
        public static List<Employee> ReadCsv(string fullfilename)
        {
            var employees = new List<Employee> { };
            FileStream fileStream = new FileStream(fullfilename, FileMode.Open);
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
    }
}