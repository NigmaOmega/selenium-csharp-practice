using NUnit.Framework;
using SeleniumPractice.SeleniumEasy.PageObjectModel;
using System.Collections.Generic;

namespace SeleniumPractice.SeleniumEasy.TestCases
{
    class BootstrapListBox : BaseTest
    {
        BootstrapListBoxPage bootstrapListBoxPage;

        List<string> items;

        [SetUp]
        public void ClassSetUp()
        {
            bootstrapListBoxPage = new BootstrapListBoxPage(driver);
            bootstrapListBoxPage.GoTo();

            items = new List<string>();
            items.Add("Dapibus ac facilisis in");
            items.Add("Morbi leo risus");
        }

        [Test]
        public void MoveItemsToRight_Successfully()
        {
            bootstrapListBoxPage.MoveRightItems(items);
            bootstrapListBoxPage.VerifyRightItems(7);
        }

        [Test]
        public void MoveItemsToLeft_Successfully()
        {
            bootstrapListBoxPage.MoveLeftItems(items);
            bootstrapListBoxPage.VerifyLeftItems(7);
        }

        [Test]
        public void AllItemsToRight_Successfully()
        {
            bootstrapListBoxPage.MoveRightAllItems();
            bootstrapListBoxPage.VerifyRightItems(10);
        }

        [Test]
        public void AllItemsToLeft_Successfully()
        {
            bootstrapListBoxPage.MoveLeftAllItems();
            bootstrapListBoxPage.VerifyLeftItems(10);
        }

        [Test]
        public void SearchItemInLeftList_Successfully()
        {
            bootstrapListBoxPage.SearchLeft("Se");
            bootstrapListBoxPage.VerifyLeftItems(1);
        }

        [Test]
        public void SearchItemInRightList_Successfully()
        {
            bootstrapListBoxPage.SearchRight("Se");
            bootstrapListBoxPage.VerifyRightItems(1);
        }

        [Test]
        public void MoveItemsLeftAndRight_Successfully()
        {
            bootstrapListBoxPage.MoveLeftAllItems();
            bootstrapListBoxPage.MoveRightAllItems();
            bootstrapListBoxPage.VerifyRightItems(10);
        }

        [Test]
        public void MoveItemsRightAndLeft_Successfully()
        {
            bootstrapListBoxPage.MoveRightAllItems();
            bootstrapListBoxPage.MoveLeftAllItems();
            bootstrapListBoxPage.VerifyLeftItems(10);
        }

        [Test]
        public void CheckeAllLeftItems_Successfully()
        {
            bootstrapListBoxPage.ClickOnCheckAllLeftItems();
            bootstrapListBoxPage.VerifyLeftItemsIsChecked(5);
        }

        [Test]
        public void CheckeAllRightItems_Successfully()
        {
            bootstrapListBoxPage.ClickOnCheckAllRightItems();
            bootstrapListBoxPage.VerifyRightItemsIsChecked(5);
        }


        [Test]
        public void UncheckeAllLeftItems_Successfully()
        {
            bootstrapListBoxPage.ClickOnCheckAllLeftItems();
            bootstrapListBoxPage.ClickOnCheckAllLeftItems();
            bootstrapListBoxPage.VerifyLeftItemsIsChecked(0);
        }

        [Test]
        public void UncheckeAllRightItems_Successfully()
        {
            bootstrapListBoxPage.ClickOnCheckAllRightItems();
            bootstrapListBoxPage.ClickOnCheckAllRightItems();
            bootstrapListBoxPage.VerifyRightItemsIsChecked(0);
        }


    }
}
