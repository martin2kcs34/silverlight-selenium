using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Selenium;

namespace DBServer.Selenium.Silvernium.Fixtures
{
    public class SilverlightApplicationFixture
    {
        private const string ObjectId = "silverlight";
        private const string Scriptkey = "MainPageFixture";

        private readonly ISelenium _selenium;
        private readonly ThoughtWorks.Selenium.Silvernium.Silvernium _silvernium;

        public SilverlightApplicationFixture(string host, int port, string browserString, string url)
        {
            _selenium = new DefaultSelenium(host, port, browserString, url);
            _selenium.Start();
            _selenium.Open(url);
            _selenium.SetSpeed("100");
            _silvernium = new ThoughtWorks.Selenium.Silvernium.Silvernium(_selenium, ObjectId, Scriptkey);
            while (!_silvernium.IsLoaded())
            {
                Thread.Sleep(100);
            }
        }

        public TextBoxFixture TextBox(string path)
        {
            return new TextBoxFixture(_silvernium, path);
        }

        public CheckBoxFixture CheckBox(string path)
        {
            return new CheckBoxFixture(_silvernium, path);
        }

        public TextBlockFixture TextBlock(string path)
        {
            return new TextBlockFixture(_silvernium, path);
        }

        public RadioButtonFixture RadioButton(string path)
        {
            return new RadioButtonFixture(_silvernium, path);
        }

    }
}
