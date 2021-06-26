 using System;
using OpenQA.Selenium;
using Test.Framework.Util;

namespace Test.Framework.Pages
{
    public class LogInPage : BasePage
    {

        //########## Setup ############
        private static IkmanUI ikmanUI;

        //########### Element Definition #############
        private By btnGoToLogin = By.XPath("/html/body/nav/div/ul[3]/li[4]/a");
        private By loginHeading = By.XPath("//*[@id='app-wrapper']/div[2]/div[3]/div[2]/div[1]/h1[contains(., 'Log in to ikman')]");
        private By userName = By.Id("input_email");
        private By password = By.Id("input_password");
        private By btnSignIn = By.XPath("//div[3]/div[2]/div[2]/div/form/div[2]/div/button");
        private By loginfailed = By.XPath("//div[2]/div[2]/div/div/span");
        private By myaccountMenu = By.XPath("/html/body/nav/div/ul[3]/li[3]/a/span[contains(., 'My account')]");      
       

        //private By btnGotoLogins = By.XPath("//div[2]/div[2]/div/div[3]/button");
        private By btnGotoEmail = By.XPath("//*[text()='Continue with Email']");
        //private By btnGotoLogins = By.XPath("//div[2]/div[3]/div[2]/div[2]/div[1]/div[3]/button/[contains(., 'Continue with Email')]");

        //private By btnLogOut = By.XPath("//a[@class='navbar-link']//span[@class='fa fa-sign-out']");
        //private By logoutPage = By.XPath("//div[@class='container page-loggedOut']");


        //################## Methods ############
        public LogInPage()
        {
            ikmanUI = new IkmanUI(driver);
        }
        public bool clickLoginBtn()
        {
            return ikmanUI.ClickElement(btnGoToLogin);
        }
        
        public bool ClickEmailBtn()
        {
            return ikmanUI.ClickElement(btnGotoEmail);
        }
     
        public bool logInHeadingDisplayed()
        {
            ikmanUI.sleep(15);
            return ikmanUI.IsElementVisible(loginHeading);
        }
        public void enterUserName(string uName)
        {
            ikmanUI.ClickElement(userName);
            ikmanUI.Textclear(userName);
            ikmanUI.ValueSendkeys(userName, uName);
        }
        public void enterPassword(string pwd)
        {
            ikmanUI.ClickElement(password);
            ikmanUI.Textclear(password);
            ikmanUI.ValueSendkeys(password, pwd);
        }
        public bool clickSignInBtn()
        {
            ikmanUI.WaitForElementVisible(btnSignIn);
            return ikmanUI.ClickElement(btnSignIn);
        }
        public bool loginFaildMSGdisplayed()
        {
            ikmanUI.sleep(5);
            return ikmanUI.IsElementVisible(loginfailed);
        }
        public bool loginDisplayedMyaccount()
        {
            ikmanUI.sleep(10);
            return ikmanUI.IsElementVisible(myaccountMenu);
        }
        public bool gotoPage(string url)
        {
            return ikmanUI.navigateTo(url);
        }

        public bool clickMyAccount()
        {
            return ikmanUI.ClickElement(myaccountMenu);
        }
    }
}
