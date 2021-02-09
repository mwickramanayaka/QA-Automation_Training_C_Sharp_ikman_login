using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Test.Framework.Util;
using System.Runtime;
using Test.Framework.Pages;
using FluentAssertions;
using Test.Framework.Functions;

namespace Test.Framework.tests.Login
{
    [Category("Login")]
    [TestFixture]
    class TS_Login_rdm : TestBase
    {
        [Test]
        public void TS_TS01_Login_loaded_AC1()
        {
            LogInFunctions.isGotoPage(Settings.LoginUrl);
            LogInFunctions.isClickLoginBtn();
            Assert.IsTrue(LogInFunctions.isLogInHeadingDisplayed());
        }
    }
}
