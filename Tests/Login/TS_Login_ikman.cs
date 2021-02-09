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
        public void TC_TS01_Login_loaded_AC1()
        {
            LogInFunctions.isGotoPage(Settings.LoginUrl);
            LogInFunctions.isClickLoginBtn();
            Assert.IsTrue(LogInFunctions.isLogInHeadingDisplayed());
        }
        [Test]
        public void TC_TS02_Login_wrong_username_AC2()
        {
            LogInFunctions.isGotoPage(Settings.LoginUrl);
            LogInFunctions.isClickLoginBtn();
            LogInFunctions.isUserLogIn(Settings.UserName_wrong, Settings.Password_Correct);
            Assert.IsTrue(LogInFunctions.isLoginFaildMSGdisplayed());
        }
        [Test]
        public void TC_TS03_Login_wrong_password_AC3()
        {
            LogInFunctions.isGotoPage(Settings.LoginUrl);
            LogInFunctions.isClickLoginBtn();
            LogInFunctions.isUserLogIn(Settings.UserName_Correct, Settings.Password_wrong);
            Assert.IsTrue(LogInFunctions.isLoginFaildMSGdisplayed());
        }
        [Test]
        public void TC_TS04_Login_Success_AC4()
        {
            LogInFunctions.isGotoPage(Settings.LoginUrl);
            LogInFunctions.isClickLoginBtn();
            LogInFunctions.isUserLogIn(Settings.UserName_Correct, Settings.Password_Correct);
            Assert.IsTrue(LogInFunctions.isLoginDisplayedMyaccount());
        }
    }
}
