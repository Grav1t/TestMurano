using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using TestMurano.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;



namespace TestMuranoDefTests
{
    [TestFixture]
    public class DefaultUITests
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


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void LogInOutTestCaseTest1()//Positive test
        {
            ExtentTest test = extent.CreateTest("Test1UI").Info("Test Started");

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
            Thread.Sleep(5000);
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
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div/div/a/span[2]")).Click();
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div/div/ul/li[4]/a")).Click();

            Driver.Quit();
            test.Log(Status.Pass, "Test2 Passed");
        }

        [Test, Category("DefaltUI"), Category("ChromeUI")]

        public void TheDDMenuMyFiddlesTest()
        {
            ExtentTest test = extent.CreateTest("Test1UI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("login-button")).Click();
            Driver.FindElement(By.Id("Email")).Click();
            Driver.FindElement(By.Id("Email")).Clear();
            Driver.FindElement(By.Id("Email")).SendKeys("k.test01@mail.ru");
            Driver.FindElement(By.Id("Password")).Click();
            Driver.FindElement(By.Id("Password")).Clear();
            Driver.FindElement(By.Id("Password")).SendKeys("TestPass001");
            Driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(1000);
            Driver.FindElement(By.CssSelector("a.user-name.dropdown-toggle > span.caret")).Click();
            Driver.FindElement(By.LinkText("My Fiddles")).Click();
            try
            {
                Assert.AreEqual("My Fiddles", Driver.FindElement(By.LinkText("My Fiddles")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Driver.FindElement(By.LinkText("Favorites")).Click();
            try
            {
                Assert.AreEqual("Favorites", Driver.FindElement(By.LinkText("Favorites")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            Driver.FindElement(By.LinkText("Konsta")).Click();
            Driver.FindElement(By.LinkText("Log out")).Click();
            Driver.Quit();
        }

    }    }