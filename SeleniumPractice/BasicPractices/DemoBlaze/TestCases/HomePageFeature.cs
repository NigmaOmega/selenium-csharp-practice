using NUnit.Framework;
using SeleniumPractice.DemoBlaze.Model;
using SeleniumPractice.DemoBlaze.PageObjectModel;
using System.Collections.Generic;

namespace SeleniumPractice.DemoBlaze.TestCases
{
    public class HomePageFeature : DemoBlazeBaseTest
    {
        List<Product> products;

        [OneTimeSetUp]
        public void ScenarioSetUp()
        {
            products = new List<Product>();
            Product product = new Product("Samsung galaxy s6", "$360", "The Samsung Galaxy S6 is powered by 1.5GHz octa-core Samsung Exynos 7420 processor and it comes with 3GB of RAM. The phone packs 32GB of internal storage cannot be expanded.", "Phones");
            products.Add(product);
            product = new Product("Sony vaio i5", "$790", "Sony is so confident that the VAIO S is a superior ultraportable laptop that the company proudly compares the notebook to Apple's 13-inch MacBook Pro. And in a lot of ways this notebook is better, thanks to a lighter weight.", "Laptops");
            products.Add(product);
            product = new Product("Apple monitor 24", "$400", "LED Cinema Display features a 27-inch glossy LED-backlit TFT active-matrix LCD display with IPS technology and an optimum resolution of 2560x1440. It has a 178 degree horizontal and vertical viewing angle, a \"typical\" brightness of 375 cd/m2, contrast ratio of 1000:1, and a 12 ms response time.", "Monitors");
            products.Add(product);

            homePage = new HomePage(driver);
            homePage
                .GoTo()
                .OpenLoginPopup()
                .Login(WebConstants.Username, WebConstants.Password);
        }


        [Test]
        public void DisplayListItem_FollowingCategory_Successfully()
        {
            foreach (var product in products)
            {
                homePage
                    .GoTo()
                    .SelectCategory(product.Category)
                    .VerifyProductIsDisplayed(product);
            }
        }
    }
}