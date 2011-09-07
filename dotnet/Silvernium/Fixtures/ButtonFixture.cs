using System;

namespace DBServer.Selenium.Silvernium.Fixtures
{
    public class ButtonFixture : ComponentFixture
    {
        public ButtonFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string path) 
            : base(silvernium, path) { }

        public ButtonFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string gridPath, int rowIndex, string path)
            : base(silvernium, gridPath, rowIndex, path) { }

        public ButtonFixture Click()
        {
            Call("Click");
            return this;
        }

        public ButtonFixture RequireContent(string content)
        {
            var actualContent = Call("GetProperty", "Content");
            if (content != actualContent)
            {
                throw new SilverniumFixtureException("Button does not contains expected content '" + content + "' "
                    + "(actual: " + actualContent + ")");
            }
            return this;
        }

        public ButtonFixture RequireEnabled()
        {
            var enabled = Call("IsEnabled");
            if (!Boolean.Parse(enabled))
            {
                throw new SilverniumFixtureException("Button should be enabled");
            }
            return this;
        }

        public ButtonFixture RequireDisabled()
        {
            var enabled = Call("IsEnabled");
            if (Boolean.Parse(enabled))
            {
                throw new SilverniumFixtureException("Button should be disabled");
            }
            return this;
        }

    }
}