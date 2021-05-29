﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestMurano.BaseClass
{
    public class BaseTest
    {
        public IWebDriver driver;
        
        [OneTimeSetUp]
        public void Open()
        {
            driver = new ChromeDriver("D:\\Program Files (x86)\\Google\\Chrome");
            driver.Manage().Window.Maximize();
            driver.Url = "https://dotnetfiddle.net/";
        }

        [OneTimeTearDown]
        public void Close()
        {
            driver.Quit();
        }


    }
}