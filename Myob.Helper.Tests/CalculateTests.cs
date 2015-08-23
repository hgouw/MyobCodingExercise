using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Myob.Helper.Tests
{
    [TestClass()]
    public class CalculateTests
    {
        [TestMethod()]
        public void GrossIncomeTest()
        {
            Assert.AreEqual(Calculate.GrossIncome(60050), 5004);
        }

        [TestMethod()]
        public void IncomeTaxTest()
        {
            Assert.AreEqual(Calculate.IncomeTax(60050), 922);
        }

        [TestMethod()]
        public void NetIncomeTest()
        {
            Assert.AreEqual(Calculate.NetIncome(5004, 922), 4082);
        }

        [TestMethod()]
        public void SuperTest()
        {
            Assert.AreEqual(Calculate.Super(5004, 0.09f), 450);
        }
    }
}