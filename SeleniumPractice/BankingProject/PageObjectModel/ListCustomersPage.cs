using FluentAssertions;
using OpenQA.Selenium;
using SeleniumPractice.Demo.BankingProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.AdvancePractices.BankingProject.PageObjectModel
{
    class ListCustomersPage : BasePage
    {
        readonly By searchCustomerInput = By.XPath("//intpu[@ng-model='searchCustomer']");
        readonly By customerTable = By.TagName("table");

        By DeleteCustomerLocator(string accountId)
        {
            By deleteBtn = By.XPath("//span[contains(.,'" + accountId + "')]/../..//button");
            return deleteBtn;
        }


        public ListCustomersPage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.ListCustomers;
        }

        public void SearchCustomer(string value)
        {
            driver.WaitUtil(searchCustomerInput).SendKeys(value);
        }

        public List<Customer> GetCustomerInformation()
        {
            List<Customer> result = new List<Customer>();
            var items = driver.Table(customerTable).GetTableData();
            foreach (var item in items)
            {
                string firstName = item[0];
                string lastName = item[1];
                string postCode = item[2];
                var accountNumbers = item[3].Split(" ").ToList();
                Customer customer = new Customer(firstName, lastName, postCode, accountNumbers);
                result.Add(customer);
            }
            return result;
        }

        public void VerifyListCustomerTable(int numberOfItem)
        {
            var currentNumberOfItem = GetCustomerInformation().Count;

            currentNumberOfItem.Should().Be(numberOfItem);
        }

        public void VerifyCustomerIsExisted(Customer customer)
        {
            var customers = GetCustomerInformation();

            customers.Should().ContainEquivalentOf(customer);
        }

        public void DeleteCustomer(string accountId) {
            driver.WaitUtil(DeleteCustomerLocator(accountId)).Click();
        }
    }
}
