using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.AdvancePractices.BankingProject
{
    public static class WebUrl
    {
        private static readonly string BasePage = "https://www.globalsqa.com/angularJs-protractor";
        public static string Home = BasePage + "/BankingProject/#/login";
        public static string CustomerLogin = BasePage + "/BankingProject/#/customer";
        public static string CustomerAccount = BasePage + "/BankingProject/#/account";
        public static string CustomerTranaction = BasePage + "/BankingProject/#/listTx";
        public static string Manager = BasePage + "/BankingProject/#/manager";
        public static string AddCustomer = BasePage + "/BankingProject/#/manager/addCust";
        public static string OpenAccount = BasePage + "/BankingProject/#/manager/openAccount";
        public static string ListCustomers = BasePage + "/BankingProject/#/manager/list";

    }
}
