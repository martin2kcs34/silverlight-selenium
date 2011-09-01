using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThoughtWorks.Selenium.Silvernium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium;
using System.Threading;

namespace DBServer.Selenium.Silvernium.Fixtures
{
    public class DataGridFixture : ComponentFixture
    {
        protected string PagerPath { get; set; }

        public DataGridFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string path)
            : base(silvernium, path) { }

        public DataGridFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string path, string pagerPath)
            : base(silvernium, path)
        {
            PagerPath = pagerPath;
            AssertPathPresent(pagerPath);
        }

        public DataRowFixture RowContaining(string value)
        {
            var cellPresent = CellPresentCondition(value);
            Wait(cellPresent);
            var rowIndex = Silvernium.Call("RowContaining", Path, value);
            if (string.IsNullOrEmpty(rowIndex))
                throw new SilverniumFixtureException("Unable to find row containing value " + value);
            return new DataRowFixture(Silvernium, Path, int.Parse(rowIndex));
        }

        public DataRowFixture RowByIndex(int index)
        {
            var rowCount = RowCount();
            if (index >= rowCount)
            {
                throw new SilverniumFixtureException("Row index out of bounds (requested row index: " 
                    + index + " actual row count: " + rowCount + ")");
            }
            return new DataRowFixture(Silvernium, Path, index);
        }

        public DataGridFixture RequireRowCount(int rowCount)
        {
            var actualRowCount = RowCount();
            if (actualRowCount != rowCount)
            {
                throw new SilverniumFixtureException("Unexpected row count (expected: "
                    + rowCount + " actual: " + actualRowCount + ")");
            }
            return this;
        }

        private int RowCount()
        {
            return int.Parse(Call("RowCount", Path));
        }

        public DataGridFixture RequireCellPresent(string value)
        {
            var cellPresent = CellPresentCondition(value);
            Wait(cellPresent);
            if (!cellPresent())
                throw new SilverniumFixtureException("Unable to find cell with value " + value);
            return this;
        }

        public DataGridFixture RequireCellAbsent(string value)
        {
            var cellPresent = CellPresentCondition(value);
            Wait(cellPresent);
            if (cellPresent())
                throw new SilverniumFixtureException("Unexpected cell was found with value " + value);
            return this;
        }

        //public DataGridFixture GoToPageContaining(string value)
        //{
        //    if (PagerPath == null)
        //        Assert.Fail("This is not a paged grid");

        //    Wait(GridContainsAtLeastOneRowCondition());
        //    Thread.Sleep(1000);

        //    var page = Silvernium.Call("GoToPageContaining", Path, PagerPath, value);
        //    if (page == string.Empty)
        //        Assert.Fail("Could not find page containing value " + value);
        //    return this;
        //}

        //private Condition GridContainsAtLeastOneRowCondition()
        //{
        //    return delegate
        //    {
        //        var invocationResult = Silvernium.Call("Count", Path);
        //        return !string.IsNullOrEmpty(invocationResult);
        //    };
        //}

        private Condition CellPresentCondition(string value)
        {
            return delegate
            {
                var result = Call("IsCellPresent", Path, value);
                return (result == true.ToString());
            };
        }

    }
}
