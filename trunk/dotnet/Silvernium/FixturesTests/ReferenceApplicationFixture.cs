using System;

namespace DBServer.Selenium.Silvernium.Fixtures.Tests
{
    class ReferenceApplicationFixture : SilverlightApplicationFixture
    {
        private const string Host = "localhost";
        private const int Port = 4444;
        private const string BrowserString = "*firefox";
        private const string Url = "http://localhost:1981/ReferenceApplication.aspx?testMode=true";

        private static ReferenceApplicationFixture _instance;

        public static ReferenceApplicationFixture Instance()
        {
            return _instance ?? (_instance = new ReferenceApplicationFixture());
        }

        private ReferenceApplicationFixture() : base(Host, Port, BrowserString, Url) { }

    }
}
