using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class CheckBoxFixtureTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestInitialize]
        public void ResetReferenceCheckBox()
        {
            App.CheckBox("checkBox").Uncheck();
        }

        [TestMethod]
        public void CheckCheckes()
        {
            App.CheckBox("checkBox")
                .Check()
                .RequireChecked();
        }

        [TestMethod]
        public void UncheckUncheckes()
        {
            App.CheckBox("checkBox")
                .Uncheck()
                .RequireUnchecked();
        }

        [TestMethod]
        public void RequireCheckedPassesIfCheckBoxIsChecked()
        {
            App.CheckBox("checkBox")
                .Check()
                .RequireChecked();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireCheckedThrowsExceptionIfCheckBoxIsUnchecked()
        {
            App.CheckBox("checkBox")
                .RequireChecked();

        }

        [TestMethod]
        public void RequireUncheckedPassesIfCheckBoxIsUnchecked()
        {
            App.CheckBox("checkBox")
                .RequireUnchecked();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireUncheckedThrowsExceptionIfCheckBoxIsChecked()
        {
            App.CheckBox("checkBox")
                .Check()
                .RequireUnchecked();
        }

    }
}
