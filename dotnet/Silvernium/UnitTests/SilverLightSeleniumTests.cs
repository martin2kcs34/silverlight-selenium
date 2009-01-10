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
            mockProcessor = new DynamicMock(typeof (ISelenium));
            selenium = (ISelenium) mockProcessor.MockInstance;
            mockProcessor.ExpectAndReturn("GetEval", "Firefox/2.0.0.18", "navigator.userAgent");
        }

        [TearDown]
        public void TearDown()
        {
            mockProcessor.Verify();
        }


        [Test]
        public void ShouldCreateXAMLContent()
        {
            mockProcessor.Expect("GetEval", "document['Test'].content.createFromXaml('xamlContent','namescope');");
            silvernium = new Silvernium(selenium, "Test");
            silvernium.CreateFromXAML("xamlContent", "namescope");
        }

        [Test]
        public void ShouldFindName()
        {
            mockProcessor.ExpectAndReturn("GetEval", "Return Name", "document['Test'].content.findName('objectName');");
            silvernium = new Silvernium(selenium, "Test");
            Assert.AreEqual("Return Name", silvernium.FindName("objectName"));
        }

        [Test]
        public void ShouldInitParams()
        {
            mockProcessor.ExpectAndReturn("GetEval", "List of init params", "document['Test'].initParams;");
            silvernium = new Silvernium(selenium, "Test");
            Assert.AreEqual("List of init params", silvernium.InitParams());
        }

        [Test]
        public void ShouldReturnAccessibilityValue()
        {
            mockProcessor.ExpectAndReturn("GetEval", "Some Accessibility Return Value",
                                          "document['Test'].content.accessibility;");
            silvernium = new Silvernium(selenium, "Test");
            Assert.AreEqual("Some Accessibility Return Value", silvernium.Accessibility());
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

        [Test]
        public void ShouldReturnFullScreenAttributes()
        {
            mockProcessor.ExpectAndReturn("GetEval", "True", "document['Test'].content.fullScreen;");
            silvernium = new Silvernium(selenium, "Test");
            Assert.IsTrue(silvernium.FullScreen());
        }

        [Test]
        public void ShouldReturnTrueIfLoaded()
        {
            mockProcessor.ExpectAndReturn("GetEval", "True", "document['Test'].isLoaded;");
            silvernium = new Silvernium(selenium, "Test");
            Assert.IsTrue(silvernium.IsLoaded());
        }

        [Test]
        public void ShouldReturnTrueIfVersionIsSupported()
        {
            mockProcessor.ExpectAndReturn("GetEval", "true", "document['Test'].isVersionSupported('10');");
            silvernium = new Silvernium(selenium, "Test");
            Assert.IsTrue(silvernium.IsVersionSupported("10"));
        }

        [Test]
        public void ShouldReturnRoot()
        {
            mockProcessor.ExpectAndReturn("GetEval", "Root Content", "document['Test'].root;");
            silvernium = new Silvernium(selenium, "Test");
            Assert.AreEqual("Root Content", silvernium.Root());
        }

        [Test]
        public void ShouldReturnBackgroundInformation()
        {
            mockProcessor.ExpectAndReturn("GetEval", "Bg Info", "document['Test'].settings.background;");
            silvernium = new Silvernium(selenium, "Test");
            Assert.AreEqual("Bg Info", silvernium.Background());
        }

        [Test]
        public void ShouldCallSettingsProperties()
        {
            mockProcessor.ExpectAndReturn("GetEval", "True", "document['Test'].settings.enabledFramerateCounter;");
            mockProcessor.ExpectAndReturn("GetEval", "True", "document['Test'].settings.enableRedrawRegions;");
            mockProcessor.ExpectAndReturn("GetEval", "True", "document['Test'].settings.enableHtmlAccess;");
            mockProcessor.ExpectAndReturn("GetEval", "42", "document['Test'].settings.maxFrameRate;");
            mockProcessor.ExpectAndReturn("GetEval", "True", "document['Test'].settings.windowless;");
            silvernium = new Silvernium(selenium, "Test");
            Assert.IsTrue(silvernium.EnabledFrameRateCounter());
            Assert.IsTrue(silvernium.EnableRedrawRegions());
            Assert.IsTrue(silvernium.EnableHtmlAccess());
            Assert.AreEqual(42, silvernium.MaxFrameRate());
            Assert.IsTrue(silvernium.WindowLess());
        }

        [Test]
        public void ShouldReturnSource()
        {
            mockProcessor.ExpectAndReturn("GetEval", "Source Code", "document['Test'].source;");
            silvernium = new Silvernium(selenium, "Test");
            Assert.AreEqual("Source Code", silvernium.Source());
        }
    }
}