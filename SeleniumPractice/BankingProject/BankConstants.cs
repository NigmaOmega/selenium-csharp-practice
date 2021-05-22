using SeleniumPractice.AdvancePractices.BankingProject.Model;
using SeleniumPractice.Demo.BankingProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.Demo.BankingProject
{
    static class BankConstants
    {
        public static string DefaultCustomerName = "Harry Potter";
        public static string DefaultCurrency = "Dollar";

        public static Account CustomerAccountValid = new Account(DefaultCustomerName, "1004", 0 , DefaultCurrency);
        public static Account CustomerAccountValidOther = new Account(DefaultCustomerName, "1005", 0, "Pound");


    }
}
