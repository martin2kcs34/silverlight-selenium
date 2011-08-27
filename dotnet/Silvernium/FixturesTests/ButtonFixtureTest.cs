using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class ButtonFixtureTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void ClickClicks()
        {
            var textBox = App.TextBox("clearTextBox");
            var button = App.Button("clearButton");

            textBox.SetText("This text should be cleared by the button above");
            button.Click();
            textBox.RequireText("");
        }

        [TestMethod]
        public void RequireContentPassesForExpectedContent()
        {
            App.Button("clearButton").RequireContent("This Button clears the TextBox below");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireContentThrowsExceptionForUnexpectedContent()
        {
            App.Button("clearButton").RequireContent("This is not the Button content");
        }

        [TestMethod]
        public void RequireEnabledPassesForExpectedState()
        {
            App.Button("clearButton").RequireEnabled();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireEnabledThrowsExceptionForUnexpectedState()
        {
            App.Button("disabledButton").RequireEnabled();
        }

        [TestMethod]
        public void RequireDisabledPassesForExpectedState()
        {
            App.Button("disabledButton").RequireDisabled();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireDisabledThrowsExceptionForUnexpectedState()
        {
            App.Button("clearButton").RequireDisabled();
        }

    }
}
