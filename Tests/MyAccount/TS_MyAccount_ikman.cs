using NUnit.Framework;
using Test.Framework.Util;
using Test.Framework.Functions;

namespace Test.Framework.Tests.MyAccount
{
    [Category("MyAccount-Page")]
    [TestFixture]
    class TS_MyAccount_ikman : TestBase
    {
        [Test]
        public void TC_TS02_MyAccount_Loaded_AC1()
        {
            //login to ikman
            Assert.IsTrue(LogInFunctions.isGotoPage(Settings.LoginUrl));
            Assert.IsTrue(LogInFunctions.isClickLoginBtn());
            Assert.IsTrue(LogInFunctions.isClickEmailBtn());
            Assert.IsTrue(LogInFunctions.isUserLogIn(Settings.UserName_Correct, Settings.Password_Correct));
            Assert.IsTrue(LogInFunctions.isLoginDisplayedMyaccount());
        }

        [Test]
        public void TC_TS02_MyMembership_Success_AC2()
        {
            //Navigating to MyAccount
            Assert.IsTrue(MyAccountFunctions.isClickMyAccountBtn());
            Assert.IsTrue(MyAccountFunctions.isMyMembershipBtnDisplayed());
            Assert.IsTrue(MyAccountFunctions.isClickMyMembershipBtn());
            Assert.IsTrue(MyAccountFunctions.isBecomeAIkmanMemberDisplayed());
        }

  
    }
}
