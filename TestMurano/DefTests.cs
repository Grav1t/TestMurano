using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using TestMurano.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Support.UI;

namespace TestMuranoDefTests
{
    [TestFixture]
    public class DefaultUITests
    {
        ExtentReports extent = null;
        IWebDriver driver;
        private StringBuilder verificationErrors;
        private bool acceptNextAlert = true;

        public void LogIn(IWebDriver Driver)
        {
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("login-button")).Click();
            Driver.FindElement(By.Id("Email")).Click();
            Driver.FindElement(By.Id("Email")).Clear();
            Driver.FindElement(By.Id("Email")).SendKeys("k.test01@mail.ru");
            Driver.FindElement(By.Id("Password")).Click();
            Driver.FindElement(By.Id("Password")).Clear();
            Driver.FindElement(By.Id("Password")).SendKeys("TestPass001");
            Driver.FindElement(By.XPath("//form[@id='form0']/div[3]/div[2]/button")).Click();
        }
        public void LogOut(IWebDriver Driver)
        {
            Driver.FindElement(By.Id("account-display-name")).Click();
            Driver.FindElement(By.LinkText("Log out")).Click();
        }

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


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void LogInOutTestCaseTest1()//Positive test
        {
            ExtentTest test = extent.CreateTest("1TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            test.Log(Status.Info, "Chrome Browser lanches");
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
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
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 1 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void DDMenuMyFiddlesTest()
        {
            ExtentTest test = extent.CreateTest("2TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
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
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.LinkText("Favorites")).Click();
            try
            {
                Assert.AreEqual("Favorites", Driver.FindElement(By.LinkText("Favorites")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 2 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void DDMenuAccSetTest()
        {
            ExtentTest test = extent.CreateTest("3TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div/div/a/span[2]")).Click();
            Driver.FindElement(By.LinkText("Account")).Click();
            try
            {
                Assert.AreEqual("Account Settings", Driver.FindElement(By.XPath("//h3")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("account-settings-form")).Click();
            try
            {
                Assert.AreEqual("Account Settings | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 3 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void AccessTestUA()
        {
            ExtentTest test = extent.CreateTest("4TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);

            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//form[@id='CodeForm']/div[2]/div[3]/div[2]/div/button/span")).Click();
            Driver.FindElement(By.LinkText("Public")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Public", Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/form/div[2]/div[3]/div[2]/div/button/span[1]")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 4 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void AccessTestAut()
        {
            ExtentTest test = extent.CreateTest("5TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//form[@id='CodeForm']/div[2]/div[3]/div[2]/div/button/span")).Click();
            Driver.FindElement(By.LinkText("Public")).Click();
            try
            {
                Assert.AreEqual("Public ", Driver.FindElement(By.XPath("(//button[@type='button'])[10]")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 5 Passed");
        }

        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void SearchTest()
        {
            ExtentTest test = extent.CreateTest("6TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("(//a[@type='button'])[2]")).Click();
            Thread.Sleep(5000);
            try
            {
                Assert.AreEqual("All Fiddles | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("All Fiddles", Driver.FindElement(By.XPath("//div[2]/h1")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 6 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void SearchTestUA()
        {
            ExtentTest test = extent.CreateTest("7TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("(//a[@type='button'])[2]")).Click();
            Thread.Sleep(5000);
            try
            {
                Assert.AreEqual("All Fiddles | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("All Fiddles", Driver.FindElement(By.XPath("//div[2]/h1")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 7 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void GetStartTestAut()
        {
            ExtentTest test = extent.CreateTest("8TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.LinkText("Getting Started")).Click();
            try
            {
                Assert.AreEqual("C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Overview", Driver.FindElement(By.XPath("//div[2]/h1")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Thread.Sleep(1000);
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 8 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void CollaborateTestUA()
        {
            ExtentTest test = extent.CreateTest("9TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("togetherjs")).Click();
            Thread.Sleep(1000);
            Driver.FindElement(By.CssSelector("#togetherjs-walkthrough .togetherjs-close")).Click();
            try
            {
                Assert.AreEqual("Invite a friend", Driver.FindElement(By.XPath("//div[@id='togetherjs-share']/header")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 9 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void CollaborateTestAut()
        {
            ExtentTest test = extent.CreateTest("10TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("togetherjs")).Click();
            Thread.Sleep(1000);
            Driver.FindElement(By.CssSelector("#togetherjs-walkthrough .togetherjs-close")).Click();
            try
            {
                Assert.AreEqual("Invite a friend", Driver.FindElement(By.XPath("//div[@id='togetherjs-share']/header")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 10 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void ShareTestUA()
        {
            ExtentTest test = extent.CreateTest("11TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("Share")).Click();
            try
            {
                Assert.AreEqual("Share Link", Driver.FindElement(By.XPath("//div[@id='share-dialog']/span/b")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Embed on Your Page", Driver.FindElement(By.XPath("//div[@id='share-dialog']/div[2]/span/b")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.XPath("//form[@id='CodeForm']/div[2]/div[4]/div/div/div[2]/div[6]")).Click();
            Driver.Quit();
            test.Log(Status.Pass, "Test 11 Passed");
        }

        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void ShareTestAut()
        {
            ExtentTest test = extent.CreateTest("12TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("Share")).Click();
            try
            {
                Assert.AreEqual("Share Link", Driver.FindElement(By.XPath("//div[@id='share-dialog']/span/b")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Embed on Your Page", Driver.FindElement(By.XPath("//div[@id='share-dialog']/div[2]/span/b")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.XPath("//form[@id='CodeForm']/div[2]/div[4]/div/div/div[2]/div[6]")).Click();
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 12 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void OptionsLanguageTestAut()
        {
            ExtentTest test = extent.CreateTest("13TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            Driver.FindElement(By.Id("Language")).Click();
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            new SelectElement(Driver.FindElement(By.Id("Language"))).SelectByText("VB.NET");
            try
            {
                Assert.AreEqual("VbNet", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Thread.Sleep(1000);
            Driver.FindElement(By.Id("Language")).Click();
            new SelectElement(Driver.FindElement(By.Id("Language"))).SelectByText("F#");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("FSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 13 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void OptionsLanguageTestUA()
        {
            ExtentTest test = extent.CreateTest("14TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.Id("Language")).Click();
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            new SelectElement(Driver.FindElement(By.Id("Language"))).SelectByText("VB.NET");
            try
            {
                Assert.AreEqual("VbNet", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Thread.Sleep(1000);
            Driver.FindElement(By.Id("Language")).Click();
            new SelectElement(Driver.FindElement(By.Id("Language"))).SelectByText("F#");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("FSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 14 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void OptionsCompilerTestUA()
        {
            ExtentTest test = extent.CreateTest("15TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Console", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Net45", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("Compiler")).Click();
            new SelectElement(Driver.FindElement(By.Id("Compiler"))).SelectByText("Roslyn 3.8");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Roslyn", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            new SelectElement(Driver.FindElement(By.Id("Compiler"))).SelectByText(".NET 5");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("NetCore22", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 15 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void OptionsCompilerTestAut()
        { ExtentTest test = extent.CreateTest("16TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Console", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Net45", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("Compiler")).Click();
            new SelectElement(Driver.FindElement(By.Id("Compiler"))).SelectByText("Roslyn 3.8");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Roslyn", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            new SelectElement(Driver.FindElement(By.Id("Compiler"))).SelectByText(".NET 5");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("NetCore22", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 16 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void OptionsPTypeTestUA()
        {
            ExtentTest test = extent.CreateTest("17TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Console", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("Script");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Script", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Thread.Sleep(1000);
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("MVC");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Mvc", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("Nancy");
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("Nancy", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test17 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void OptionsPTypeTestAut()
        {
            ExtentTest test = extent.CreateTest("18TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            LogIn(Driver); 
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Console", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("Script");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Script", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Thread.Sleep(1000);
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("MVC");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Mvc", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("Nancy");
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("Nancy", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 18 Passed");
        }



        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void AboutTestUA()
        { ExtentTest test = extent.CreateTest("19TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.Id("about-btn")).Click();
            Driver.FindElement(By.Id("output")).Click();
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.Id("about-btn")).Click();
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("ABOUT US\r\n========\r\n\r\nWe are a group of .NET developers who are sick and tired of starting Visual Studio, creating a new project and running it, just to test simple code or try out samples from other developers.  \r\n\r\nThis tool was inspired by http://jsfiddle.net, which is just awesome.\r\n\r\nIf you are interested in working on .NET Fiddle please send your resume and links to a couple of your best fiddles to dotnetfiddle at entechsolutions dot com.  The most impressive fiddle will get the job.\r\n\r\nENTech Solutions\r\nhttp://www.entechsolutions.com", Driver.FindElement(By.XPath("//*[@id='output']")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test19 Passed");
        }



        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void AboutTestAut()
        {
            ExtentTest test = extent.CreateTest("20TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.Id("about-btn")).Click();
            Driver.FindElement(By.Id("output")).Click();
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.Id("about-btn")).Click();
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("ABOUT US\r\n========\r\n\r\nWe are a group of .NET developers who are sick and tired of starting Visual Studio, creating a new project and running it, just to test simple code or try out samples from other developers.  \r\n\r\nThis tool was inspired by http://jsfiddle.net, which is just awesome.\r\n\r\nIf you are interested in working on .NET Fiddle please send your resume and links to a couple of your best fiddles to dotnetfiddle at entechsolutions dot com.  The most impressive fiddle will get the job.\r\n\r\nENTech Solutions\r\nhttp://www.entechsolutions.com", Driver.FindElement(By.XPath("//*[@id='output']")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 20 Passed");

        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void SupportTestUA()
        {
            ExtentTest test = extent.CreateTest("Test21UI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Roadmap")).Click();
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("What's coming?", Driver.FindElement(By.XPath("/html/body/div/div[3]/div/div/div[1]/h1")).Text);
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
            try
            {
                Assert.AreEqual(".NET Fiddle Evolution", Driver.FindElement(By.XPath("//div[2]/h1")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 21 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void SupportTestAut()
        {
            ExtentTest test = extent.CreateTest("22TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Roadmap")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("What's coming?", Driver.FindElement(By.XPath("/html/body/div/div[2]/div/div/div[1]/h1")).Text);
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
            try
            {
                Assert.AreEqual(".NET Fiddle Evolution", Driver.FindElement(By.XPath("//div[2]/h1")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 22 Passed");
        }



        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void TermsTestUA()
        {
            ExtentTest test = extent.CreateTest("23TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Terms")).Click();
            try
            {
                Assert.AreEqual("Terms & Conditions", Driver.FindElement(By.XPath("//h2")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Terms | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 23 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void TermsTestAut()
        {
            ExtentTest test = extent.CreateTest("24TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Terms")).Click();
            try
            {
                Assert.AreEqual("Terms & Conditions", Driver.FindElement(By.XPath("//h2")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Terms | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 24 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void PrivacyTestUA()
        { ExtentTest test = extent.CreateTest("25TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Privacy Policy")).Click();
            try
            {
                Assert.AreEqual("Privacy Policy", Driver.FindElement(By.XPath("//h2")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Privacy Policy | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 25 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void PrivacyTestAut()
        {
            ExtentTest test = extent.CreateTest("26TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Privacy Policy")).Click();
            try
            {
                Assert.AreEqual("Privacy Policy", Driver.FindElement(By.XPath("//h2")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Privacy Policy | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 26 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void ContactUSTestUA()
        {
            ExtentTest test = extent.CreateTest("27TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button/span")).Click();
            Driver.FindElement(By.LinkText("Contact Us")).Click();
                try
                {
                    Assert.AreEqual("Contact us", Driver.FindElement(By.XPath("//div[@id='contact-page']/h1")).Text);
                }
                catch (AssertionException e)
                {
                     verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
                }
                try
                {
                    Assert.AreEqual("Contact us | C# Online Compiler | .NET Fiddle", Driver.Title);
                }
                catch (AssertionException e)
                {
                     verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
                }
            Driver.Quit();
            test.Log(Status.Pass, "Test 27 Passed");
        }


        [Test, Category("DefaltUI"), Category("ChromeUI")]
        public void ContactUSTestAut()
        {
            ExtentTest test = extent.CreateTest("28TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button/span")).Click();
            Driver.FindElement(By.LinkText("Contact Us")).Click();
            try
            {
                Assert.AreEqual("Contact us", Driver.FindElement(By.XPath("//div[@id='contact-page']/h1")).Text);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Contact us | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                 verificationErrors.Append(e.Message); 
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 28 Passed");
        }









        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFLogInOutTestCaseTest1()//Positive test
        {
            ExtentTest test = extent.CreateTest("29TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            test.Log(Status.Info, "Chrome Browser lanches");
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
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
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 29 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFDDMenuMyFiddlesTest()
        {
            ExtentTest test = extent.CreateTest("30TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
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
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.LinkText("Favorites")).Click();
            try
            {
                Assert.AreEqual("Favorites", Driver.FindElement(By.LinkText("Favorites")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 30 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFDDMenuAccSetTest()
        {
            ExtentTest test = extent.CreateTest("31TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div/div/a/span[2]")).Click();
            Driver.FindElement(By.LinkText("Account")).Click();
            try
            {
                Assert.AreEqual("Account Settings", Driver.FindElement(By.XPath("//h3")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("account-settings-form")).Click();
            try
            {
                Assert.AreEqual("Account Settings | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 31 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFAccessTestUA()
        {
            ExtentTest test = extent.CreateTest("32TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);

            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//form[@id='CodeForm']/div[2]/div[3]/div[2]/div/button/span")).Click();
            Driver.FindElement(By.LinkText("Public")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Public", Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/form/div[2]/div[3]/div[2]/div/button/span[1]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 32 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFAccessTestAut()
        {
            ExtentTest test = extent.CreateTest("33TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//form[@id='CodeForm']/div[2]/div[3]/div[2]/div/button/span")).Click();
            Driver.FindElement(By.LinkText("Public")).Click();
            try
            {
                Assert.AreEqual("Public ", Driver.FindElement(By.XPath("(//button[@type='button'])[10]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 33 Passed");
        }

        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFSearchTest()
        {
            ExtentTest test = extent.CreateTest("34TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("(//a[@type='button'])[2]")).Click();
            Thread.Sleep(5000);
            try
            {
                Assert.AreEqual("All Fiddles | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("All Fiddles", Driver.FindElement(By.XPath("//div[2]/h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 34 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFSearchTestUA()
        {
            ExtentTest test = extent.CreateTest("35TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("(//a[@type='button'])[2]")).Click();
            Thread.Sleep(5000);
            try
            {
                Assert.AreEqual("All Fiddles | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("All Fiddles", Driver.FindElement(By.XPath("//div[2]/h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 35 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFGetStartTestAut()
        {
            ExtentTest test = extent.CreateTest("36TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.LinkText("Getting Started")).Click();
            try
            {
                Assert.AreEqual("C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Overview", Driver.FindElement(By.XPath("//div[2]/h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Thread.Sleep(1000);
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 36 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFCollaborateTestUA()
        {
            ExtentTest test = extent.CreateTest("37TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("togetherjs")).Click();
            Thread.Sleep(1000);
            Driver.FindElement(By.CssSelector("#togetherjs-walkthrough .togetherjs-close")).Click();
            try
            {
                Assert.AreEqual("Invite a friend", Driver.FindElement(By.XPath("//div[@id='togetherjs-share']/header")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 37 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFCollaborateTestAut()
        {
            ExtentTest test = extent.CreateTest("38TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("togetherjs")).Click();
            Thread.Sleep(1000);
            Driver.FindElement(By.CssSelector("#togetherjs-walkthrough .togetherjs-close")).Click();
            try
            {
                Assert.AreEqual("Invite a friend", Driver.FindElement(By.XPath("//div[@id='togetherjs-share']/header")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 38 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFShareTestUA()
        {
            ExtentTest test = extent.CreateTest("39TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("Share")).Click();
            try
            {
                Assert.AreEqual("Share Link", Driver.FindElement(By.XPath("//div[@id='share-dialog']/span/b")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Embed on Your Page", Driver.FindElement(By.XPath("//div[@id='share-dialog']/div[2]/span/b")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.XPath("//form[@id='CodeForm']/div[2]/div[4]/div/div/div[2]/div[6]")).Click();
            Driver.Quit();
            test.Log(Status.Pass, "Test 39 Passed");
        }

        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFShareTestAut()
        {
            ExtentTest test = extent.CreateTest("40TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("Share")).Click();
            try
            {
                Assert.AreEqual("Share Link", Driver.FindElement(By.XPath("//div[@id='share-dialog']/span/b")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Embed on Your Page", Driver.FindElement(By.XPath("//div[@id='share-dialog']/div[2]/span/b")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.XPath("//form[@id='CodeForm']/div[2]/div[4]/div/div/div[2]/div[6]")).Click();
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 40 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFOptionsLanguageTestAut()
        {
            ExtentTest test = extent.CreateTest("41TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            Driver.FindElement(By.Id("Language")).Click();
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            new SelectElement(Driver.FindElement(By.Id("Language"))).SelectByText("VB.NET");
            try
            {
                Assert.AreEqual("VbNet", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Thread.Sleep(1000);
            Driver.FindElement(By.Id("Language")).Click();
            new SelectElement(Driver.FindElement(By.Id("Language"))).SelectByText("F#");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("FSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 41 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFOptionsLanguageTestUA()
        {
            ExtentTest test = extent.CreateTest("42TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.Id("Language")).Click();
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            new SelectElement(Driver.FindElement(By.Id("Language"))).SelectByText("VB.NET");
            try
            {
                Assert.AreEqual("VbNet", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Thread.Sleep(1000);
            Driver.FindElement(By.Id("Language")).Click();
            new SelectElement(Driver.FindElement(By.Id("Language"))).SelectByText("F#");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("FSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 42 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFOptionsCompilerTestUA()
        {
            ExtentTest test = extent.CreateTest("43TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Console", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Net45", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("Compiler")).Click();
            new SelectElement(Driver.FindElement(By.Id("Compiler"))).SelectByText("Roslyn 3.8");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Roslyn", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            new SelectElement(Driver.FindElement(By.Id("Compiler"))).SelectByText(".NET 5");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("NetCore22", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 43 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFOptionsCompilerTestAut()
        {
            ExtentTest test = extent.CreateTest("44TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Console", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Net45", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("Compiler")).Click();
            new SelectElement(Driver.FindElement(By.Id("Compiler"))).SelectByText("Roslyn 3.8");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Roslyn", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            new SelectElement(Driver.FindElement(By.Id("Compiler"))).SelectByText(".NET 5");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("NetCore22", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 44 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFOptionsPTypeTestUA()
        {
            ExtentTest test = extent.CreateTest("45TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Console", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("Script");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Script", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Thread.Sleep(1000);
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("MVC");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Mvc", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("Nancy");
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("Nancy", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 45 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFOptionsPTypeTestAut()
        {
            ExtentTest test = extent.CreateTest("46TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Console", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("Script");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Script", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Thread.Sleep(1000);
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("MVC");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Mvc", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("Nancy");
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("Nancy", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 46 Passed");
        }



        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFAboutTestUA()
        {
            ExtentTest test = extent.CreateTest("47TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.Id("about-btn")).Click();
            Driver.FindElement(By.Id("output")).Click();
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.Id("about-btn")).Click();
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("ABOUT US\r\n========\r\n\r\nWe are a group of .NET developers who are sick and tired of starting Visual Studio, creating a new project and running it, just to test simple code or try out samples from other developers.  \r\n\r\nThis tool was inspired by http://jsfiddle.net, which is just awesome.\r\n\r\nIf you are interested in working on .NET Fiddle please send your resume and links to a couple of your best fiddles to dotnetfiddle at entechsolutions dot com.  The most impressive fiddle will get the job.\r\n\r\nENTech Solutions\r\nhttp://www.entechsolutions.com", Driver.FindElement(By.XPath("//*[@id='output']")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test47 Passed");
        }



        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFAboutTestAut()
        {
            ExtentTest test = extent.CreateTest("48TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.Id("about-btn")).Click();
            Driver.FindElement(By.Id("output")).Click();
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.Id("about-btn")).Click();
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("ABOUT US\r\n========\r\n\r\nWe are a group of .NET developers who are sick and tired of starting Visual Studio, creating a new project and running it, just to test simple code or try out samples from other developers.  \r\n\r\nThis tool was inspired by http://jsfiddle.net, which is just awesome.\r\n\r\nIf you are interested in working on .NET Fiddle please send your resume and links to a couple of your best fiddles to dotnetfiddle at entechsolutions dot com.  The most impressive fiddle will get the job.\r\n\r\nENTech Solutions\r\nhttp://www.entechsolutions.com", Driver.FindElement(By.XPath("//*[@id='output']")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 48 Passed");

        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFSupportTestUA()
        {
            ExtentTest test = extent.CreateTest("49TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Roadmap")).Click();
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("What's coming?", Driver.FindElement(By.XPath("/html/body/div/div[3]/div/div/div[1]/h1")).Text);
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
            try
            {
                Assert.AreEqual(".NET Fiddle Evolution", Driver.FindElement(By.XPath("//div[2]/h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 49 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFSupportTestAut()
        {
            ExtentTest test = extent.CreateTest("50TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Roadmap")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("What's coming?", Driver.FindElement(By.XPath("/html/body/div/div[2]/div/div/div[1]/h1")).Text);
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
            try
            {
                Assert.AreEqual(".NET Fiddle Evolution", Driver.FindElement(By.XPath("//div[2]/h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 50 Passed");
        }



        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFTermsTestUA()
        {
            ExtentTest test = extent.CreateTest("51TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Terms")).Click();
            try
            {
                Assert.AreEqual("Terms & Conditions", Driver.FindElement(By.XPath("//h2")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Terms | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 51 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFTermsTestAut()
        {
            ExtentTest test = extent.CreateTest("52TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Terms")).Click();
            try
            {
                Assert.AreEqual("Terms & Conditions", Driver.FindElement(By.XPath("//h2")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Terms | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 52 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFPrivacyTestUA()
        {
            ExtentTest test = extent.CreateTest("53TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Privacy Policy")).Click();
            try
            {
                Assert.AreEqual("Privacy Policy", Driver.FindElement(By.XPath("//h2")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Privacy Policy | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 53 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFPrivacyTestAut()
        {
            ExtentTest test = extent.CreateTest("54TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Privacy Policy")).Click();
            try
            {
                Assert.AreEqual("Privacy Policy", Driver.FindElement(By.XPath("//h2")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Privacy Policy | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 54 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFContactUSTestUA()
        {
            ExtentTest test = extent.CreateTest("55TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button/span")).Click();
            Driver.FindElement(By.LinkText("Contact Us")).Click();
            try
            {
                Assert.AreEqual("Contact us", Driver.FindElement(By.XPath("//div[@id='contact-page']/h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Contact us | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 55 Passed");
        }


        [Test, Category("DefaltUI"), Category("FireFoxUI")]
        public void FFContactUSTestAut()
        {
            ExtentTest test = extent.CreateTest("56TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 2);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button/span")).Click();
            Driver.FindElement(By.LinkText("Contact Us")).Click();
            try
            {
                Assert.AreEqual("Contact us", Driver.FindElement(By.XPath("//div[@id='contact-page']/h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Contact us | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 56 Passed");
        }






        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IELogInOutTestCaseTest1()//Positive test
        {
            ExtentTest test = extent.CreateTest("57TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 1);
            test.Log(Status.Info, "Chrome Browser lanches");
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
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
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 57 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEDDMenuMyFiddlesTest()
        {
            ExtentTest test = extent.CreateTest("58TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
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
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.LinkText("Favorites")).Click();
            try
            {
                Assert.AreEqual("Favorites", Driver.FindElement(By.LinkText("Favorites")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 58 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEDDMenuAccSetTest()
        {
            ExtentTest test = extent.CreateTest("59TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div/div/a/span[2]")).Click();
            Driver.FindElement(By.LinkText("Account")).Click();
            try
            {
                Assert.AreEqual("Account Settings", Driver.FindElement(By.XPath("//h3")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("account-settings-form")).Click();
            try
            {
                Assert.AreEqual("Account Settings | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 59 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEAccessTestUA()
        {
            ExtentTest test = extent.CreateTest("60TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);

            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//form[@id='CodeForm']/div[2]/div[3]/div[2]/div/button/span")).Click();
            Driver.FindElement(By.LinkText("Public")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Public", Driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/form/div[2]/div[3]/div[2]/div/button/span[1]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 60 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEAccessTestAut()
        {
            ExtentTest test = extent.CreateTest("61TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//form[@id='CodeForm']/div[2]/div[3]/div[2]/div/button/span")).Click();
            Driver.FindElement(By.LinkText("Public")).Click();
            try
            {
                Assert.AreEqual("Public ", Driver.FindElement(By.XPath("(//button[@type='button'])[10]")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 61 Passed");
        }

        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IESearchTest()
        {
            ExtentTest test = extent.CreateTest("62TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("(//a[@type='button'])[2]")).Click();
            Thread.Sleep(5000);
            try
            {
                Assert.AreEqual("All Fiddles | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("All Fiddles", Driver.FindElement(By.XPath("//div[2]/h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 62 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IESearchTestUA()
        {
            ExtentTest test = extent.CreateTest("63TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("(//a[@type='button'])[2]")).Click();
            Thread.Sleep(5000);
            try
            {
                Assert.AreEqual("All Fiddles | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("All Fiddles", Driver.FindElement(By.XPath("//div[2]/h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 63 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEGetStartTestAut()
        {
            ExtentTest test = extent.CreateTest("64TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.LinkText("Getting Started")).Click();
            try
            {
                Assert.AreEqual("C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Overview", Driver.FindElement(By.XPath("//div[2]/h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Thread.Sleep(1000);
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 64 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IECollaborateTestUA()
        {
            ExtentTest test = extent.CreateTest("65TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("togetherjs")).Click();
            Thread.Sleep(1000);
            Driver.FindElement(By.CssSelector("#togetherjs-walkthrough .togetherjs-close")).Click();
            try
            {
                Assert.AreEqual("Invite a friend", Driver.FindElement(By.XPath("//div[@id='togetherjs-share']/header")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 65 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IECollaborateTestAut()
        {
            ExtentTest test = extent.CreateTest("66TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("togetherjs")).Click();
            Thread.Sleep(1000);
            Driver.FindElement(By.CssSelector("#togetherjs-walkthrough .togetherjs-close")).Click();
            try
            {
                Assert.AreEqual("Invite a friend", Driver.FindElement(By.XPath("//div[@id='togetherjs-share']/header")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 66 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEShareTestUA()
        {
            ExtentTest test = extent.CreateTest("67TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("Share")).Click();
            try
            {
                Assert.AreEqual("Share Link", Driver.FindElement(By.XPath("//div[@id='share-dialog']/span/b")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Embed on Your Page", Driver.FindElement(By.XPath("//div[@id='share-dialog']/div[2]/span/b")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.XPath("//form[@id='CodeForm']/div[2]/div[4]/div/div/div[2]/div[6]")).Click();
            Driver.Quit();
            test.Log(Status.Pass, "Test 67 Passed");
        }

        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEShareTestAut()
        {
            ExtentTest test = extent.CreateTest("68TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.Id("Share")).Click();
            try
            {
                Assert.AreEqual("Share Link", Driver.FindElement(By.XPath("//div[@id='share-dialog']/span/b")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Embed on Your Page", Driver.FindElement(By.XPath("//div[@id='share-dialog']/div[2]/span/b")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.XPath("//form[@id='CodeForm']/div[2]/div[4]/div/div/div[2]/div[6]")).Click();
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 68 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEOptionsLanguageTestAut()
        {
            ExtentTest test = extent.CreateTest("69TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            Driver.FindElement(By.Id("Language")).Click();
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            new SelectElement(Driver.FindElement(By.Id("Language"))).SelectByText("VB.NET");
            try
            {
                Assert.AreEqual("VbNet", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Thread.Sleep(1000);
            Driver.FindElement(By.Id("Language")).Click();
            new SelectElement(Driver.FindElement(By.Id("Language"))).SelectByText("F#");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("FSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 69 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEOptionsLanguageTestUA()
        {
            ExtentTest test = extent.CreateTest("70TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.Id("Language")).Click();
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            new SelectElement(Driver.FindElement(By.Id("Language"))).SelectByText("VB.NET");
            try
            {
                Assert.AreEqual("VbNet", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Thread.Sleep(1000);
            Driver.FindElement(By.Id("Language")).Click();
            new SelectElement(Driver.FindElement(By.Id("Language"))).SelectByText("F#");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("FSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 70 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEOptionsCompilerTestUA()
        {
            ExtentTest test = extent.CreateTest("71TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Console", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Net45", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("Compiler")).Click();
            new SelectElement(Driver.FindElement(By.Id("Compiler"))).SelectByText("Roslyn 3.8");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Roslyn", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            new SelectElement(Driver.FindElement(By.Id("Compiler"))).SelectByText(".NET 5");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("NetCore22", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 71 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEOptionsCompilerTestAut()
        {
            ExtentTest test = extent.CreateTest("72TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Console", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Net45", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("Compiler")).Click();
            new SelectElement(Driver.FindElement(By.Id("Compiler"))).SelectByText("Roslyn 3.8");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Roslyn", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            new SelectElement(Driver.FindElement(By.Id("Compiler"))).SelectByText(".NET 5");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("NetCore22", Driver.FindElement(By.Id("Compiler")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 72 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEOptionsPTypeTestUA()
        {
            ExtentTest test = extent.CreateTest("73TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Console", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("Script");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Script", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Thread.Sleep(1000);
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("MVC");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Mvc", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("Nancy");
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("Nancy", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 73 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEOptionsPTypeTestAut()
        {
            ExtentTest test = extent.CreateTest("74TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("CSharp", Driver.FindElement(By.Id("Language")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Console", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("Script");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Script", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Thread.Sleep(1000);
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("MVC");
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Mvc", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.FindElement(By.Id("ProjectType")).Click();
            new SelectElement(Driver.FindElement(By.Id("ProjectType"))).SelectByText("Nancy");
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("Nancy", Driver.FindElement(By.Id("ProjectType")).GetAttribute("value"));
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 74 Passed");
        }



        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEAboutTestUA()
        {
            ExtentTest test = extent.CreateTest("75TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.Id("about-btn")).Click();
            Driver.FindElement(By.Id("output")).Click();
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.Id("about-btn")).Click();
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("ABOUT US\r\n========\r\n\r\nWe are a group of .NET developers who are sick and tired of starting Visual Studio, creating a new project and running it, just to test simple code or try out samples from other developers.  \r\n\r\nThis tool was inspired by http://jsfiddle.net, which is just awesome.\r\n\r\nIf you are interested in working on .NET Fiddle please send your resume and links to a couple of your best fiddles to dotnetfiddle at entechsolutions dot com.  The most impressive fiddle will get the job.\r\n\r\nENTech Solutions\r\nhttp://www.entechsolutions.com", Driver.FindElement(By.XPath("//*[@id='output']")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test75 Passed");
        }



        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEAboutTestAut()
        {
            ExtentTest test = extent.CreateTest("76TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.Id("about-btn")).Click();
            Driver.FindElement(By.Id("output")).Click();
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.Id("about-btn")).Click();
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("ABOUT US\r\n========\r\n\r\nWe are a group of .NET developers who are sick and tired of starting Visual Studio, creating a new project and running it, just to test simple code or try out samples from other developers.  \r\n\r\nThis tool was inspired by http://jsfiddle.net, which is just awesome.\r\n\r\nIf you are interested in working on .NET Fiddle please send your resume and links to a couple of your best fiddles to dotnetfiddle at entechsolutions dot com.  The most impressive fiddle will get the job.\r\n\r\nENTech Solutions\r\nhttp://www.entechsolutions.com", Driver.FindElement(By.XPath("//*[@id='output']")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 76 Passed");

        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IESupportTestUA()
        {
            ExtentTest test = extent.CreateTest("77TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Roadmap")).Click();
            Thread.Sleep(2000);
            try
            {
                Assert.AreEqual("What's coming?", Driver.FindElement(By.XPath("/html/body/div/div[3]/div/div/div[1]/h1")).Text);
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
            try
            {
                Assert.AreEqual(".NET Fiddle Evolution", Driver.FindElement(By.XPath("//div[2]/h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 77 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IESupportTestAut()
        {
            ExtentTest test = extent.CreateTest("78TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Roadmap")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("What's coming?", Driver.FindElement(By.XPath("/html/body/div/div[2]/div/div/div[1]/h1")).Text);
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
            try
            {
                Assert.AreEqual(".NET Fiddle Evolution", Driver.FindElement(By.XPath("//div[2]/h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 78 Passed");
        }



        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IETermsTestUA()
        {
            ExtentTest test = extent.CreateTest("79TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Terms")).Click();
            try
            {
                Assert.AreEqual("Terms & Conditions", Driver.FindElement(By.XPath("//h2")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Terms | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 79 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IETermsTestAut()
        {
            ExtentTest test = extent.CreateTest("80TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Terms")).Click();
            try
            {
                Assert.AreEqual("Terms & Conditions", Driver.FindElement(By.XPath("//h2")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Terms | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 80 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEPrivacyTestUA()
        {
            ExtentTest test = extent.CreateTest("81TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Privacy Policy")).Click();
            try
            {
                Assert.AreEqual("Privacy Policy", Driver.FindElement(By.XPath("//h2")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Privacy Policy | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 81 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEPrivacyTestAut()
        {
            ExtentTest test = extent.CreateTest("82TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button")).Click();
            Driver.FindElement(By.LinkText("Privacy Policy")).Click();
            try
            {
                Assert.AreEqual("Privacy Policy", Driver.FindElement(By.XPath("//h2")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Privacy Policy | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 82 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEContactUSTestUA()
        {
            ExtentTest test = extent.CreateTest("83TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            Driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button/span")).Click();
            Driver.FindElement(By.LinkText("Contact Us")).Click();
            try
            {
                Assert.AreEqual("Contact us", Driver.FindElement(By.XPath("//div[@id='contact-page']/h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Contact us | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            Driver.Quit();
            test.Log(Status.Pass, "Test 83 Passed");
        }


        [Test, Category("DefaltUI"), Category("IExplorerUI")]
        public void IEContactUSTestAut()
        {
            ExtentTest test = extent.CreateTest("84TestUI").Info("Test Started");
            var Driver = new BrowserUtilities().Init(driver, 3);
            LogIn(Driver);
            test.Log(Status.Info, "User log in");
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//div[@id='top-navbar']/div[3]/div[2]/button/span")).Click();
            Driver.FindElement(By.LinkText("Contact Us")).Click();
            try
            {
                Assert.AreEqual("Contact us", Driver.FindElement(By.XPath("//div[@id='contact-page']/h1")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            try
            {
                Assert.AreEqual("Contact us | C# Online Compiler | .NET Fiddle", Driver.Title);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
                test.Log(Status.Fail, e.ToString());
            }
            LogOut(Driver);
            Driver.Quit();
            test.Log(Status.Pass, "Test 84 Passed");
        }
    }
}
}