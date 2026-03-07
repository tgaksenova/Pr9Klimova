using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pr9Klimova.Pages;

namespace Auth_Testing_Positive
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AuthTestMethodPositive()
        {
            var page = new AuthPage();
            Assert.IsFalse(page.Auth(" "," "));
        }
    }
}
