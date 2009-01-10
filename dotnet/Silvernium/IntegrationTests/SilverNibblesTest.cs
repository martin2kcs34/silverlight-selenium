using NUnit.Framework;
using Selenium;
using ThoughtWorks.Selenium.Silvernium;

namespace IntegrationTests
{
    [TestFixture]
    public class SilverNibblesTest
    {
        private const string URL = "http://www.markheath.me.uk/silvernibbles";
        private const string OBJECTID = "SilverlightControl";
        private const string SCRIPTKEY = "SilverNibbles";
        private ISelenium selenium;
        private Silvernium silvernium;

        [SetUp]
        public void SetUp()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*iexplore", URL);
            selenium.Start();
            selenium.Open(URL);
            silvernium = new Silvernium(selenium, OBJECTID, SCRIPTKEY);
        }

        [TearDown]
        public void TearDown()
        {
            selenium.Stop();
        }
        [Test]
        public void ShouldCommunicateWithSilverNibbleApplication()
        {
            Assert.AreEqual("SilverNibbles", selenium.GetTitle());
            // verifies default properties in the silverlight object
            Assert.AreEqual(640, silvernium.ActualWidth());
            Assert.AreEqual(460, silvernium.ActualHeight());

            // verifies user defined properties and methods
            // content.SilverNibbles.StartingSpeed;,  returns 5
            Assert.AreEqual("5", silvernium.GetPropertyValue("StartingSpeed"));
            // content.SilverNibbles.NewGame('1');,  returns null
            Assert.AreEqual("null", silvernium.Call("NewGame", "1"));


            // testing set and get for a user defined property
            Assert.AreEqual("5", silvernium.GetPropertyValue("StartingSpeed"));
            // setting the property
            silvernium.SetPropertyValue("StartingSpeed", "8");
            // getting it again
            Assert.AreEqual("8", silvernium.GetPropertyValue("StartingSpeed"));
        }
    }
}