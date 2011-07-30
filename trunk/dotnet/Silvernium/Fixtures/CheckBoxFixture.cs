using System;
using Selenium;

namespace DBServer.Selenium.Silvernium.Fixtures
{
    public class CheckBoxFixture : ComponentFixture
    {
        public CheckBoxFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string path) 
            : base(silvernium, path) { }

        public CheckBoxFixture Uncheck()
        {
            Call("SetValue", Path, Boolean.FalseString);
            return this;
        }

        public CheckBoxFixture Check()
        {
            Call("SetValue", Path, Boolean.TrueString);
            return this;
        }

        public CheckBoxFixture RequireChecked()
        {
            var value = Call("GetValue", Path);
            if (!Boolean.Parse(value))
            {
                throw new SilverniumFixtureException("Checkbox was not checked");
            }
            return this;
        }

        public CheckBoxFixture RequireUnchecked()
        {
            var value = Call("GetValue", Path);
            if (Boolean.Parse(value))
            {
                throw new SilverniumFixtureException("Checkbox was checked");
            }
            return this;
        }
    }
}