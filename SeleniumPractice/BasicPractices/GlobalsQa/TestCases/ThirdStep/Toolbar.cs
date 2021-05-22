using NUnit.Framework;
using SeleniumPractice.BasicPractices.GlobalsQa.PageObjectModel.ThirdStep;

namespace SeleniumPractice.BasicPractices.GlobalsQa.TestCases.ThirdStep
{
    class Toolbar : BaseTest
    {
        ToolbarPage toolbarPage;

        [SetUp]
        public void ClassSetUp()
        {
            toolbarPage = new ToolbarPage(driver);
            toolbarPage.GoTo();
        }

        [Test]
        public void RunLastOptions()
        {
            toolbarPage.RunLastOptions();
            toolbarPage.VerifyOutputIsShown("Running Last Action...");
        }


        [Test]
        public void SelectSaveOption()
        {
            toolbarPage.SelectOptionItem("Save");
            toolbarPage.VerifyOutputIsShown("Save");
        }


        [Test]
        public void SelectOpenOption()
        {
            toolbarPage.SelectOptionItem("Delete");
            toolbarPage.SelectOptionItem("Open...");
            toolbarPage.VerifyOutputIsShown("Open...");
        }

        [Test]
        public void SelectDeleteOption()
        {
            toolbarPage.SelectOptionItem("Delete");
            toolbarPage.VerifyOutputIsShown("Delete");
        }
    }
}
