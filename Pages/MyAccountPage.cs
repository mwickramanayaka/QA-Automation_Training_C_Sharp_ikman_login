using System;
using OpenQA.Selenium;
using Test.Framework.Util;

namespace Test.Framework.Pages
{
    public class MyAccountPage : BasePage
    {
        //########## Setup ############
        private static IkmanUI ikmanUI;

        //########### Element Definition #############
        private By myaccountMenu = By.XPath("/html/body/nav/div/ul[3]/li[3]/a/span[contains(., 'My account')]");
        private By myMembership = By.XPath("//*[@class='ui-nav-item gtm-my-membership-click']");
        private By BecomeAIkmanMember = By.XPath("//*[@id='my-content']/div/div[1]/h3");
        
        //################## Methods ############
        public MyAccountPage()
        {
            ikmanUI = new IkmanUI(driver);
        }

        public bool loginDisplayedMyaccount()
        {
            ikmanUI.sleep(5);
            return ikmanUI.IsElementVisible(myaccountMenu);
        }

        public bool clickMyAccount()
        {
            return ikmanUI.ClickElement(myaccountMenu);
        }

        public bool MyMembershipBtnDisplayed()
        {
            ikmanUI.sleep(5); 
            return ikmanUI.IsElementVisible(myMembership);
        }

        public bool clickMyMembership()
        {           
            return ikmanUI.ClickElement(myMembership);
        }

        public bool BecomeAIkmanMemberDisplayed()
        {
            return ikmanUI.ClickElement(BecomeAIkmanMember);
        }
    }
}
