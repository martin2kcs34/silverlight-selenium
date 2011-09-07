using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class TextBlockFixtureWithinDataGridTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void RequireTextPassesForCorrectValues()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBlock("innerTextBlock").RequireText("TextBlock 1");
            dataGrid.RowByIndex(1).TextBlock("innerTextBlock").RequireText("TextBlock 2");
            dataGrid.RowByIndex(2).TextBlock("innerTextBlock").RequireText("TextBlock 3");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireTextThrowsExceptionForIncorrectValues()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBlock("innerTextBlock").RequireText("TextBlock 2");
        }

        [TestMethod]
        public void RequireContainsPassesForExactValues()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBlock("innerTextBlock").RequireContains("TextBlock 1");
            dataGrid.RowByIndex(1).TextBlock("innerTextBlock").RequireContains("TextBlock 2");
            dataGrid.RowByIndex(2).TextBlock("innerTextBlock").RequireContains("TextBlock 3");
        }

        [TestMethod]
        public void RequireContainsPassesForPartialValues()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBlock("innerTextBlock").RequireContains("Block 1");
            dataGrid.RowByIndex(1).TextBlock("innerTextBlock").RequireContains("Block 2");
            dataGrid.RowByIndex(2).TextBlock("innerTextBlock").RequireContains("Block 3");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireContainsThrowsExceptionForIncorrectValues()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBlock("innerTextBlock").RequireContains("Block 2");
        }

        [TestMethod]
        public void RequireNotContainsPassesForAbsentValues()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBlock("innerTextBlock").RequireNotContains("Block 2");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireNotContainsThrowsExceptionForPresentValues()
        {
            var dataGrid = App.DataGrid("editableDataGrid");
            dataGrid.RowByIndex(0).TextBlock("innerTextBlock").RequireNotContains("Block 1");
        }

    }
}
