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

//An additional script for configuring the browser and further automating the process.

namespace TestMurano.Utilities
{
    class BrowserUtilities
    {
        public int select;
        public IWebDriver Init(IWebDriver driver, int selectBrowser)
        {
            select = selectBrowser;
            if (select == 1) { driver = new ChromeDriver("D:\\Program Files (x86)\\Google\\Chrome"); }
            else if (select == 2) { driver = new FirefoxDriver(); }
            else { driver = new InternetExplorerDriver(); }
            driver.Manage().Window.Maximize();
            driver.Url = "https://dotnetfiddle.net/";
            return driver;
        }
    }
}
