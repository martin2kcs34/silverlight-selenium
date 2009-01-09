using System;
using System.Linq;
using Selenium;

namespace ThoughtWorks.Selenium.Silvernium
{
    public class Silvernium
    {
        private readonly string scriptKey = "";
        private readonly ISelenium selenium;
        private readonly String silverLightJSStringPrefix;

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
            if (appName.Contains(BrowserConstants.FIREFOX3) || appName.Contains(BrowserConstants.IE))
            {
                return createJSPrefixWindowDocument(silverlightObjectId);
            }
            else if (appName.Contains(BrowserConstants.FIREFOX2))
            {
                return createJSPrefixDocument(silverlightObjectId);
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

        public String jsForDirectMethod(String functionName, params string[] parameters)
        {
            string functionArgs = "";
            if (parameters.Count() > 0)
            {
                ;
                for (int i = 0; i < parameters.Count(); i++)
                {
                    functionArgs = functionArgs + "'" + parameters[i] + "',";
                }
                // remove last comma
                functionArgs = functionArgs.Substring(0, functionArgs.Length - 1);
            }
            return silverLightJSStringPrefix + functionName + "(" + functionArgs + ");";
        }

        public String jsForContentScriptMethod(String functionName, params string[] parameters)
        {
            String functionArgs = "";
            if (parameters.Count() > 0)
            {
                ;
                for (int i = 0; i < parameters.Count(); i++)
                {
                    functionArgs = functionArgs + "'" + parameters[i] + "',";
                }
                // remove last comma
                functionArgs = functionArgs.Substring(0, functionArgs.Length - 1);
            }
            return silverLightJSStringPrefix + "content." + scriptKey + functionName + "(" + functionArgs + ");";
        }

        public String jsForContentMethod(String functionName, params string[] parameters)
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
    }
}