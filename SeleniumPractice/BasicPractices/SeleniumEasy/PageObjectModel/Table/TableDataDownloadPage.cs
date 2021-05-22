using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumPractice.Commons.DataProcess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using TextCopy;

namespace SeleniumPractice.SeleniumEasy.PageObjectModel
{
    class TableDataDownloadPage : BasePage
    {
        readonly By copyBtn = By.ClassName("buttons-copy");
        readonly By excelBtn = By.ClassName("buttons-excel");
        readonly By pdfBtn = By.ClassName("buttons-pdf");
        readonly By printBtn = By.ClassName("buttons-print");
        readonly By nameSorting = By.XPath("//th[text()='Name']");
        readonly By csvBtn = By.ClassName("buttons-csv");
        readonly By seachInput = By.XPath("//*[@id='example_filter']/label/input");

        static string pathUser = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        static string csvFilePath = pathUser + @"\Downloads\Selenium Easy - Download Table Data to CSV, Excel, PDF and Print.csv";
        static string excelFilePath = pathUser + @"\Downloads\Selenium Easy - Download Table Data to CSV, Excel, PDF and Print.xlsx";
        static string pdfFilePath = pathUser + @"\Downloads\Selenium Easy - Download Table Data to CSV, Excel, PDF and Print.pdf";

        public TableDataDownloadPage(IWebDriver driver)
        {
            this.driver = driver;
            this.pageUrl = WebUrl.TableDataDownload;
        }

        public void SortByName()
        {
            driver.WaitUtil(nameSorting).Click();
        }

        public List<List<string>> CopyTable()
        {
            driver.WaitUtil(copyBtn).Click();
            string clipboardText = ClipboardService.GetText();
            var rowData = clipboardText.Split("\r\n").ToList();
            var tableData = rowData.Select(s => s.Split("\t").ToList()).ToList();
            return tableData;
        }

        public List<List<string>> DownloadCsvTable()
        {
            List<List<string>> result;
            driver.WaitUtil(csvBtn).Click();

            driver.Sleep(3000);
            var rowsData = FileAccess.ReadText(csvFilePath).Split("\r\n");
            result = rowsData.Select(s => s.Split("\",\"").Select(s => s.Replace("\"", "")).ToList()).ToList();

            return result;
        }

        public List<string> DownloadPdfTable()
        {
            List<string> result;
            driver.WaitUtil(pdfBtn).Click();

            driver.Sleep(5000);
            result = FileHelper.ReadPdf(pdfFilePath).Split("\n").ToList();

            return result;
        }

        public List<string> PrintAndDownloadPdfTable()
        {
            List<string> result = null;
            driver.WaitUtil(printBtn).Click();

            return result;
        }

        public List<List<string>> DownloadExcelTable()
        {
            List<List<string>> result;
            driver.WaitUtil(excelBtn).Click();

            driver.Sleep(3000);
            result = FileAccess.ReadExcel(excelFilePath, 0, false).AsEnumerable().Select(x => x.ItemArray.Select(s => s.ToString()).ToList()).ToList();
            return result;
        }

        public void CleanUpDownloadFolder()
        {
            List<string> paths = new List<string>();
            paths.Add(csvFilePath);
            paths.Add(excelFilePath);
            paths.Add(pdfFilePath);

            foreach (string path in paths)
            {
                try
                {
                    File.Delete(path);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void Search(string input)
        {
            driver.WaitUtil(seachInput).SendKeys(input);
        }

        public void VerifyDataTable(List<List<string>> expectedDataTable, List<List<string>> currentDataTable)
        {
            Assert.AreEqual(expectedDataTable, currentDataTable);
        }

        public void VerifyPdfFile(List<List<string>> expectedDataTable, List<string> fileContent)
        {
            string fileTitle = "Selenium Easy - Download Table Data to CSV, Excel, PDF and Print";

            Assert.AreEqual(fileTitle, fileContent[0]);
            fileContent.RemoveAt(0);

            List<string> expectedPdfContent = new List<string>();
            foreach (var row in expectedDataTable)
            {
                string rowItem = "";
                foreach (var cell in row)
                {
                    rowItem = rowItem + cell + " ";
                }
                rowItem = rowItem.Remove(rowItem.Length - 1);
                expectedPdfContent.Add(rowItem);
            }

            Assert.AreEqual(expectedPdfContent, fileContent);

        }


    }
}
