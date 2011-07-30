using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium;

namespace DBServer.Selenium.Silvernium.Fixtures
{
    public delegate bool Condition();

    public abstract class ComponentFixture
    {
        protected const long Timeout = 30000;
        protected ThoughtWorks.Selenium.Silvernium.Silvernium Silvernium { get; set; }
        protected string Path { get; set; }

        protected ComponentFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string path)
        {
            Silvernium = silvernium;
            Path = path;
            AssertPathPresent(path);
        }

        public void Wait(Condition condition)
        {
            var millisAtStart = CurrentMilliseconds();
            var millisNow = CurrentMilliseconds();
            while (millisNow - millisAtStart <= Timeout)
            {
                if (condition())
                    return;
                Thread.Sleep(100);
                millisNow = CurrentMilliseconds();
            }
        }

        private long CurrentMilliseconds()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        protected ComponentFixture AssertPathPresent(String path)
        {
            var pathPresent = PathPresentCondition(path);
            Wait(pathPresent);
            Assert.IsTrue(pathPresent());
            return this;
        }

        protected Condition PathPresentCondition(string path)
        {
            return delegate
            {
                var invocationResult = Silvernium.Call("FindControl", path);
                return !string.IsNullOrEmpty(invocationResult);
            };
        }

        protected string Call(string functionName, params string[] parameters)
        {
            const int maxRetry = 10;
            const int sleepInterval = 500;
            for (var i = 0; i < maxRetry; i++)
            {
                try
                {
                    return Silvernium.Call(functionName, parameters);
                }
                catch (SeleniumException)
                {
                    if (i < maxRetry)
                    {
                        Thread.Sleep(sleepInterval);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return null;
        }
    }
}