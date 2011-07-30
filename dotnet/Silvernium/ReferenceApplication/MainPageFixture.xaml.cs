using System;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DBServer.Selenium.Silvernium.ReferenceApplication
{
    [ScriptableType]
    public partial class MainPageFixture
    {
        public MainPageFixture()
        {
            InitializeComponent();
            HtmlPage.RegisterScriptableObject("MainPageFixture", this);
        }

        public string SayHello()
        {
            return "Hello, World!";
        }

        public string GetValue(string path)
        {
            var component = FindControl(path);
            return GetValue(component);
        }

        private string GetValue(DependencyObject component)
        {
            if (component is AutoCompleteBox)
            {
                return ((AutoCompleteBox)component).Text;
            }
            if (component is TextBox)
            {
                return ((TextBox)component).Text;
            }
            if (component is TextBlock)
            {
                return ((TextBlock)component).Text;
            }
            if (component is CheckBox)
            {
                return ((CheckBox)component).IsChecked.ToString();
            }
            if (component is RadioButton)
            {
                return ((RadioButton) component).IsChecked.ToString();
            }
            throw new UnsupportedComponentException(component.GetType());
        }

        public void SetValue(string path, string value)
        {
            var component = FindControl(path);
            SetValue(component, value);
        }

        private void SetValue(DependencyObject component, string value)
        {
            if (component is AutoCompleteBox)
            {
                ((AutoCompleteBox)component).Text = value;
            }
            else if (component is TextBox)
            {
                ((TextBox)component).Text = value;
            }
            else if (component is CheckBox)
            {
                ((CheckBox)component).IsChecked = Boolean.Parse(value);
            }
            else if (component is RadioButton)
            {
                ((RadioButton) component).IsChecked = Boolean.Parse(value);
            }
        }

        public new string IsEnabled(String path)
        {
            var component = FindControl(path);
            if (component is TextBox)
            {
                return (!((TextBox) component).IsReadOnly).ToString();
            }
            throw new UnsupportedComponentException(component.GetType());
        }

        public DependencyObject FindControl(String path)
        {
            var currentNode = WindowTracker.Instance().IsEmpty() ? this : (DependencyObject)WindowTracker.Instance().CurrentWindow();
            foreach (var partialPath in path.Split('.'))
            {
                currentNode = FindControl(partialPath, currentNode);
                if (currentNode == null)
                {
                    return null;
                }
            }
            return currentNode;
        }

        private DependencyObject FindControl(string id, DependencyObject currentParent)
        {
            var currChildren = currentParent.GetVisualChildren();
            foreach (var item in currChildren)
            {
                if (item.GetValue(NameProperty).ToString().Equals(id))
                    return item;

                var childItem = FindControl(id, item);
                if (childItem != null)
                    return childItem;
            }

            return null;
        }
    }

    internal class UnsupportedComponentException : Exception
    {
        public UnsupportedComponentException(Type type) 
            : base(type.ToString()) { }
    }
}
