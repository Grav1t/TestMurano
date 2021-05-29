using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestMurano.BaseClass;



namespace TestMurano2

{
    [TestFixture]

    public class TestClass : BaseTest

    {
        [Test]
        public void Test1()
        {
            driver.FindElement(By.Id("login-button")).Click();
            IWebElement logInButton = driver.FindElement(By.Id("Email"));
            logInButton.SendKeys("k.test01@mail.ru");

        }
    }
}