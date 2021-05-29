            using System;
            using System.Text;
            using System.Text.RegularExpressions;
            using System.Threading;
            using NUnit.Framework;
            using OpenQA.Selenium;
            using OpenQA.Selenium.Chrome;
            using OpenQA.Selenium.Support.UI;

namespace TestMurano
    {
        [TestFixture]
        public class LogInTestCase
        {
            private IWebDriver driver;
            private StringBuilder verificationErrors;
                        private bool acceptNextAlert = true;

            [SetUp]
            public void SetupTest()
            {
                driver = new ChromeDriver("D:\\Program Files (x86)\\Google\\Chrome");
                                verificationErrors = new StringBuilder();
            }

            [TearDown]
            public void TeardownTest()
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                  
                }
                Assert.AreEqual("", verificationErrors.ToString());
            }

            [Test]
            public void LogInTestCaseTest()
            {
                driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
                driver.FindElement(By.Id("login-button")).Click();
                driver.FindElement(By.Id("Email")).Click();
                driver.FindElement(By.Id("Email")).Clear();
                driver.FindElement(By.Id("Email")).SendKeys("k.test01@mail.ru");
                driver.FindElement(By.Id("Password")).Click();
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys("TestPass001");
                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                
                try
                {
                    Assert.AreEqual("C# Online Compiler | .NET Fiddle", driver.Title);
                }
                catch (AssertionException e)
                {
                    verificationErrors.Append(e.Message);
                }
                /*try
                {
                    Assert.AreEqual("Konsta", driver.FindElement(By.Id("account-display-name")).Text);
                }
                catch (AssertionException e)
                {
                    verificationErrors.Append(e.Message);
                }*/
            }
            private bool IsElementPresent(By by)
            {
                try
                {
                    driver.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }

            private bool IsAlertPresent()
            {
                try
                {
                    driver.SwitchTo().Alert();
                    return true;
                }
                catch (NoAlertPresentException)
                {
                    return false;
                }
            }

            private string CloseAlertAndGetItsText()
            {
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    string alertText = alert.Text;
                    if (acceptNextAlert)
                    {
                        alert.Accept();
                    }
                    else
                    {
                        alert.Dismiss();
                    }
                    return alertText;
                }
                finally
                {
                    acceptNextAlert = true;
                }
            }
        }
    }
