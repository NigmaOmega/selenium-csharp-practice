using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class FileDownload : BaseTest
    {
        FileDownloadPage fileDownloadPage;
        readonly string fileContent = DataGenerator.GenerateString(100);

        [SetUp]
        public void ClassSetUp()
        {
            fileDownloadPage = new FileDownloadPage(driver);
            fileDownloadPage.GoTo();
            fileDownloadPage.CleanUpDownloadFolder();
        }

        [Test]
        public void GenerateFile_Successfully()
        {
            fileDownloadPage.GenerateFile(fileContent);
            fileDownloadPage.VerifyDownloadButtonIsShow();
        }


        [Test]
        public void DownloadFile_Successfully()
        {
            fileDownloadPage.GenerateFile(fileContent);
            fileDownloadPage.DownloadFile();
            fileDownloadPage.VerifyFileDownloaded(fileContent);
        }

        [Test]
        public void InputFieldIsSetExceedMaximumLengthOfText_NoLitmitIsSet()
        {
            int lengthOfText = 555;
            fileDownloadPage.GenerateFile(DataGenerator.GenerateString(lengthOfText));
            fileDownloadPage.VerifyLengthOfTextOfDataInputField(lengthOfText);
        }



    }
}
