using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class DynamicDataLoading : BaseTest
    {
        DynamicDataLoadingPage dynamicDataLoadingPage;

        [SetUp]
        public void ClassSetUp()
        {
            dynamicDataLoadingPage = new DynamicDataLoadingPage(driver);
            dynamicDataLoadingPage.GoTo();
        }

        [Test]
        public void LoadingStatusIsShowWhenGetNewUser_Successfully()
        {
            dynamicDataLoadingPage.GetNewUser();
            dynamicDataLoadingPage.VerifyLoadingStatusIsShown();
        }

        [Test]
        public void GetNewUser_Successfully()
        {
            dynamicDataLoadingPage.GetNewUser();
            dynamicDataLoadingPage.WaitForGetNewUser();
            dynamicDataLoadingPage.VerifyUserInformationIsShowm();
        }

        [Test]
        public void GetNewUserTwoTimes_Successfully()
        {
            dynamicDataLoadingPage.GetNewUser();
            dynamicDataLoadingPage.WaitForGetNewUser();
            dynamicDataLoadingPage.GetNewUser();
            dynamicDataLoadingPage.WaitForGetNewUser();
            dynamicDataLoadingPage.VerifyUserInformationIsShowm();
        }
    }
}
