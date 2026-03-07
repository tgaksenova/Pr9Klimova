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
        //private static App _app;               
      
        [TestMethod]
        public void AuthTestMethodPositive()
        {
            //_app = new App();
            //_app.InitializeComponent();  // Загружает App.xaml ресурсы
           var page = new AuthPage();
            //var dict = new ResourceDictionary();
            //dict.Source = new Uri("Dictionary1.xaml", UriKind.Relative);  // Путь к вашему RD
            //page.Resources.MergedDictionaries.Add(dict);
            var myResourceDictionary = new ResourceDictionary
            {
                Source = new Uri("/Pr9Klimova;component../Pr9Klimova/Dicrionary1.xaml", UriKind.RelativeOrAbsolute)
            };
            Assert.IsFalse(page.Auth(" "," "));
        }
    }
}
