using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Framework.Pages;
using OpenQA.Selenium.Chrome;

namespace Test.Framework.Functions
{
    public class LogInFunctions
    {
        private static LogInPage LogInPage = new LogInPage();
        public LogInFunctions()
        {
           
        }
        public static void isClickLoginBtn()
        {
            LogInPage.clickLoginBtn();
        }
        public static bool isLogInHeadingDisplayed()
        {
            return LogInPage.logInHeadingDisplayed();
        }
        public static void isUserLogIn(String uname, String pwd)
        {
            LogInPage.enterUserName(uname);
            LogInPage.enterPassword(pwd);
            LogInPage.clickSignInBtn();
        }
        public static bool isLoginFaildMSGdisplayed()
        {
            return LogInPage.loginFaildMSGdisplayed();
        }
        public static void isGotoPage(String url)
        {
            LogInPage.gotoPage(url);
        }
    }
}
