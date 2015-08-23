using System;

namespace Myob.Helper
{
    /// <summary>
    /// Miscellaneous Calculation Helper Functions
    /// </summary>
    public static class Calculate
    {
        /// <summary>
        /// Calculate Monthly Gross Income
        /// </summary>
        /// <param name="annualSalary">Annual Salary</param>
        public static decimal GrossIncome(decimal annualSalary) => Math.Floor(annualSalary / 12);

        /// <summary>
        /// Calculate Monthly Income Tax (based on the ATO rates for 2012-13 financial year)
        /// </summary>
        /// <param name="taxableIncome">Taxable Income</param>
        public static decimal IncomeTax(decimal taxableIncome)
        {
            decimal incomeTax = 0;
            if ((0 <= taxableIncome) && (taxableIncome <= 18200))
            {
                incomeTax = 0;
            }
            else if ((18201 <= taxableIncome) && (taxableIncome <= 37000))
            {
                incomeTax = ((taxableIncome - 18200) * 0.19m) / 12;
            }
            else if ((37001 <= taxableIncome) && (taxableIncome <= 80000))
            {
                incomeTax = (3572 + (taxableIncome - 37000) * 0.325m) / 12;
            }
            else if ((80001 <= taxableIncome) && (taxableIncome <= 180000))
            {
                incomeTax = (17547 + (taxableIncome - 80000) * 0.37m) / 12;
            }
            else if (taxableIncome >= 180001)
            {
                incomeTax = (54547 + (taxableIncome - 180000) * 0.45m) / 12;
            }
            return Math.Ceiling(incomeTax);
        }

        /// <summary>
        /// Calculate Monthly Net Income
        /// </summary>
        /// <param name="grossIncome">Monthly Gross Income</param>
        /// <param name="incomeTax">Monthly Income Tax</param>
        public static decimal NetIncome(decimal grossIncome, decimal incomeTax) => grossIncome - incomeTax;

        /// <summary>
        /// Calculate Monthly Superannuation Contribution
        /// </summary>
        /// <param name="grossIncome">Monthly Gross Income</param>
        /// <param name="superRate">Superannuation Rate</param>
        public static decimal Super(decimal grossIncome, float superRate) => Math.Floor(grossIncome * (decimal)superRate);
    }
}