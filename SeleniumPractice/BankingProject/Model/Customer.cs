using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPractice.Demo.BankingProject.Model
{
    class Customer
    {
        public Customer(string firstName, string lastName, string postCode) {
            FirstName = firstName;
            LastName = lastName;
            PostCode = postCode;
        }

        public Customer(string firstName, string lastName, string postCode, List<string> accountNumbers)
        {
            FirstName = firstName;
            LastName = lastName;
            PostCode = postCode;
            AccountNumbers = accountNumbers;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PostCode { get; set; }
        public List<string> AccountNumbers { get; set; }
    }
}
