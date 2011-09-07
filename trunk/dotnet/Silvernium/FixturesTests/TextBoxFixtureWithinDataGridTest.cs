using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class TextBoxFixtureWithinDataGridTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void RequireTextPassesForCorrectValues()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBox("innerTextBox").RequireText("TextBox 1");
            dataGrid.RowByIndex(1).TextBox("innerTextBox").RequireText("TextBox 2");
            dataGrid.RowByIndex(2).TextBox("innerTextBox").RequireText("TextBox 3");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireTextThrowsExceptionForIncorrectValues()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBox("innerTextBox").RequireText("TextBox 2");
        }

        [TestMethod]
        public void RequireContainsPassesForExactValues()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBox("innerTextBox").RequireContains("TextBox 1");
            dataGrid.RowByIndex(1).TextBox("innerTextBox").RequireContains("TextBox 2");
            dataGrid.RowByIndex(2).TextBox("innerTextBox").RequireContains("TextBox 3");
        }
        
        [TestMethod]
        public void RequireContainsPassesForPartialValues()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBox("innerTextBox").RequireContains("Box 1");
            dataGrid.RowByIndex(1).TextBox("innerTextBox").RequireContains("Box 2");
            dataGrid.RowByIndex(2).TextBox("innerTextBox").RequireContains("Box 3");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireContainsThrowsExceptionForIncorrectValues()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBox("innerTextBox").RequireContains("Box 2");
        }

        [TestMethod]
        public void RequireNotContainsPassesForAbsentValues()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBox("innerTextBox").RequireNotContains("NotABox 1");
            dataGrid.RowByIndex(1).TextBox("innerTextBox").RequireNotContains("NotABox 2");
            dataGrid.RowByIndex(2).TextBox("innerTextBox").RequireNotContains("NotABox 3");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireNotContainsThrowsExceptionForPresentValues()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBox("innerTextBox").RequireNotContains("Box 1");
        }

        [TestMethod]
        public void SetTextChangesTextBoxValue()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBox("innerTextBox")
                .RequireText("TextBox 1")
                .SetText("TextBox 1a")
                .RequireText("TextBox 1a")
                .SetText("TextBox 1");
            dataGrid.RowByIndex(1).TextBox("innerTextBox")
                .RequireText("TextBox 2")
                .SetText("TextBox 2a")
                .RequireText("TextBox 2a")
                .SetText("TextBox 2");
        }

        [TestMethod]
        public void RequireEnabledPassesForExpectedState()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBox("innerTextBox").RequireEnabled();
            dataGrid.RowByIndex(1).TextBox("innerTextBox").RequireEnabled();
        }
        
        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireEnabledThrowsExceptionForUnexpectedState()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(2).TextBox("innerTextBox").RequireEnabled();
        }

        [TestMethod]
        public void RequireDisabledPassesForExpectedState()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(2).TextBox("innerTextBox").RequireDisabled();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireDisabledThrowsExceptionForUnexpectedState()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBox("innerTextBox").RequireDisabled();
        }

    }

}
