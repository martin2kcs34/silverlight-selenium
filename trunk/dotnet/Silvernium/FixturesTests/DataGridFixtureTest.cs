using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        [TestMethod]
        public void GoToPageContainingGoesToTheRightPage()
        {
            var dataGrid = App.DataGrid("booksDataGrid", "booksDataPager");
            dataGrid
                .GoToPageContaining("The Unbearable Lightness of Being").RequireCellPresent("Milan Kundera")
                .GoToPageContaining("The Lord of The Rings").RequireCellPresent("J.R.R. Tolkien")
                .GoToPageContaining("O Tempo e o Vento").RequireCellPresent("Erico Verissimo")
                .GoToPageContaining("Los Siete Locos").RequireCellPresent("Roberto Arlt")
                .GoToPageContaining("La Invencion de Morel").RequireCellPresent("Adolfo Bioy Casares")
                .GoToPageContaining("For Whom the Bell Tolls").RequireCellPresent("Ernest Hemingway")
                .GoToPageContaining("Dom Casmurro").RequireCellPresent("Machado de Assis")
                .GoToPageContaining("Cien Anos de Soledad").RequireCellPresent("Gabriel Garcia Marquez")
                .GoToPageContaining("2001 - A Space Odissey").RequireCellPresent("Arthur C. Clarke");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void GoToPageContainingThrowsExceptionIfThereIsNoPageContaningTheExpectedValue()
        {
            App.DataGrid("booksDataGrid", "booksDataPager").GoToPageContaining("Paulo Coelho");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void GoToPageContainingThrowsExceptionIfTheDataGridHasNoDataPager()
        {
            App.DataGrid("musiciansDataGrid").GoToPageContaining("Drums");
        }

    }
}
