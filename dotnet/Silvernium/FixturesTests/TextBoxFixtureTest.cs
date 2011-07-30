using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class TextBoxFixtureTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void RequireTextPassesForCorrectValues()
        {
            App.TextBox("textBox").RequireText("This is a TextBox");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireTextThrowsExceptionForIncorrectValues()
        {
            App.TextBox("textBox").RequireText("This is not a TextBox");
        }

        [TestMethod]
        public void RequireContainsPassesForExactValues()
        {
            App.TextBox("textBox").RequireContains("This is a TextBox");
        }
        
        [TestMethod]
        public void RequireContainsPassesForPartialValues()
        {
            App.TextBox("textBox").RequireContains("is a Text");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireContainsThrowsExceptionForIncorrectValues()
        {
            App.TextBox("textBox").RequireContains("is not a Text");
        }

        [TestMethod]
        public void RequireNotContainsPassesForAbsentValues()
        {
            App.TextBox("textBox").RequireNotContains("is not a Text");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireNotContainsThrowsExceptionForPresentValues()
        {
            App.TextBox("textBox").RequireNotContains("is a Text");
        }

        [TestMethod]
        public void SetTextChangesTextBoxValue()
        {
            App.TextBox("textBox")
                .RequireText("This is a TextBox")

                .SetText("This is still a TextBox")
                .RequireText("This is still a TextBox")

                .SetText("This is a TextBox")
                .RequireText("This is a TextBox");
        }

        [TestMethod]
        public void RequireEnabledPassesForExpectedState()
        {
            App.TextBox("textBox").RequireEnabled();
        }
        
        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireEnabledThrowsExceptionForUnexpectedState()
        {
            App.TextBox("disabledTextBox").RequireEnabled();
        }

        [TestMethod]
        public void RequireDisabledPassesForExpectedState()
        {
            App.TextBox("disabledTextBox").RequireDisabled();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireDisabledThrowsExceptionForUnexpectedState()
        {
            App.TextBox("textBox").RequireDisabled();
        }

    }

}
