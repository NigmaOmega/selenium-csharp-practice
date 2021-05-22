using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class TableDataDownload : BaseTest
    {
        TableDataDownloadPage tableDataDownloadPage;
        List<List<string>> tableData;
        List<string> tableTitle;
        List<List<string>> fullTableData;
        readonly string searchText = "Tok";

        [SetUp]
        public void ClassSetUp()
        {
            tableDataDownloadPage = new TableDataDownloadPage(driver);
            tableDataDownloadPage.GoTo();
            tableDataDownloadPage.CleanUpDownloadFolder();

            string filePath = Directory.GetCurrentDirectory() + @"\SeleniumEasy\Resource\DataTableDownload.csv";
            var rowsData = FileAccess.ReadText(filePath).Split("\r\n");
            fullTableData = rowsData.Select(s => s.Split("\",\"").Select(s => s.Replace("\"", "")).ToList()).ToList();
            tableTitle = fullTableData[0];
            tableData = fullTableData.GetRange(1, fullTableData.Count - 1);
        }

        [Test]
        public void CopyTable_Successfully()
        {
            var currentTableData = tableDataDownloadPage.CopyTable();

            tableDataDownloadPage.VerifyDataTable(fullTableData, currentTableData);
        }

        [Test]
        public void SortingNameThenCopyTable_SortingWorkCorrectly()
        {
            tableDataDownloadPage.SortByName();
            var currentTableData = tableDataDownloadPage.CopyTable();
            var expectedTableData = tableData.OrderByDescending(s => s[0]).ToList();
            expectedTableData.Insert(0, tableTitle);

            tableDataDownloadPage.VerifyDataTable(expectedTableData, currentTableData);
        }

        [Test]
        public void SearchThenCopyTable_SearchWorkCorrectly()
        {

            tableDataDownloadPage.Search(searchText);
            var currentTableData = tableDataDownloadPage.CopyTable();
            var expectedTableData = tableData.Where(s => s.Where(k => k.Contains(searchText)).ToList().Count > 0).ToList();
            expectedTableData.Insert(0, tableTitle);

            tableDataDownloadPage.VerifyDataTable(expectedTableData, currentTableData);
        }

        [Test]
        public void DownloadCsvFile_Successfully()
        {
            var currentTableData = tableDataDownloadPage.DownloadCsvTable();

            tableDataDownloadPage.VerifyDataTable(fullTableData, currentTableData);
        }

        [Test]
        public void SearchThenDownloadCsvFile_SearchWorkCorrectly()
        {

            tableDataDownloadPage.Search(searchText);
            var currentTableData = tableDataDownloadPage.DownloadCsvTable();
            var expectedTableData = tableData.Where(s => s.Where(k => k.Contains(searchText)).ToList().Count > 0).ToList();
            expectedTableData.Insert(0, tableTitle);
            tableDataDownloadPage.VerifyDataTable(expectedTableData, currentTableData);
        }

        [Test]
        public void SortingNameThenDownloadCsvFile_SortingWorkCorrectly()
        {
            tableDataDownloadPage.SortByName();
            var currentTableData = tableDataDownloadPage.DownloadCsvTable();
            var expectedTableData = tableData.OrderByDescending(s => s[0]).ToList();
            expectedTableData.Insert(0, tableTitle);

            tableDataDownloadPage.VerifyDataTable(expectedTableData, currentTableData);
        }


        [Test]
        public void DownloadExcelFile_Successfully()
        {
            var currentTableData = tableDataDownloadPage.DownloadExcelTable();

            tableDataDownloadPage.VerifyDataTable(fullTableData, currentTableData);
        }

        [Test]
        public void SearchThenDownloadExcelFile_SearchWorkCorrectly()
        {

            tableDataDownloadPage.Search(searchText);
            var currentTableData = tableDataDownloadPage.DownloadExcelTable();
            var expectedTableData = tableData.Where(s => s.Where(k => k.Contains(searchText)).ToList().Count > 0).ToList();
            expectedTableData.Insert(0, tableTitle);
            tableDataDownloadPage.VerifyDataTable(expectedTableData, currentTableData);
        }

        [Test]
        public void SortingNameThenDownloadExcelFile_SortingWorkCorrectly()
        {
            tableDataDownloadPage.SortByName();
            var currentTableData = tableDataDownloadPage.DownloadExcelTable();
            var expectedTableData = tableData.OrderByDescending(s => s[0]).ToList();
            expectedTableData.Insert(0, tableTitle);

            tableDataDownloadPage.VerifyDataTable(expectedTableData, currentTableData);
        }

        [Test]
        public void DownloadPdfFile_Successfully()
        {
            var pdfFileContent = tableDataDownloadPage.DownloadPdfTable();

            tableDataDownloadPage.VerifyPdfFile(fullTableData, pdfFileContent);
        }


        [Test]
        public void SearchThenDownloadPdfFile_Successfully()
        {
            tableDataDownloadPage.Search(searchText);
            var pdfFileContent = tableDataDownloadPage.DownloadPdfTable();

            var expectedTableData = tableData.Where(s => s.Where(k => k.Contains(searchText)).ToList().Count > 0).ToList();
            expectedTableData.Insert(0, tableTitle);

            tableDataDownloadPage.VerifyPdfFile(expectedTableData, pdfFileContent);
        }

        [Test]
        public void SortingNameThenDownloadPdfFile_SortingWorkCorrectly()
        {
            tableDataDownloadPage.SortByName();
            var pdfFileContent = tableDataDownloadPage.DownloadPdfTable();
            var expectedTableData = tableData.OrderByDescending(s => s[0]).ToList();
            expectedTableData.Insert(0, tableTitle);

            tableDataDownloadPage.VerifyPdfFile(expectedTableData, pdfFileContent);
        }

        [Test]
        public void PrintDataTable_Successfully()
        {
            //TODO
        }
    }
}
