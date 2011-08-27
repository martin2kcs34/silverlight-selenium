using System;
using System.Linq;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace DBServer.Selenium.Silvernium.ReferenceApplication
{
    [ScriptableType]
    public partial class SilverlightFixture
    {
        public SilverlightFixture()
        {
            InitializeComponent();
            HtmlPage.RegisterScriptableObject("SilverlightFixture", this);
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
            if (component is ComboBox)
            {
                return GetValue(component as ComboBox);
            }
            throw new SilverlightFixtureException("Unsupported component type: " + component.GetType());
        }

        private string GetValue(ComboBox comboBox)
        {
            var displayMemberPath = comboBox.DisplayMemberPath;

            var item = comboBox.SelectedItem;
            var comboBoxItem = item as ComboBoxItem;

            if (item == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(displayMemberPath))
            {
                return (string)item.GetType().GetProperty(displayMemberPath).GetValue(item, null);
            }
            if (comboBoxItem != null && comboBoxItem.Content.GetType() == typeof(string))
            {
                return (string) comboBoxItem.Content;
            }
            if (item is DependencyObject)
            {
                return GetStringsFromPropertiesOfItselfAndChildren(item as DependencyObject, "");
            }
            throw new SilverlightFixtureException("Could not retrieve combo box value");
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
                ((RadioButton)component).IsChecked = Boolean.Parse(value);
            }
            else if (component is ComboBox)
            {
                SetValue(component as ComboBox, value);
            }
        }

        private void SetValue(ComboBox comboBox, string value)
        {
            var displayMemberPath = comboBox.DisplayMemberPath;
            for (var i = 0; i < comboBox.Items.Count; i++)
            {
                var item = comboBox.Items.ElementAt(i);
                var comboBoxItem = item as ComboBoxItem;

                if (item == null)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        comboBox.SelectedItem = item;
                        return;
                    }
                    continue;
                }

                if (!string.IsNullOrEmpty(displayMemberPath))
                {
                    var displayValue = (string)item.GetType().GetProperty(displayMemberPath).GetValue(item, null);
                    if (value == displayValue)
                    {
                        comboBox.SelectedItem = item;
                        return;
                    }
                }
                else if (comboBoxItem != null && comboBoxItem.Content.GetType() == typeof(string) && ((string)comboBoxItem.Content) == value)
                {
                    comboBox.SelectedItem = item;
                    return;
                }
                else if (item is DependencyObject && HasStringInSomePropertyOfItselfOrChildren(item as DependencyObject, value))
                {
                    comboBox.SelectedItem = item;
                    return;                  
                }

                //if (item.ContentTemplate != null && item.ContentTemplate.GetVisualChildren())
                //{
                //}
            }

            throw new SilverlightFixtureException("Value not found: " + value);
        }

        private bool HasStringInSomePropertyOfItselfOrChildren(DependencyObject node, string value)
        {
            foreach (var property in node.GetType().GetProperties())
            {
                if (property.CanRead && property.GetValue(node, null) as string == value)
                {
                    return true;
                }
            }
            foreach (var child in node.GetVisualChildren())
            {
                if (HasStringInSomePropertyOfItselfOrChildren(child, value))
                {
                    return true;
                }
            }
            return false;
        }

        private string GetStringsFromPropertiesOfItselfAndChildren(DependencyObject node, string currentStrings)
        {
            foreach (var property in node.GetType().GetProperties())
            {
                if (property.CanRead)
                {
                    currentStrings += "|" + property.GetValue(node, null);
                }
            }
            foreach (var child in node.GetVisualChildren())
            {
                currentStrings = GetStringsFromPropertiesOfItselfAndChildren(child, currentStrings);
            }
            return currentStrings;
        }

        public new string IsEnabled(String path)
        {
            var component = FindControl(path);
            if (component is TextBox)
            {
                return (!((TextBox) component).IsReadOnly).ToString();
            }
            if (component is ComboBox)
            {
                return (((ComboBox)component).IsEnabled).ToString();
            }
            if (component is Button)
            {
                return (((Button) component).IsEnabled).ToString();
            }
            throw new SilverlightFixtureException("Unsupported component type: " + component.GetType());
        }

        public void Click(String path)
        {
            var button = (Button)FindControl(path);
            var peer = new ButtonAutomationPeer(button);
            var ip = (IInvokeProvider)peer;
            ip.Invoke();
        }

        public string GetProperty(String path, String propertyName)
        {
            var component = FindControl(path);
            return component.GetType().GetProperty(propertyName).GetValue(component, null).ToString();
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

        public string Describe(String path)
        {
            return Describe(FindControl(path), "");
        }

        private string Describe(DependencyObject node, string identation)
        {
            var description = identation == string.Empty ? "" : identation.Substring(0, identation.Length - 1) + "-";
            description += node;
            description += !string.IsNullOrEmpty(node.GetValue(NameProperty).ToString()) 
                ? " - " + node.GetValue(NameProperty) : "";
            if (node.GetType() == typeof(TextBlock))
            {
                description += " - " + ((TextBlock)node).Text;
            }
            description += "\n";
            foreach (var child in node.GetVisualChildren())
            {
                description += Describe(child, identation + "| ");
            }
            return description;
        }
    }

    internal class SilverlightFixtureException : Exception
    {
        public SilverlightFixtureException(string message) 
            : base(message) { }
    }

}
