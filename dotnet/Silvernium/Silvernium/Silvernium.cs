using System;
using System.Linq;
using Selenium;

namespace ThoughtWorks.Selenium.Silvernium
{
    public class Silvernium
    {
        private readonly string scriptKey = "";
        private readonly ISelenium selenium;
        private readonly string silverLightJSStringPrefix;

        public Silvernium(ISelenium selenium, string silverlightObjectId, string scriptKey)
        {
            if (!string.IsNullOrEmpty(scriptKey))
            {
                this.scriptKey = scriptKey + ".";
            }
            this.selenium = selenium;
            silverLightJSStringPrefix = GetSilverLightJSStringPrefix(silverlightObjectId);
        }

        public Silvernium(ISelenium selenium, string silverlightObjectId)
        {
            this.selenium = selenium;
            silverLightJSStringPrefix = GetSilverLightJSStringPrefix(silverlightObjectId);
        }

        public string SilverLightJSStringPrefix
        {
            get { return silverLightJSStringPrefix; }
        }

        private string GetSilverLightJSStringPrefix(string silverlightObjectId)
        {
            string appName = selenium.GetEval("navigator.userAgent");
            if (appName.Contains(BrowserConstants.FIREFOX2))
            {
                return createJSPrefixDocument(silverlightObjectId);
            }
            if (appName.Contains(BrowserConstants.FIREFOX) || appName.Contains(BrowserConstants.IE))
            {
                return createJSPrefixWindowDocument(silverlightObjectId);
            }
            return string.Empty;
        }

        public string createJSPrefixWindowDocument(string silverlightObjectId)
        {
            return "window.document['" + silverlightObjectId + "'].";
        }

        public string createJSPrefixDocument(string silverlightObjectId)
        {
            return "document['" + silverlightObjectId + "'].";
        }

        public string jsForDirectMethod(string functionName, params string[] parameters)
        {
            string functionArgs = "";
            if (parameters.Count() > 0)
            {
                for (int i = 0; i < parameters.Count(); i++)
                {
                    functionArgs = functionArgs + "'" + parameters[i] + "',";
                }
                // remove last comma
                functionArgs = functionArgs.Substring(0, functionArgs.Length - 1);
            }
            return silverLightJSStringPrefix + functionName + "(" + functionArgs + ");";
        }

        public string jsForContentScriptMethod(string functionName, params string[] parameters)
        {
            string functionArgs = "";
            if (parameters.Count() > 0)
            {
                for (int i = 0; i < parameters.Count(); i++)
                {
                    functionArgs = functionArgs + "'" + parameters[i] + "',";
                }
                // remove last comma
                functionArgs = functionArgs.Substring(0, functionArgs.Length - 1);
            }
            return silverLightJSStringPrefix + "content." + scriptKey + functionName + "(" + functionArgs + ");";
        }

        public string jsForContentMethod(string functionName, params string[] parameters)
        {
            string functionArgs = "";
            if (parameters.Count() > 0)
            {
                for (int i=0; i<parameters.Count(); i++)
                {
                    functionArgs = functionArgs + "'" + parameters[i] + "',";
                }
                //remove last comma
                functionArgs = functionArgs.Substring(0, functionArgs.Length - 1);
            }
            return silverLightJSStringPrefix + "content." + functionName + "(" + functionArgs + ");";
        }

        private string jsForContentProperty(string propertyName)
        {
            return silverLightJSStringPrefix + "content." + propertyName + ";";
        }

        private string jsForDirectProperty(string propertyName)
        {
            return silverLightJSStringPrefix + propertyName + ";";
        }

        private string jsForSettingsProperty(string propertyName)
        {
            return silverLightJSStringPrefix + "settings." + propertyName + ";";
        }

        private string jsForContentScriptGetProperty(string propertyName)
        {
            return silverLightJSStringPrefix + "content." + scriptKey + propertyName + ";";
        }

        private string jsForContentScriptSetProperty(string propertyName, string parameters)
        {
            return silverLightJSStringPrefix + "content." + scriptKey + propertyName + "='" + parameters + "';";
        }

        public void Start()
        {
            selenium.Start();
        }

        public void Stop()
        {
            selenium.Stop();
        }

        public void Open(string url)
        {
            selenium.Open(url);
        }

        public string DirectMethod(string functionName, params string[] parameters)
        {
            return selenium.GetEval(jsForDirectMethod(functionName, parameters));
        }

        public string ContentMethod(string functionName, params string[] parameters)
        {
            return selenium.GetEval(jsForContentMethod(functionName, parameters));
        }

        private string ContentProperty(string propertyName)
        {
            return selenium.GetEval(jsForContentProperty(propertyName));
        }

        private string DirectProperty(string propertyName)
        {
            return selenium.GetEval(jsForDirectProperty(propertyName));
        }

        private string SettingsProperty(string propertyName)
        {
            return selenium.GetEval(jsForSettingsProperty(propertyName));
        }

        public string GetPropertyValue(string propertyName)
        {
            return selenium.GetEval(jsForContentScriptGetProperty(propertyName));
        }

        public string SetPropertyValue(string propertyName, string parameters)
        {
            return selenium.GetEval(jsForContentScriptSetProperty(propertyName, parameters));
        }

        public string Call(string functionName, params string[] parameters)
        {
            return selenium.GetEval(jsForContentScriptMethod(functionName, parameters));
        }

        //Silverlight Methods
        public bool IsVersionSupported(string versionString)
        {
            return Convert.ToBoolean(DirectMethod("isVersionSupported", versionString));
        }

        public int ActualHeight()
        {
            return Convert.ToInt32(ContentProperty("actualHeight"));
        }

        public int ActualWidth()
        {
            return Convert.ToInt32(ContentProperty("actualWidth"));
        }

        public string Accessibility()
        {
            return ContentProperty("accessibility");
        }

        public void CreateFromXAML(string xamlContent, string namescope)
        {
            ContentMethod("createFromXaml", xamlContent, namescope);
        }

        public string FindName(string objectName)
        {
            return ContentMethod("findName", objectName);
        }

        public bool FullScreen()
        {
            return Convert.ToBoolean(ContentProperty("fullScreen"));
        }

        public string InitParams()
        {
            return DirectProperty("initParams");
        }

        public bool IsLoaded()
        {
            return Convert.ToBoolean(DirectProperty("isLoaded"));
        }

        public string Root()
        {
            return DirectProperty("root");
        }

        public string Background()
        {
            return SettingsProperty("background");
        }

        public bool EnabledFrameRateCounter()
        {
            return Convert.ToBoolean(SettingsProperty("enabledFramerateCounter"));
        }

        public bool EnableRedrawRegions()
        {
            return Convert.ToBoolean(SettingsProperty("enableRedrawRegions"));
        }

        public bool EnableHtmlAccess()
        {
            return Convert.ToBoolean(SettingsProperty("enableHtmlAccess"));
        }

        public int MaxFrameRate()
        {
            return Convert.ToInt32(SettingsProperty("maxFrameRate"));
        }

        public bool WindowLess()
        {
            return Convert.ToBoolean(SettingsProperty("windowless"));
        }

        public string Source()
        {
            return DirectProperty("source");
        }	
    }
}