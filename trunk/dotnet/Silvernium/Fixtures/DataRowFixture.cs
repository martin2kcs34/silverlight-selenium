using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBServer.Selenium.Silvernium.Fixtures;
using ThoughtWorks.Selenium.Silvernium;

namespace DBServer.Selenium.Silvernium.Fixtures
{
    public class DataRowFixture : ComponentFixture
    {
        protected int Index { get; set; }

        public DataRowFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string path, int index)
            : base(silvernium, path)
        {
            Index = index;
        }

        //public ComboBoxCellFixture ComboBoxCell(string name)
        //{
        //    return new ComboBoxCellFixture(Silvernium, Path, RowIndex, name);
        //}

        //public TextBoxCellFixture TextBoxCell(string name)
        //{
        //    return new TextBoxCellFixture(Silvernium, Path, RowIndex, name);
        //}

        //public CheckBoxCellFixture CheckBoxCell(string name)
        //{
        //    return new CheckBoxCellFixture(Silvernium, Path, RowIndex, name);
        //}

        public DataRowFixture Select()
        {
            Silvernium.Call("SelectRowByIndex", Path, Index.ToString());
            return this;
        }

        public DataRowFixture RequireIndex(int index)
        {
            if (index != Index)
            {
                throw new SilverniumFixtureException("Unexpected row index. (expected: " + index + " actual: " + Index + ")");
            }
            return this;
        }

    }
}
