using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    [TestClass]
    public class TextBlockFixtureTest
    {
        private static readonly ReferenceApplicationFixture App = ReferenceApplicationFixture.Instance();

        [TestMethod]
        public void RequireTextPassesForCorrectValues()
        {
            App.TextBlock("textBlock").RequireText("This is a TextBlock");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireTextThrowsExceptionForIncorrectValues()
        {
            App.TextBlock("textBlock").RequireText("This is not a TextBlock");
        }

        [TestMethod]
        public void RequireContainsPassesForExactValues()
        {
            App.TextBlock("textBlock").RequireContains("This is a TextBlock");
        }

        [TestMethod]
        public void RequireContainsPassesForPartialValues()
        {
            App.TextBlock("textBlock").RequireContains("is a Text");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireContainsThrowsExceptionForIncorrectValues()
        {
            App.TextBlock("textBlock").RequireContains("is not a Text");
        }

        [TestMethod]
        public void RequireNotContainsPassesForAbsentValues()
        {
            App.TextBlock("textBlock").RequireNotContains("is not a Text");
        }

        [TestMethod]
        [ExpectedException(typeof(SilverniumFixtureException))]
        public void RequireNotContainsThrowsExceptionForPresentValues()
        {
            App.TextBlock("textBlock").RequireNotContains("is a Text");
        }

    }
}
