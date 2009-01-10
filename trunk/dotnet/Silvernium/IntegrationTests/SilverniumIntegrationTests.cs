using NUnit.Framework;
using Selenium;
using ThoughtWorks.Selenium.Silvernium;

namespace IntegrationTests
{
    [TestFixture]
    public class SilverniumIntegrationTests
    {
        private ISelenium selenium;
        private Silvernium silvernium;

        [SetUp]
        public void SetUp()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*iexplore", "http://localhost");
            selenium.Start();
            selenium.Open("http://localhost");
            silvernium = new Silvernium(selenium, "Test");
        }

        [TearDown]
        public void TearDown()
        {
            selenium.Stop();
        }

        [Test]
        public void ShouldSpawnBrowserOnSeleniumAndFetchSilverLightJSStringPreixForMSIE()
        {
            Assert.AreEqual("window.document['Test'].", silvernium.SilverLightJSStringPrefix);
        }
    }
}