## The silverlight-selenium project ##

The silverlight-selenium libraries extend the Selenium RC clients, adding Silverlight communication capabilities to the Selenium RC tests.

The silverlight-selenium RC client extension is currently available for the following Selenium RC client drivers: Java and .Net. The Selenium RC client extensions --Silvernium components—are available [in the Downloads session](http://code.google.com/p/silverlight-selenium/downloads/list).

## The Silvernium Fixtures _(new!)_ ##

Silvernium Fixtures provides a set of fixtures for interacting with common UI components. The cool thing about the fixtures is that you can write your tests with almost no change in your application (since the scriptable members are exposed by the Silvernium Fixtures support classes) in a fluent way like this:

```
App.DataGrid('myPanel.myDataGrid', 'myPanel.myDataPager')
   .GoToPageContaining('My Record')
   .RowContaining('My Record')
      .ComboBox('innerComboBox')
         .RequireEnabled()
         .RequireValue('Initial Value')
         .SetValue('Another Value');

App.Button('myButton').Click();
```

The Silvernium Fixtures dll and the support classes to be included in the Silverlight application are available in the [Downloads](http://code.google.com/p/silverlight-selenium/downloads/list) session. For more information, visit the [fixtures wiki page](Fixtures.md).

## The Silvernium component ##

The Silvernium is the component adding Silverlight communication capabilities to the Selenium framework.

Basically, the Silvernium is a Selenium RC Client driver extension for helping exercise the tests against the Silverlight component.

The following is the SilverNibblesTest -–a Seleniun based Unit test case testing SilverNibbles, a Web application containing SilverlightControl, a Silverlight scriptable object. Try out the SilverNibbles application [here](http://www.markheath.me.uk/silvernibbles/). Read Mark Heath’s blog on how to make SilverNibbles scriptable [here](http://mark-dot-net.blogspot.com/2007/06/howto-make-your-silverlight-11.html).

```

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



```


## Selenium RC / Silverlight Integration ##

Selenium RC uses JavaScript to communicate with the browser. And Silverlight Scriptable attribute provides a mechanism to mark the Silverlight application’s classes and functions available for JavaScript calls. Therefore Silverlight-Selenium uses JavaScript as the conduit between Selenium RC and the Silverlight application.

With Silverlight Scriptable attribute you can expose specific Silverlight application functions.For example, the following code adds external invocation capabilities to the SilverNibbles NewGame()method.
```
[Scriptable]
public void NewGame(int players)
{
...
```

On the testing side, The Silvernium is the component adding Silverlight communication capabilities to the Selenium framework. Basically, the Silvernium is a Selenium RC Client driver extension for helping exercise the tests against the Silverlight object. The Silvernium constructor takes a Selenium instance and the Silverlight object ID and the scriptable key as parameters. An instance of Silvernium is used to invoke the functions on the Silverlight application.

You can invoke functions which were externalized by the Scriptable attribute, as well as the default functions and properties of any Silverlight object (e.g, ,,background,  isLoaded,ActualWidth(), etc). The following are code snapshots from the SilverNibblesTest —the sample Seleniun based Unit test.

```
            Assert.AreEqual(460, silvernium.ActualHeight());

            // content.SilverNibbles.StartingSpeed;,  returns 5
            Assert.AreEqual("5", silvernium.GetPropertyValue("StartingSpeed"));

            // content.SilverNibbles.NewGame('1');,  returns null
            Assert.AreEqual("null", silvernium.Call("NewGame", "1"));


            // testing set and get for a user defined property
            Assert.AreEqual("5", silvernium.GetPropertyValue("StartingSpeed"));
            // setting the property
            silvernium.SetPropertyValue("StartingSpeed", "8");


```