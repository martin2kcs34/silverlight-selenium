using NMock;
using NUnit.Framework;
using Selenium;
using ThoughtWorks.Selenium.Silvernium;

namespace UnitTests
{
    [TestFixture]
    public class SilverLightSeleniumTests
    {
        private DynamicMock mockProcessor;
        private ISelenium selenium;
        private Silvernium silvernium;

        [SetUp]
        public void SetUp()
        {
            mockProcessor = new DynamicMock(typeof(ISelenium));
            selenium = (ISelenium)mockProcessor.MockInstance;
            mockProcessor.ExpectAndReturn("GetEval", "Firefox/2.0.0.18", "navigator.userAgent");
        }

        [TearDown]
        public void TearDown()
        {
            mockProcessor.Verify();
        }

        [Test]
        public void ShouldReturnTrueIfVersionIsSupported()
        {
            mockProcessor.ExpectAndReturn("GetEval", "true", "document['Test'].isVersionSupported('10');");
            silvernium = new Silvernium(selenium, "Test");
            Assert.IsTrue(silvernium.IsVersionSupported("10"));
        }

        [Test]
        public void ShouldReturnActualHeightOfMovie()
        {
            mockProcessor.ExpectAndReturn("GetEval", "42", "document['Test'].content.actualHeight;");
            silvernium = new Silvernium(selenium, "Test");
            Assert.AreEqual(42, silvernium.ActualHeight());
        }

        [Test]
        public void ShouldReturnActualWidthOfMovie()
        {
            mockProcessor.ExpectAndReturn("GetEval", "24", "document['Test'].content.actualWidth;");
            silvernium = new Silvernium(selenium, "Test");
            Assert.AreEqual(24, silvernium.ActualWidth());
        }

    }
}