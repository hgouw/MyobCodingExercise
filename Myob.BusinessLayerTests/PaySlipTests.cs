using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Myob.BusinessLayer.Tests
{
    [TestClass()]
    public class PaySlipTests
    {
        private PaySlip payslip;

        [TestInitialize]
        public void Initialize()
        {
            payslip = new PaySlip { Employee = new Employee { Name = new Name { FirstName = "David", LastName = "Rudd" }, AnnualSalary = 60050, SuperRate = 0.09f } };
            payslip.Process();
        }

        [TestMethod()]
        public void ToCsv()
        {
            Assert.AreEqual(payslip.ToString(), "xxx");
        }
    }
}