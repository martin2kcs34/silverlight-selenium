using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class DataRowFixtureTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void SelectSelectsTheRow()
        {
            var dataGrid = App.DataGrid("musiciansDataGrid");
            var textBlock = App.TextBlock("musicianTextBlock");

            dataGrid.RowByIndex(0).Select();
            textBlock.RequireText("Alex plays Guitar");
            dataGrid.RowByIndex(1).Select();
            textBlock.RequireText("Geddy plays Bass");
            dataGrid.RowByIndex(2).Select();
            textBlock.RequireText("Neil plays Drums");
        }

        [TestMethod]
        public void RequireIndexPassesForExpectedIndex()
        {
            var dataGrid = App.DataGrid("musiciansDataGrid");
            dataGrid.RowContaining("Alex").RequireIndex(0);
            dataGrid.RowContaining("Geddy").RequireIndex(1);
            dataGrid.RowContaining("Neil").RequireIndex(2);
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireIndexThrowsExceptionForUnexpectedIndex()
        {
            App.DataGrid("musiciansDataGrid").RowContaining("Alex").RequireIndex(1);
        }

    }
}
