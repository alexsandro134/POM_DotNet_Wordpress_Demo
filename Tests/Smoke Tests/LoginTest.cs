using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POM_SELENIUM;

namespace Tests
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        [TestMethod]
        public void Admin_User_Can_Login()
        {
            Assert.IsTrue(DashboardPage.IsAt, "Failed to login");
        }
    }
}
