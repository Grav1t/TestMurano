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
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;



namespace TestMurano
{
    [TestFixture]
    public class LogInParallelBrowsers
    {
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@" D: \Users\Дом\source\repos\TestMurano\TestMurano\ExtentReports\LogInParallelBrowsers.html");
            extent.AttachReporter(htmlReporter);


        }
        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }

        IWebDriver driver;
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;
        [Test, Category("LogInOut"), Category("Chrome")]
        public void LogInOutTestCaseTest1()//Positive test
        {
            ExtentTest test = extent.CreateTest("Test1").Info("Test Started");
           
            var Driver = new BrowserUtilities().Init(driver, 1);
            test.Log(Status.Info, "Chrome Browser lanches");
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("login-button")).Click();
            Driver.FindElement(By.Id("Email")).Click();
            Driver.FindElement(By.Id("Email")).Clear();
            Driver.FindElement(By.Id("Email")).SendKeys("k.test01@mail.ru");
            Driver.FindElement(By.Id("Password")).Click();
            Driver.FindElement(By.Id("Password")).Clear();
            Driver.FindElement(By.Id("Password")).SendKeys("TestPass001");
            Driver.FindElement(By.XPath("//form[@id='form0']/div[3]/div[2]/button")).Click();
            test.Log(Status.Info, "User log in");
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("Konsta", Driver.FindElement(By.XPath("//span[@id='account-display-name']")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
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
                        Driver.Quit();
            test.Log(Status.Pass,"Test2 Passed");
        }
        [Test, Category("LogInOut"), Category("Chrome")]
        public void LogInOutTestCaseTest2()//Wrong Password
        {
            var Driver = new BrowserUtilities().Init(driver, 1);
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
           
            Driver.Quit();

        }
        [Test, Category("LogInOut"), Category("Chrome")]
        public void LogInOutTestCaseTest3()///Wrong Email
        {
            var Driver = new BrowserUtilities().Init(driver, 1);
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
           
            Driver.Quit();
        }
        [Test, Category("LogInOut"), Category("Firefox")]
        public void LogInOutTestCaseTest4()//Positive test
        {
            var Driver = new BrowserUtilities().Init(driver, 2);
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
            
            Driver.Quit();
        }
        [Test, Category("LogInOut"), Category("Firefox")]
        public void LogInOutTestCaseTest5()//Wrong Password
        {
            var Driver = new BrowserUtilities().Init(driver, 2);
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
            
            Driver.Quit();

        }
        [Test, Category("LogInOut"), Category("Firefox")]
        public void LogInOutTestCaseTest6()///Wrong Email
        {
            var Driver = new BrowserUtilities().Init(driver, 2);
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
            
            Driver.Quit();
        }
        [Test, Category("LogInOut"), Category("IExplorer")]
        public void LogInOutTestCaseTest7()//Positive test
        {
            var Driver = new BrowserUtilities().Init(driver, 3);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("login-button")).Click();
            Driver.FindElement(By.Id("Email")).Click();
            Driver.FindElement(By.Id("Email")).Clear();
            Driver.FindElement(By.Id("Email")).SendKeys("k.test01@mail.ru");
            Driver.FindElement(By.Id("Password")).Click();
            Driver.FindElement(By.Id("Password")).Clear();
            Driver.FindElement(By.Id("Password")).SendKeys("TestPass001");
            Driver.FindElement(By.XPath("//form[@id='form0']/div[3]/div[2]/button")).Click();
            Thread.Sleep(5000);
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
            
            Driver.Quit();
        }
        [Test, Category("LogInOut"), Category("IExplorer")]
        public void LogInOutTestCaseTest8()//Wrong Password
        {
            var Driver = new BrowserUtilities().Init(driver, 3);
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
            
            Driver.Quit();

        }
        [Test, Category("LogInOut"), Category("IExplorer")]
        public void LogInOutTestCaseTest9()///Wrong Email
        {
            var Driver = new BrowserUtilities().Init(driver, 3);
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
            
            Driver.Quit();
        }
    }
}
