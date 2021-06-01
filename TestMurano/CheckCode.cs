using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class JStestTest
{
    private IWebDriver driver;
    public IDictionary<string, object> vars { get; private set; }
    private IJavaScriptExecutor js;
    [SetUp]
    public void SetUp()
    {
        driver = new FirefoxDriver();
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<string, object>();
        driver.Manage().Window.Maximize();
    }
    [TearDown]
    protected void TearDown()
    {
        driver.Quit();
    }
    [Test, Category("CodeTest"), Category("Chrome")]
    public void TestCodeCSharpUnauthorized()
    {
        driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
        driver.FindElement(By.CssSelector(".cm-string")).Click();
        driver.FindElement(By.CssSelector(".cm-string")).Click();
        {
            var element = driver.FindElement(By.CssSelector(".cm-string"));
            Actions builder = new Actions(driver);
            builder.DoubleClick(element).Perform();
        }
        Assert.That(driver.FindElement(By.CssSelector(".cm-string")).Text, Is.EqualTo(@"""Hello World"""));
        var TextMSG = driver.FindElement(By.CssSelector(".cm-string")).Text;
        driver.FindElement(By.CssSelector(".cm-string")).Click();
        driver.FindElement(By.CssSelector(".CodeMirror textarea")).SendKeys("Console.WriteLine(\"Hello Test!\");");
        driver.FindElement(By.CssSelector(".glyphicon-play")).Click();
        Thread.Sleep(2000);
        Assert.That(driver.FindElement(By.CssSelector(".output-pane")).Text, Is.EqualTo("Hello Test!"));
        
    }
    [Test, Category("CodeTest"), Category("Chrome")]

    public void TestCodeCSharpAuthorized()
    {
        driver.Navigate().GoToUrl("https://dotnetfiddle.net/");
        driver.FindElement(By.CssSelector(".cm-string")).Click();
        driver.FindElement(By.CssSelector(".cm-string")).Click();
        {
            var element = driver.FindElement(By.CssSelector(".cm-string"));
            Actions builder = new Actions(driver);
            builder.DoubleClick(element).Perform();
        }
        Assert.That(driver.FindElement(By.CssSelector(".cm-string")).Text, Is.EqualTo(@"""Hello World!"""));
        var TextMSG = driver.FindElement(By.CssSelector(".cm-string")).Text;
        driver.FindElement(By.CssSelector(".cm-string")).Click();
        driver.FindElement(By.CssSelector(".CodeMirror textarea")).SendKeys("Console.WriteLine(\"Hello Test!\");");
        driver.FindElement(By.CssSelector(".glyphicon-play")).Click();
        Thread.Sleep(2000);
        Assert.That(driver.FindElement(By.CssSelector(".output-pane")).Text, Is.EqualTo("Hello Test!"));

    }
}
