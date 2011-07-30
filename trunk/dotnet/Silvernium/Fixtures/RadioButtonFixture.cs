using System;

namespace DBServer.Selenium.Silvernium.Fixtures
{
    public class RadioButtonFixture : ComponentFixture
    {
        public RadioButtonFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string path) 
            : base(silvernium, path) { }

        public RadioButtonFixture Select()
        {
            Call("SetValue", Path, Boolean.TrueString);
            return this;
        }

        public RadioButtonFixture RequireSelected()
        {
            var value = Call("GetValue", Path);
            if (!Boolean.Parse(value))
            {
                throw new SilverniumFixtureException("Radio button was not selected");
            }
            return this;
        }

        public RadioButtonFixture RequireUnselected()
        {
            var value = Call("GetValue", Path);
            if (Boolean.Parse(value))
            {
                throw new SilverniumFixtureException("Radio button was selected");
            }
            return this;
        }
    }
}