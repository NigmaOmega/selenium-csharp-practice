using NUnit.Framework;
using SeleniumPractice.DemoBlaze.Model;
using SeleniumPractice.DemoBlaze.PageObjectModel;

namespace SeleniumPractice.DemoBlaze.TestCases
{
    public class ProductDetailsFeature : DemoBlazeBaseTest
    {
        Product product;

        [OneTimeSetUp]
        public void OtSetUp()
        {
            homePage = new HomePage(driver);

            homePage
                .GoTo()
                .OpenLoginPopup()
                .Login(WebConstants.Username, WebConstants.Password);

            product = new Product("Samsung galaxy s6", "$360", "The Samsung Galaxy S6 is powered by 1.5GHz octa-core Samsung Exynos 7420 processor and it comes with 3GB of RAM. The phone packs 32GB of internal storage cannot be expanded.", "Phones");
        }

        [Test]
        public void AccessProductDetails_Successfully()
        {
            homePage
                .GoTo()
                .GoToProductDetails(product)
                .VerifyProductDetailsIsShownCorrectly(product);
        }

    }
}