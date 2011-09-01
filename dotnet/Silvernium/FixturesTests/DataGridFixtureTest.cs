using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class DataGridFixtureTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void RequireCellPresentPassesForPresentCell()
        {
            App.DataGrid("musiciansDataGrid")
                .RequireCellPresent("Alex")
                .RequireCellPresent("Geddy")
                .RequireCellPresent("Neil")
                .RequireCellPresent("Guitar")
                .RequireCellPresent("Bass")
                .RequireCellPresent("Drums");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireCellPresentThrowsExceptionForAbsentCell()
        {
            App.DataGrid("musiciansDataGrid").RequireCellPresent("Kenny G");
        }

        [TestMethod]
        public void RequireCellAbsentPassesForAbsentCell()
        {
            App.DataGrid("musiciansDataGrid").RequireCellAbsent("Sax");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireCellAbsentThrowsExceptionForPresentCell()
        {
            App.DataGrid("musiciansDataGrid").RequireCellAbsent("Drums");
        }

        [TestMethod]
        public void RowContainingReturnsAFixtureForTheRespectiveRow()
        {
            var dataGrid = App.DataGrid("musiciansDataGrid");
            dataGrid.RowContaining("Alex").RequireIndex(0);
            dataGrid.RowContaining("Geddy").RequireIndex(1);
            dataGrid.RowContaining("Neil").RequireIndex(2);
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RowContainingThrowsExceptionIfThereIsNoRowContainingTheExpectedValue()
        {
            App.DataGrid("musiciansDataGrid").RowContaining("Kenny G");
        }

        [TestMethod]
        public void RowByIndexReturnsAFixtureForTheRespectiveRow()
        {
            var dataGrid = App.DataGrid("musiciansDataGrid");
            dataGrid.RowByIndex(0).RequireIndex(0);
            dataGrid.RowByIndex(1).RequireIndex(1);
            dataGrid.RowByIndex(2).RequireIndex(2);
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RowByIndexThrowsExceptionIfRowIndexIsOutOfBounds()
        {
            App.DataGrid("musiciansDataGrid").RowByIndex(3);
        }

        [TestMethod]
        public void RequireRowCountPassesForExpectedRowCount()
        {
            App.DataGrid("musiciansDataGrid").RequireRowCount(3);
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireRowCountThrowsExceptionForUnexpectedRowCount()
        {
            App.DataGrid("musiciansDataGrid").RequireRowCount(4);
        }

    }
}
