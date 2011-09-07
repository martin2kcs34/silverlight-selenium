using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class ButtonFixtureWithinDataGridTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void ClickClicks()
        {
            var dataGrid = App.DataGrid("editableDataGrid");

            dataGrid.RowByIndex(0).Button("innerButton").Click();
            App.TextBlock("messageTextBlock").RequireText("Clicked at Button 1");
            App.Button("okButton").Click();

            dataGrid.RowByIndex(1).Button("innerButton").Click();
            App.TextBlock("messageTextBlock").RequireText("Clicked at Button 2");
            App.Button("okButton").Click();
        }

        [TestMethod]
        public void RequireContentPassesForExpectedContent()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).Button("innerButton").RequireContent("Button 1");
            dataGrid.RowByIndex(1).Button("innerButton").RequireContent("Button 2");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireContentThrowsExceptionForUnexpectedContent()
        {
            App.DataGrid("editableDataGrid").RowByIndex(0).Button("innerButton").RequireContent("This is not the Button content");
        }

        [TestMethod]
        public void RequireEnabledPassesForExpectedState()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).Button("innerButton").RequireEnabled();
            dataGrid.RowByIndex(1).Button("innerButton").RequireEnabled();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireEnabledThrowsExceptionForUnexpectedState()
        {
            App.DataGrid("editableDataGrid").RowByIndex(2).Button("innerButton").RequireEnabled();
        }

        [TestMethod]
        public void RequireDisabledPassesForExpectedState()
        {
            App.DataGrid("editableDataGrid").RowByIndex(2).Button("innerButton").RequireDisabled();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireDisabledThrowsExceptionForUnexpectedState()
        {
            App.DataGrid("editableDataGrid").RowByIndex(0).Button("innerButton").RequireDisabled();
        }

    }
}
