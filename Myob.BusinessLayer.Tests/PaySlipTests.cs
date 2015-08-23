using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Myob.BusinessLayer.Tests
{
    [TestClass()]
    public class PaySlipTests
    {
        private PaySlip payslip;

        [TestInitialize]
        public void Initialise()
        {
            payslip = new PaySlip { Employee = new Employee { Name = new Name { FirstName = "David", LastName = "Rudd" }, AnnualSalary = 60050, SuperRate = 0.09f, PaymentPeriod = "01 March - 31 March" } };
            payslip.Process();
        }

        [TestMethod()]
        public void ToCsv()
        {
            Assert.AreEqual(payslip.ToCsv(), "David Rudd,01 March - 31 March,5004,922,4082,450");
        }
    }
}