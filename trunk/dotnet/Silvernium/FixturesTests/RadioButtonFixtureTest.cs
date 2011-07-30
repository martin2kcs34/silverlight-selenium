using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class RadioButtonFixtureTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestInitialize]
        public void ResetReferenceRadioButton()
        {
            App.RadioButton("radioButtonILike").Select();
        }

        [TestMethod]
        public void SelectSelectsTheRadioButtonAndUnselectOtherRadiosInTheSameGroup()
        {
            var radioButtonILike = App.RadioButton("radioButtonILike");
            var radioButtonIHate = App.RadioButton("radioButtonIHate");

            radioButtonIHate
                .Select()
                .RequireSelected();
            radioButtonILike
                .RequireUnselected()
                .Select()
                .RequireSelected();
            radioButtonIHate
                .RequireUnselected();
        }

        [TestMethod]
        public void RequireSelectedPassesIfTheRadioButtonIsSelected()
        {
            App.RadioButton("radioButtonILike").RequireSelected();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireSelectedThrowsExceptionIfTheRadioButtonIsUnselected()
        {
            App.RadioButton("radioButtonIHate").RequireSelected();
        }

        [TestMethod]
        public void RequireUnselectedPassesIfTheRadioButtonIsNotSelected()
        {
            App.RadioButton("radioButtonIHate").RequireUnselected();
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireUnselectedThrowsExceptionIfTheRadioButtonIsSelected()
        {
            App.RadioButton("radioButtonILike").RequireUnselected();
        }

    }
}
