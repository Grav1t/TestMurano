using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMurano.Utilities
{
    class BrowserUtilities
    {
        public IWebDriver Init(IWebDriver driver)
        {
            driver = new ChromeDriver("D:\\Program Files (x86)\\Google\\Chrome");
            driver.Manage().Window.Maximize();
            driver.Url = "https://dotnetfiddle.net/";
            return driver;
        }
    }
}
