using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBServer.Selenium.Silvernium.Fixtures
{
    public class SilverniumFixtureException : Exception
    {
        public SilverniumFixtureException(string message) : base(message) { }
    }
}
