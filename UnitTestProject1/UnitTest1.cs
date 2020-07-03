using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Racing.Models;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckAli()
        {
            Ali a = new Ali();
            int money = a.GetMoney();
            Assert.AreEqual(money, 50);

        }
        [TestMethod]
        public void CheckBob()
        {

            Bob b = new Bob();
            int money = b.GetMoney();
            Assert.AreEqual(money, 50);

        }
        [TestMethod]
        public void CheckJoe()
        {
            Joe a = new Joe();
            int money = a.GetMoney();
            Assert.AreEqual(money, 50);

        }
    }
}
