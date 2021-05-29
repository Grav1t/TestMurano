using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestMurano.BaseClass;
using TestMurano.Utilities;


namespace TestMurano
{
    [TestFixture]
    public class LogInParallelBrowsers
    {
        IWebDriver driver;
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;
        [Test]
        public void LogInOutTestCaseTest1()//Positive test
        {
            var Driver = new BrowserUtilities().Init(driver);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("login-button")).Click();
            Driver.FindElement(By.Id("Email")).Click();
            Driver.FindElement(By.Id("Email")).Clear();
            Driver.FindElement(By.Id("Email")).SendKeys("k.test01@mail.ru");
            Driver.FindElement(By.Id("Password")).Click();
            Driver.FindElement(By.Id("Password")).Clear();
            Driver.FindElement(By.Id("Password")).SendKeys("TestPass001");
            Driver.FindElement(By.XPath("//form[@id='form0']/div[3]/div[2]/button")).Click();
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("Konsta", Driver.FindElement(By.XPath("//span[@id='account-display-name']")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("k.test01@mail.ru", Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div/span")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div/div/a/span[2]")).Click();
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div/div/ul/li[4]/a")).Click();
            Driver.Close();
        }
        [Test]
        public void LogInOutTestCaseTest2()//Wrong Password
        {
            var Driver = new BrowserUtilities().Init(driver);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("login-button")).Click();
            Driver.FindElement(By.Id("Email")).Click();
            Driver.FindElement(By.Id("Email")).Clear();
            Driver.FindElement(By.Id("Email")).SendKeys("k.test01@mail.ru");
            Driver.FindElement(By.Id("Password")).Click();
            Driver.FindElement(By.Id("Password")).Clear();
            Driver.FindElement(By.Id("Password")).SendKeys("TestPass01");
            Driver.FindElement(By.XPath("//form[@id='form0']/div[3]/div[2]/button")).Click();
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("Incorrect email or password.", Driver.FindElement(By.XPath("//span[@id='login-message']/div")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Driver.Close();

        }
        [Test]
        public void LogInOutTestCaseTest3()///Wrong Email
        {
            var Driver = new BrowserUtilities().Init(driver);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("login-button")).Click();
            Driver.FindElement(By.Id("Email")).Click();
            Driver.FindElement(By.Id("Email")).Clear();
            Driver.FindElement(By.Id("Email")).SendKeys("k.test001@mail.ru");
            Driver.FindElement(By.Id("Password")).Click();
            Driver.FindElement(By.Id("Password")).Clear();
            Driver.FindElement(By.Id("Password")).SendKeys("TestPass001");
            Driver.FindElement(By.XPath("//form[@id='form0']/div[3]/div[2]/button")).Click();
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("Incorrect email or password.", Driver.FindElement(By.XPath("//span[@id='login-message']/div")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Driver.Close();
        }
      
    }
}
