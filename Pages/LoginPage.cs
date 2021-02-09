using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Test.Framework.Util;

namespace Test.Framework.Pages
{
    public class LogInPage : BasePage
    {

        //########## Setup ############
        private static IkmanUI ikmanUI;
    
        //########### Element Definition #############
        private By loginHeading = By.XPath("//*[@id='app-wrapper']/div[2]/div[3]/div[2]/div[1]/h1[contains(., 'Log in to ikman')]");
        private By userName = By.Id("input_email");
        private By password = By.Id("input_password");
        private By btnSignIn = By.XPath("//div[3]/div[2]/div[2]/div/form/div[2]/div/button");
        private By loginfailed = By.XPath("//div[3]/div[2]/div[2]/div/div[2]/span");
        private By btnGoToLogin = By.XPath("/html/body/nav/div/ul[3]/li[4]/a");

        //private By btnLogOut = By.XPath("//a[@class='navbar-link']//span[@class='fa fa-sign-out']");

        //private By logoutPage = By.XPath("//div[@class='container page-loggedOut']");


        //################## Methods ############
        public LogInPage()
        {
            ikmanUI = new IkmanUI(driver);
        }
        public void clickLoginBtn()
        {
            ikmanUI.ClickElement(btnGoToLogin);
        }
        public bool logInHeadingDisplayed()
        {
            ikmanUI.sleep(15);
            return ikmanUI.IsElementVisible(loginHeading);
        }
        public void enterUserName(String uName)
        {
            ikmanUI.ClickElement(userName);
            ikmanUI.Textclear(userName);
            ikmanUI.ValueSendkeys(userName, uName);
        }
        public void enterPassword(String pwd)
        {
            ikmanUI.ClickElement(password);
            ikmanUI.Textclear(password);
            ikmanUI.ValueSendkeys(password, pwd);
        }
        public void clickSignInBtn()
        {
            ikmanUI.WaitForElementVisible(btnSignIn);
            ikmanUI.ClickElement(btnSignIn);
        }
        public bool loginFaildMSGdisplayed()
        {
            ikmanUI.sleep(5);
            return ikmanUI.IsElementVisible(loginfailed);
        }
        public void gotoPage(string url)
        {
            ikmanUI.navigateTo(url);
        }
    }
}
