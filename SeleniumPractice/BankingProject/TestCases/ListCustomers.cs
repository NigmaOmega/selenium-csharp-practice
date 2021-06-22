using NUnit.Framework;
using SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel;
using SeleniumPractice.Demo.BankingProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.Demo.BankingProject.TestCases
{
    [Category("Bank Project")]
    class ListCustomers : BaseTest
    {
        ListCustomersPage listCustomersPage;

        readonly int numberOfItem = 5;

        [SetUp]
        public void ClassSetUp()
        {
            listCustomersPage = new ListCustomersPage(driver);
            listCustomersPage.GoTo();
            driver.DeleteStorage();
        }

        [Test]
        public void ShowListCustomersTable()
        {
            listCustomersPage.GoTo();
            listCustomersPage.VerifyListCustomerTable(numberOfItem);
        }

        [Test]
        public void ShowCustomerInformationOnTableWhenAddANewOne()
        {
            Customer customer = new Customer("W33", "Haa", "1234");

            AddCustomerPage addCustomerPage = new AddCustomerPage(driver);
            addCustomerPage.GoTo();
            addCustomerPage.AddCustomer(customer);
            addCustomerPage.VerifyAlertCustomerIsAddedAndCloseTheAlert();

            listCustomersPage.GoTo();
            listCustomersPage.VerifyListCustomerTable(numberOfItem + 1);

            OpenAccountPage openAccountPage = new OpenAccountPage(driver);
            openAccountPage.GoTo();
            string customerName = customer.FirstName + " " + customer.LastName;
            openAccountPage.OpenAccount(customerName, BankConstants.DefaultCurrency);
            var acountNumbers = openAccountPage.GetAccountNumberIsCreatedInAlert();
            customer.AccountNumbers = new List<string>();
            customer.AccountNumbers.Add(acountNumbers);
            openAccountPage.CloseAlert();

            listCustomersPage.GoTo();
            listCustomersPage.VerifyCustomerIsExisted(customer);
        }

        [Test]
        public void DeleteCustomerInTheTable() {

            Customer customer = new Customer("W33", "Haa", "1234");

            AddCustomerPage addCustomerPage = new AddCustomerPage(driver);
            addCustomerPage.GoTo();
            addCustomerPage.AddCustomer(customer);
            addCustomerPage.VerifyAlertCustomerIsAddedAndCloseTheAlert();

            OpenAccountPage openAccountPage = new OpenAccountPage(driver);
            openAccountPage.GoTo();
            string customerName = customer.FirstName + " " + customer.LastName;
            openAccountPage.OpenAccount(customerName, BankConstants.DefaultCurrency);
            var acountNumbers = openAccountPage.GetAccountNumberIsCreatedInAlert();
            openAccountPage.CloseAlert();

            listCustomersPage.GoTo();
            listCustomersPage.DeleteCustomer(acountNumbers);
            listCustomersPage.VerifyListCustomerTable(numberOfItem);
        }
    }
}
