using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class CheckBoxFixtureWithinDataGridTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void CheckCheckes()
        {
            App.DataGrid("editableDataGrid").RowByIndex(1).CheckBox("innerCheckBox")
                .RequireUnchecked()
                .Check()
                .RequireChecked()
                .Uncheck();
        }

        [TestMethod]
        public void UncheckUncheckes()
        {
            App.DataGrid("editableDataGrid").RowByIndex(0).CheckBox("innerCheckBox")
                .RequireChecked()
                .Uncheck()
                .RequireUnchecked()
                .Check();
        }

        [TestMethod]
        public void RequireCheckedPassesIfCheckBoxIsChecked()
        {
            App.DataGrid("editableDataGrid").RowByIndex(0).CheckBox("innerCheckBox").RequireChecked();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireCheckedThrowsExceptionIfCheckBoxIsUnchecked()
        {
            App.DataGrid("editableDataGrid").RowByIndex(1).CheckBox("innerCheckBox").RequireChecked();
        }

        [TestMethod]
        public void RequireUncheckedPassesIfCheckBoxIsUnchecked()
        {
            App.DataGrid("editableDataGrid").RowByIndex(1).CheckBox("innerCheckBox").RequireUnchecked();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireUncheckedThrowsExceptionIfCheckBoxIsChecked()
        {
            App.DataGrid("editableDataGrid").RowByIndex(0).CheckBox("innerCheckBox").RequireUnchecked();
        }

    }
}
