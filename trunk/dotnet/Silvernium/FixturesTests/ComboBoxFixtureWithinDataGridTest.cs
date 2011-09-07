using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class ComboBoxFixtureWithinDataGridTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void RequireValuePassesForCorrectValues()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).ComboBox("innerComboBox").RequireValue("Option 1");
            dataGrid.RowByIndex(1).ComboBox("innerComboBox").RequireValue("Option 2");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireValueThrowsExceptionForIncorrectValue()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).ComboBox("innerComboBox").RequireValue("Option 2");
        }

        [TestMethod]
        public void SetValueChangesComboBoxValue()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).ComboBox("innerComboBox")
                .RequireValue("Option 1")
                .SetValue("Option 2")
                .RequireValue("Option 2")
                .SetValue("Option 1");
            dataGrid.RowByIndex(1).ComboBox("innerComboBox")
                .RequireValue("Option 2")
                .SetValue("Option 1")
                .RequireValue("Option 1")
                .SetValue("Option 2");
        }

        [TestMethod]
        public void RequireEnabledPassesForExpectedState()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).ComboBox("innerComboBox").RequireEnabled();
            dataGrid.RowByIndex(1).ComboBox("innerComboBox").RequireEnabled();
        }
        
        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireEnabledThrowsExceptionForUnexpectedState()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(2).ComboBox("innerComboBox").RequireEnabled();
        }

        [TestMethod]
        public void RequireDisabledPassesForExpectedState()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(2).ComboBox("innerComboBox").RequireDisabled();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireDisabledThrowsExceptionForUnexpectedState()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).ComboBox("innerComboBox").RequireDisabled();
        }

    }

}
