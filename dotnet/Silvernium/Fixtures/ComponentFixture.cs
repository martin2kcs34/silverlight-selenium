using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selenium;

namespace DBServer.Selenium.Silvernium.Fixtures
{
    public delegate bool Condition();

    public abstract class ComponentFixture
    {
        protected const long Timeout = 5000;
        protected ThoughtWorks.Selenium.Silvernium.Silvernium Silvernium { get; set; }
        protected string GridPath { get; private set; }
        protected int RowIndex { get; private set; }
        protected string Path { get; private set; }

        protected ComponentFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, string path)
        {
            Silvernium = silvernium;
            Path = path;
            AssertPathPresent(path);
        }

        protected ComponentFixture(ThoughtWorks.Selenium.Silvernium.Silvernium silvernium, 
            string gridPath, int rowIndex, string path)
        {
            Silvernium = silvernium;
            GridPath = gridPath;
            RowIndex = rowIndex;
            Path = path;
            AssertPathPresent(gridPath, rowIndex, path);
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

        protected ComponentFixture AssertPathPresent(string path)
        {
            var pathPresent = PathPresentCondition(path);
            Wait(pathPresent);
            if (!pathPresent())
            {
                throw new SilverniumFixtureException("Could not find control for path '" + path + "'");
            }
            return this;
        }

        protected ComponentFixture AssertPathPresent(string gridPath, int rowIndex, string path)
        {
            var pathPresent = PathPresentCondition(gridPath, rowIndex, path);
            Wait(pathPresent);
            if (!pathPresent())
            {
                throw new SilverniumFixtureException("Could not find control for path '" 
                    + gridPath + "[" + rowIndex + "]." + path + "'");
            }
            return this;
        }

        protected Condition PathPresentCondition(string path)
        {
            return delegate
            {
                var invocationResult = Silvernium.Call("FindControl", path);
                return invocationResult != "null";
            };
        }

        protected Condition PathPresentCondition(string gridPath, int rowIndex, string path)
        {
            return delegate
            {
                var invocationResult = Silvernium.Call("FindControl", gridPath, rowIndex.ToString(), path);
                return invocationResult != "null";
            };
        }

        protected string Call(string functionName, params string[] parameters)
        {
            var parametersWithPath = new List<string>();
            if (GridPath != null)
            {
                parametersWithPath.Add(GridPath);
                parametersWithPath.Add(RowIndex.ToString());
            }
            parametersWithPath.Add(Path);
            parametersWithPath.AddRange(parameters);

            const int maxRetry = 10;
            const int sleepInterval = 500;
            for (var i = 0; i < maxRetry; i++)
            {
                try
                {
                    return Silvernium.Call(functionName, parametersWithPath.ToArray());
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