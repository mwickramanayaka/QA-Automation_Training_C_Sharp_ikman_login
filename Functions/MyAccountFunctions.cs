using System;
using Test.Framework.Pages;

namespace Test.Framework.Functions
{
    public class MyAccountFunctions
    {
        private static MyAccountPage MyAccountPage = new MyAccountPage();
        public MyAccountFunctions()
        {

        }        

        public static bool isClickMyAccountBtn()
        {
            return MyAccountPage.clickMyAccount();
        }

        public static bool isMyMembershipBtnDisplayed()
        {
            return MyAccountPage.MyMembershipBtnDisplayed();
        }

        public static bool isClickMyMembershipBtn()
        {
            return MyAccountPage.clickMyMembership();
        }

        public static bool isBecomeAIkmanMemberDisplayed()
        {
            return MyAccountPage.BecomeAIkmanMemberDisplayed();
        }


    }
}
