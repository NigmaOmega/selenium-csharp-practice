using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class WindowsPopupModal : BaseTest
    {
        WindowsPopupModalPage windowsPopupModalPage;

        [SetUp]
        public void ClassSetUp()
        {
            windowsPopupModalPage = new WindowsPopupModalPage(driver);
            windowsPopupModalPage.GoTo();
        }

        [Test]
        public void FollowOnTwiter_Successfully()
        {
            windowsPopupModalPage.FollowOnTwitter();
            windowsPopupModalPage.VerifyTwiterPageIsShown();
        }

        [Test]
        public void FollowOnTwitterAndFacebook_Successfully()
        {
            windowsPopupModalPage.FollowOnTwitterAndFacebook();
            windowsPopupModalPage.VerifyTwiterAndFacebookPagesAreShown();
        }

        [Test]
        public void LikeOnFacebook_Successfully()
        {
            windowsPopupModalPage.LikeOnFacebook();
            windowsPopupModalPage.VerifyFacebookPageIsShown();
        }

        [Test]
        public void FollowALl_Successfully()
        {
            windowsPopupModalPage.FollowAll();
            windowsPopupModalPage.VerifyFacebookAndTwitterAndGooglePlusPagesAreShown();
        }
    }
}
