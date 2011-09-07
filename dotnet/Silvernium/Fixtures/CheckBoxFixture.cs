using System;

namespace DBServer.Selenium.Silvernium.Fixtures
{
    public class CheckBoxFixture : ComponentFixture
    {
        public CheckBoxFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string path) 
            : base(silvernium, path) { }

        public CheckBoxFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string gridPath, int rowIndex, string path)
            : base(silvernium, gridPath, rowIndex, path) { }

        public CheckBoxFixture Uncheck()
        {
            Call("SetValue", Boolean.FalseString);
            return this;
        }

        public CheckBoxFixture Check()
        {
            Call("SetValue", Boolean.TrueString);
            return this;
        }

        public CheckBoxFixture RequireChecked()
        {
            var value = Call("GetValue");
            if (!Boolean.Parse(value))
            {
                throw new SilverniumFixtureException("Checkbox was not checked");
            }
            return this;
        }

        public CheckBoxFixture RequireUnchecked()
        {
            var value = Call("GetValue");
            if (Boolean.Parse(value))
            {
                throw new SilverniumFixtureException("Checkbox was checked");
            }
            return this;
        }
    }
}