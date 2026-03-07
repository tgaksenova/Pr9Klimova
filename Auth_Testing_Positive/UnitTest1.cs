using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pr9Klimova;
using Pr9Klimova.Pages;
using System;
using System.Windows;

namespace Auth_Testing_Positive
{
    [TestClass]
    public class UnitTest1
    {
        private static App _app;

        [TestMethod]
        public void AuthTestMethodPositive()
        {
            _app = new App();
            _app.InitializeComponent();  // Загружает App.xaml ресурсы
            var page = new AuthPage();           
            Assert.IsFalse(page.Auth(" "," "));
        }
    }
}
