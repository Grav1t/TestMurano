            using System;
            using System.Text;
            using System.Text.RegularExpressions;
            using System.Threading;
            using NUnit.Framework;
            using OpenQA.Selenium;
            using OpenQA.Selenium.Chrome;
            using OpenQA.Selenium.Support.UI;
using TestMurano.BaseClass;


namespace TestMurano
    {
        [TestFixture]
        public class LogInTestCase : BaseTest
        {
            private StringBuilder verificationErrors;
            private bool acceptNextAlert = true;
                   
        

        [Test]
        public void LogInOutTestCaseTest1()//Positive test
        {
            {
                driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
                driver.FindElement(By.Id("login-button")).Click();
                driver.FindElement(By.Id("Email")).Click();
                driver.FindElement(By.Id("Email")).Clear();
                driver.FindElement(By.Id("Email")).SendKeys("k.test01@mail.ru");
                driver.FindElement(By.Id("Password")).Click();
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys("TestPass001");
                driver.FindElement(By.XPath("//form[@id='form0']/div[3]/div[2]/button")).Click();
                Thread.Sleep(2000);
                try
                {
                    Assert.AreEqual("Konsta", driver.FindElement(By.XPath("//span[@id='account-display-name']")).Text);
                }
                catch (AssertionException e)
                {
                    verificationErrors.Append(e.Message);
                }
                try
                {
                    Assert.AreEqual("k.test01@mail.ru", driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div/span")).Text);
                }
                catch (AssertionException e)
                {
                    verificationErrors.Append(e.Message);
                }
                try
                {
                    Assert.AreEqual("C# Online Compiler | .NET Fiddle", driver.Title);
                }
                catch (AssertionException e)
                {
                    verificationErrors.Append(e.Message);
                }
                driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div/div/a/span[2]")).Click();
                driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div/div/ul/li[4]/a")).Click();
            }
        }
        [Test]
        public void LogInOutTestCaseTest2()//Wrong Password
        {
                driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
                driver.FindElement(By.Id("login-button")).Click();
                driver.FindElement(By.Id("Email")).Click();
                driver.FindElement(By.Id("Email")).Clear();
                driver.FindElement(By.Id("Email")).SendKeys("k.test01@mail.ru");
                driver.FindElement(By.Id("Password")).Click();
                driver.FindElement(By.Id("Password")).Clear();
                driver.FindElement(By.Id("Password")).SendKeys("TestPass01");
                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(1000);
            try
                {
                    Assert.AreEqual("Incorrect email or password.", driver.FindElement(By.XPath("//span[@id='login-message']/div")).Text);
                }
                catch (AssertionException e)
                {
                    verificationErrors.Append(e.Message);
                }
                driver.FindElement(By.XPath("//button[@type='button']")).Click();
            

        }
        [Test]
        public void LogInOutTestCaseTest3()///Wrong Email
        {
            driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            driver.FindElement(By.Id("login-button")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("k.test001@mail.ru");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("TestPass001");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Incorrect email or password.", driver.FindElement(By.XPath("//span[@id='login-message']/div")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//button[@type='button']")).Click();

        }
        /*private bool IsElementPresent(By by)
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
            }*/
        }
}
