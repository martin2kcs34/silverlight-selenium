using System;

namespace DBServer.Selenium.Silvernium.Fixtures
{
    public class TextBoxFixture : ComponentFixture
    {
        public TextBoxFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string path) 
            : base(silvernium, path) { }

        public TextBoxFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string gridPath, int rowIndex, string path)
            : base(silvernium, gridPath, rowIndex, path) { }

        public TextBoxFixture SetText(string text)
        {
            Call("SetValue", text);
            return this;
        }

        public TextBoxFixture RequireText(string text)
        {
            var actualText = Call("GetValue");
            if (text != actualText)
            {
                throw new SilverniumFixtureException("Text box doesn't contains expected text '" 
                    + text + "' (actual: '" + actualText + "')");
            }
            return this;
        }

        public TextBoxFixture RequireContains(string partialText)
        {
            var fullText = Call("GetValue");
            if (fullText == null || !fullText.Contains(partialText))
            {
                throw new SilverniumFixtureException("Text box does not contains expected partial text " + partialText
                    + " (actual: " + fullText + ")");
            }
            return this;
        }

        public TextBoxFixture RequireNotContains(string partialText)
        {
            var fullText = Call("GetValue");
            if (fullText != null && fullText.Contains(partialText))
            {
                throw new SilverniumFixtureException("Text box contains unexpected partial text " + partialText
                    + " (actual: " + fullText + ")");
            }
            return this;
        }

        public TextBoxFixture RequireEnabled()
        {
            var enabled = Call("IsEnabled");
            if (!Boolean.Parse(enabled))
            {
                throw new SilverniumFixtureException("Text box should be enabled");
            }
            return this;
        }

        public TextBoxFixture RequireDisabled()
        {
            var enabled = Call("IsEnabled");
            if (Boolean.Parse(enabled))
            {
                throw new SilverniumFixtureException("Text box should be disabled");
            }
            return this;
        }

    }
}