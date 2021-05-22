using NUnit.Framework;
using SeleniumPractice.DemoBlaze.Model;
using System.Collections.Generic;

namespace SeleniumPractice.DemoBlaze.TestCases
{
    public class CartFeature : DemoBlazeBaseTest
    {
        List<Product> products;

        [OneTimeSetUp]
        public void ScenarioSetUp()
        {
            products = new List<Product>();
            Product product = new Product("Samsung galaxy s6", "$360", "The Samsung Galaxy S6 is powered by 1.5GHz octa-core Samsung Exynos 7420 processor", "Phones");
            products.Add(product);
            product = new Product("Sony vaio i5", "$790", "Sony is so confident that the VAIO S is a superior ultraportable laptop that the", "Laptops");
            products.Add(product);
            product = new Product("Apple monitor 24", "$400", "LED Cinema Display features a 27-inch glossy LED-backlit TFT active-matrix LCD display with", "Monitors");
            products.Add(product);

            string newUserName = "User_" + DataGenerator.GenerateString(10);

            homePage
                .GoTo()
                .OpenSignUpPopup();

            signUpPage
                .SignUp(newUserName, WebConstants.Password)
                .AcceptAlert();

            homePage
                .GoTo()
                .OpenLoginPopup();

            loginPage
                .Login(newUserName, WebConstants.Password);
        }

        [Test]
        public void AddProductToCart_Successfully()
        {
            foreach (var product in products)
            {
                homePage
                    .GoTo()
                    .SelectCategory(product.Category)
                    .GoToProductDetails(product);

                productDetailsPage
                    .AddToCart();
            }

            homePage
                .GoToCart();

            cartPage
                .VerifyProductIsShown(products);


        }
    }
}