using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class FileDownloadPage : BasePage
    {
        readonly string downloadFolder;
        readonly By dataInput = By.Id("textbox");
        readonly By generateFileBtn = By.Id("create");
        readonly By downloadBtn = By.Id("link-to-download");

        public FileDownloadPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.FileDownload;
            downloadFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
        }

        public void GenerateFile(string text)
        {
            driver.WaitUtil(dataInput).SendKeys(text);
            driver.WaitUtil(generateFileBtn).Click();

        }

        public void VerifyDownloadButtonIsShow()
        {
            var IsDisplayed = driver.WaitUtil(downloadBtn).Displayed;

            Assert.IsTrue(IsDisplayed);
        }

        public void DownloadFile()
        {
            driver.WaitUtil(downloadBtn).Click();
            driver.Sleep(5000);
        }

        public void CleanUpDownloadFolder()
        {
            try
            {
                File.Delete(downloadFolder + "\\easyinfo.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void VerifyFileDownloaded(string value)
        {
            var fileContent = FileAccess.ReadText(downloadFolder + "\\easyinfo.txt");

            Assert.AreEqual(value, fileContent);
        }

        public void VerifyLengthOfTextOfDataInputField(int lengthOfText)
        {
            var currentLength = driver.WaitUtil(dataInput).GetAttribute("value").Length;

            Assert.AreEqual(lengthOfText, currentLength);
        }
    }
}
