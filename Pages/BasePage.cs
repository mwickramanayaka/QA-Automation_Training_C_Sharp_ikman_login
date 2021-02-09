using System;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using AventStack.ExtentReports;
using System.IO;
//using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Threading;
using Test.Framework.Util;

namespace Test.Framework.Pages
{
    public class BasePage
    {
        protected static IWebDriver driver = DriverSetup.GetDriverSetupInstance().GetWebDriver();
        private static BasePage instance;
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }

            set
            {
                driver = value;
            }
        }
    } 
}

