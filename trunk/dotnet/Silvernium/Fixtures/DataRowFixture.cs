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

        public DataRowFixture Select()
        {
            Call("SelectRowByIndex", Index.ToString());
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

        public ButtonFixture Button(string path)
        {
            return new ButtonFixture(Silvernium, Path, Index, path);
        }

        public CheckBoxFixture CheckBox(string path)
        {
            return new CheckBoxFixture(Silvernium, Path, Index, path);
        }

        public ComboBoxFixture ComboBox(string path)
        {
            return new ComboBoxFixture(Silvernium, Path, Index, path);
        }

        public TextBlockFixture TextBlock(string path)
        {
            return new TextBlockFixture(Silvernium, Path, Index, path);
        }

        public TextBoxFixture TextBox(string path)
        {
            return new TextBoxFixture(Silvernium, Path, Index, path);
        }
    }
}
