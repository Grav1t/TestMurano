using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace TestMurano.Utilities
{
    class BrowserUtilities
    {
        public IWebDriver Init(IWebDriver driver, int selectBrowser)
        {
            if (selectBrowser == 1) { driver = new ChromeDriver("D:\\Program Files (x86)\\Google\\Chrome"); }
            if (selectBrowser == 2) { driver = new FirefoxDriver(); }
            if (selectBrowser == 3) { driver = new InternetExplorerDriver(); } 
            else { driver = new FirefoxDriver(); }
            driver.Manage().Window.Maximize();
            driver.Url = "https://dotnetfiddle.net/";
            return driver;
        }
    }
}
