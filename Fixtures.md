# Introduction #

Silvernium Fixtures is an additional project built on top of core Silvernium that aims to provide fixtures (test supports) for easy interaction and assertion on Silverlight UI components. To see it in action, follow the steps below:
  * Download the latest version of the Silvernium solution from SVN
  * Start the Reference Application (ReferenceApplication project) from Visual Studio
  * Start the Selenium Server
  * Run the test in the FixturesTests project

# A very simple example #

The following code shows an example of how to interact with a TextBox contained in the reference application (source code included in the solution). Notice that this application has some support classes included (as described below) that allows the interaction from the fixtures.

```
using DBServer.Selenium.Silvernium.Fixtures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class ReferenceApplicationSampleTest
    {
        private const string Host = "localhost";
        private const int Port = 4444;
        private const string BrowserString = "*firefox";
        private const string Url = "http://silvernium.dbserver.com.br/ReferenceApplication.aspx?testMode=true";

        [TestMethod]
        public void DemonstrateTextBoxInteraction()
        {
            var referenceApp = new SilverlightApplicationFixture(Host, Port, BrowserString, Url);
            referenceApp.TextBox("textBox")
                .RequireEnabled()
                .RequireText("This is a TextBox")
                .SetText("This is still a TextBox, but we changed its value")
                .RequireText("This is still a TextBox, but we changed its value");
        }
    }
}
```

# What does it provides #

At the present moment, you will find support for the following UI controls:

  * CheckBox
  * ComboBox
  * RadioButton
  * TextBlock
  * TextBox
  * Button
  * DataGrid
  * Paged DataGrid
  * Editable DataGrid

# What's next? #

If you need a fixture for another UI control, submit an issue or join our Google Group and let us know!

# How to use it with your Silverlight project #

In order to make your project accessible to the components fixtures, you need to include both SilverlightFixture.xaml and WindowTracker.cs on it. These resources can be found on the ReferenceApplication project. For more information, please take a look at App.xaml.cs and ReferenceApplication.aspx, specially at the following lines:

App.xaml.cs
```
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.InitParams.ContainsKey("testMode") && Boolean.Parse(e.InitParams["testMode"]))
            {
                this.RootVisual = new SilverlightFixture();
            }
            else
            {
                this.RootVisual = new MainPage();
            }
        }
```

ReferenceApplication.aspx
```
        <object id="silverlight" data="data:application/x-silverlight-2," type="application/x-silverlight-2" width="100%" height="100%">
          <param name="InitParams" value="testMode=<%=Boolean.TrueString.Equals(Request.Params["testMode"], StringComparison.CurrentCultureIgnoreCase)%>" />
		  <param name="source" value="ClientBin/ReferenceApplication.xap"/>
		  <param name="onError" value="onSilverlightError" />
		  <param name="background" value="white" />
		  <param name="minRuntimeVersion" value="3.0.40818.0" />
		  <param name="autoUpgrade" value="true" />
		  <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40818.0" style="text-decoration:none">
 			  <img src="http://go.microsoft.com/fwlink/?LinkId=108181" alt="Get Microsoft Silverlight" style="border-style:none"/>
		  </a>
	    </object>
```