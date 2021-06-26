using System;
using Test.Framework.Pages;

namespace Test.Framework.Functions
{
    public class LogInFunctions
    {
        private static LogInPage LogInPage = new LogInPage();
        public LogInFunctions()
        {
           
        }
        public static bool isClickLoginBtn()
        {
            return LogInPage.clickLoginBtn();
         }
       
        public static bool isClickEmailBtn() 
        {
            return LogInPage.ClickEmailBtn();
        }
       
        public static bool isLogInHeadingDisplayed()
        {
            return LogInPage.logInHeadingDisplayed();
        }
        public static bool isLoginDisplayedMyaccount()
        {
            return LogInPage.loginDisplayedMyaccount();
        }
        public static bool isUserLogIn(string uname, string pwd)
        {
            LogInPage.enterUserName(uname);
            LogInPage.enterPassword(pwd);
            return LogInPage.clickSignInBtn();
        }
        public static bool isLoginFaildMSGdisplayed()
        {
            return LogInPage.loginFaildMSGdisplayed();
        }
        public static bool isGotoPage(string url)
        {
            return LogInPage.gotoPage(url);
        }
        /*
        public static bool isClickMyAccountBtn()
        {
            return LogInPage.clickMyAccount();
        }
        */
    }
}
