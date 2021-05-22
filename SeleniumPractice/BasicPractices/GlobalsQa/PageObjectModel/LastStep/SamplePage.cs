using OpenQA.Selenium;
using SeleniumPractice.GlobalsQa;
using System.Collections.Generic;

namespace SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.LastStep
{
    class SamplePage : BasePage
    {
        By chooseFile = By.XPath("//input[contains(@name,'file-')]");
        By nameInput = By.ClassName("name");
        By emailInput = By.ClassName("email");
        By websiteInput = By.ClassName("url");
        By experienceSelect = By.ClassName("select");
        By expertiseCheckboxOptions = By.ClassName("checkbox-multiple");
        By educationRadioOptions = By.ClassName("radio");
        By alertBoxBtn = By.XPath("//button[text()='Alert Box : Click Here']");
        By commentInput = By.ClassName("textarea");
        By submitBtn = By.ClassName("pushbutton-wide");
        public SamplePage(IWebDriver driver)
        {
            this.driver = driver;
            this.url = WebUrl.Windows;
        }

        public void FillDataIntoPage(string filePath, string name, string email, string website, string experience, List<string> expertises, string education, string comment)
        {
            driver.WaitUtil(chooseFile).SendKeys(filePath);
            driver.WaitUtil(nameInput).SendKeys(name);
            driver.WaitUtil(emailInput).SendKeys(email);
            driver.WaitUtil(websiteInput).SendKeys(website);
            driver.Select(experienceSelect).ByText(experience);
            driver.Checkbox(expertiseCheckboxOptions).ByValues(expertises);
            driver.Radio(educationRadioOptions).ByValue(education);
            driver.WaitUtil(alertBoxBtn).SendKeys(name);
            driver.WaitUtil(commentInput).SendKeys(name);
            driver.WaitUtil(submitBtn).Click();
        }
    }
}
