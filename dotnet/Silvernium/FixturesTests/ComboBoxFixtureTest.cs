using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class ComboBoxFixtureTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void RequireValuePassesForCorrectValues()
        {
            App.ComboBox("simpleComboBox").RequireValue("Option 1");
            App.ComboBox("displayMemberPathComboBox").RequireValue("Arthur");
            App.ComboBox("disabledComboBox").RequireValue("Disabled ComboBox");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireValueThrowsExceptionForIncorrectValueInASimpleComboBox()
        {
            App.TextBox("simpleComboBox").RequireText("This is not my value");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireValueThrowsExceptionForIncorrectValueInADisplayMemberPathComboBox()
        {
            App.TextBox("displayMemberPathComboBox").RequireText("This is not my value");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireValueThrowsExceptionForIncorrectValueInADisabledComboBox()
        {
            App.TextBox("disabledComboBox").RequireText("This is not my value");
        }

        [TestMethod]
        public void SetValueChangesComboBoxValue()
        {
            App.ComboBox("simpleComboBox")
                .RequireValue("Option 1")
                .SetValue("Option 2")
                .RequireValue("Option 2")
                .SetValue("Option 3")
                .RequireValue("Option 3")
                .SetValue("Option 1")
                .RequireValue("Option 1");

            App.ComboBox("displayMemberPathComboBox")
                .RequireValue("Arthur")
                .SetValue("John")
                .RequireValue("John")
                .SetValue("Richard")
                .RequireValue("Richard")
                .SetValue("Arthur")
                .RequireValue("Arthur");
        }

        [TestMethod]
        public void RequireEnabledPassesForExpectedState()
        {
            App.ComboBox("simpleComboBox").RequireEnabled();
        }
        
        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireEnabledThrowsExceptionForUnexpectedState()
        {
            App.ComboBox("disabledComboBox").RequireEnabled();
        }

        [TestMethod]
        public void RequireDisabledPassesForExpectedState()
        {
            App.ComboBox("disabledComboBox").RequireDisabled();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireDisabledThrowsExceptionForUnexpectedState()
        {
            App.ComboBox("simpleComboBox").RequireDisabled();
        }

    }

}
