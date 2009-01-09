using NMock;
using NUnit.Framework;
using Selenium;
using ThoughtWorks.Selenium.Silvernium;

namespace UnitTests
{
    [TestFixture]
    public class SilverniumTests
    {
        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
            mockProcessor = new DynamicMock(typeof (ISelenium));
            selenium = (ISelenium) mockProcessor.MockInstance;
        }

        [TearDown]
        public void TearDown()
        {
            mockProcessor.Verify();
        }

        #endregion

        private DynamicMock mockProcessor;
        private ISelenium selenium;
        private Silvernium silvernium;

        [Test]
        public void ShouldReturnDocumentJSPrefixForFF2()
        {
            mockProcessor.ExpectAndReturn("GetEval", "Firefox/2.0.0.18", "navigator.userAgent");
            silvernium = new Silvernium(selenium, "test");
            Assert.AreEqual("document['test'].", silvernium.createJSPrefixDocument("test"));
        }

        [Test]
        public void ShouldReturnJSFunctionForDirectMethodForFF2()
        {
            mockProcessor.ExpectAndReturn("GetEval", "Firefox/2.0.0.18", "navigator.userAgent");
            silvernium = new Silvernium(selenium, "Test");
            Assert.AreEqual("document['Test'].Func1();", silvernium.jsForDirectMethod("Func1"));
            Assert.AreEqual("document['Test'].Func2('42');", silvernium.jsForDirectMethod("Func2", "42"));
            Assert.AreEqual("document['Test'].Func3('42','24');",
                            silvernium.jsForDirectMethod("Func3", new[] {"42", "24"}));
        }

        [Test]
        public void ShouldReturnJSFunctionForDirectMethodForMSIE()
        {
            mockProcessor.ExpectAndReturn("GetEval", "MSIE", "navigator.userAgent");
            silvernium = new Silvernium(selenium, "Test");
            Assert.AreEqual("window.document['Test'].Func1();", silvernium.jsForDirectMethod("Func1"));
            Assert.AreEqual("window.document['Test'].Func2('42');", silvernium.jsForDirectMethod("Func2", "42"));
            Assert.AreEqual("window.document['Test'].Func3('42','24');",
                            silvernium.jsForDirectMethod("Func3", new[] {"42", "24"}));
        }

        [Test]
        public void ShouldReturnJSFunctionForScriptMethodForFF2()
        {
            mockProcessor.ExpectAndReturn("GetEval", "Firefox/2.0.0.18", "navigator.userAgent");
            silvernium = new Silvernium(selenium, "Test", "Key");
            Assert.AreEqual("document['Test'].content.Key.Func1();", silvernium.jsForContentScriptMethod("Func1"));
            Assert.AreEqual("document['Test'].content.Key.Func2('42');",
                            silvernium.jsForContentScriptMethod("Func2", "42"));
            Assert.AreEqual("document['Test'].content.Key.Func3('42','24');",
                            silvernium.jsForContentScriptMethod("Func3", new[] {"42", "24"}));
        }

        [Test]
        public void ShouldReturnJSFunctionForScriptMethodForFF3()
        {
            mockProcessor.ExpectAndReturn("GetEval", "Firefox/3.0.0.1", "navigator.userAgent");
            silvernium = new Silvernium(selenium, "Test", "Key");
            Assert.AreEqual("window.document['Test'].content.Key.Func1();", silvernium.jsForContentScriptMethod("Func1"));
            Assert.AreEqual("window.document['Test'].content.Key.Func2('42');",
                            silvernium.jsForContentScriptMethod("Func2", "42"));
            Assert.AreEqual("window.document['Test'].content.Key.Func3('42','24');",
                            silvernium.jsForContentScriptMethod("Func3", new[] {"42", "24"}));
        }
        
        [Test]
        public void ShouldReturnJSFunctionForContentMethodForFF2()
        {
            mockProcessor.ExpectAndReturn("GetEval", "Firefox/2.0.0.18", "navigator.userAgent");
            silvernium = new Silvernium(selenium, "Test", "Key");
            Assert.AreEqual("document['Test'].content.Func1();", silvernium.jsForContentMethod("Func1"));
            Assert.AreEqual("document['Test'].content.Func2('42');",
                            silvernium.jsForContentMethod("Func2", "42"));
            Assert.AreEqual("document['Test'].content.Func3('42','24');",
                            silvernium.jsForContentMethod("Func3", new[] { "42", "24" }));
        }

        [Test]
        public void ShouldReturnJSFunctionForContentMethodForFF3()
        {
            mockProcessor.ExpectAndReturn("GetEval", "Firefox/3.0.0.1", "navigator.userAgent");
            silvernium = new Silvernium(selenium, "Test", "Key");
            Assert.AreEqual("window.document['Test'].content.Func1();", silvernium.jsForContentMethod("Func1"));
            Assert.AreEqual("window.document['Test'].content.Func2('42');",
                            silvernium.jsForContentMethod("Func2", "42"));
            Assert.AreEqual("window.document['Test'].content.Func3('42','24');",
                            silvernium.jsForContentMethod("Func3", new[] { "42", "24" }));
        }

        [Test]
        public void ShouldReturnWindowDocumentJSPrefixForFF3()
        {
            mockProcessor.ExpectAndReturn("GetEval", "Firefox/3.0.0.1", "navigator.userAgent");
            silvernium = new Silvernium(selenium, "test");
            Assert.AreEqual("window.document['test'].", silvernium.createJSPrefixWindowDocument("test"));
        }
    }
}