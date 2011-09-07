using System;
using System.Linq; 

namespace DBServer.Selenium.Silvernium.Fixtures
{
    public class ComboBoxFixture : ComponentFixture
    {
        public ComboBoxFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string path) 
            : base(silvernium, path) { }

        public ComboBoxFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string gridPath, int rowIndex, string path)
            : base(silvernium, gridPath, rowIndex, path) { }

        public ComboBoxFixture SetValue(string value)
        {
            Call("SetValue", value);
            return this;
        }

        public ComboBoxFixture RequireValue(string value)
        {
            var actualValue = Call("GetValue").Split('|');
            if (!actualValue.Contains(value))
            {
                throw new SilverniumFixtureException("Expected value wasn't selected '" 
                    + value + "' (actual: '" + actualValue + "')");
            }
            return this;
        }

        public ComboBoxFixture RequireEnabled()
        {
            var enabled = Call("IsEnabled");
            if (!Boolean.Parse(enabled))
            {
                throw new SilverniumFixtureException("Combo box should be enabled");
            }
            return this;
        }

        public ComboBoxFixture RequireDisabled()
        {
            var enabled = Call("IsEnabled");
            if (Boolean.Parse(enabled))
            {
                throw new SilverniumFixtureException("Combo box should be disabled");
            }
            return this;
        }

    }
}