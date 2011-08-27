using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace DBServer.Selenium.Silvernium.ReferenceApplication
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            displayMemberPathComboBox.ItemsSource = new Collection<Person>
            {
                new Person {Id = 1, Name = "Arthur"},
                new Person {Id = 2, Name = "John"},
                new Person {Id = 3, Name = "Richard"}
            };
            displayMemberPathComboBox.SelectedIndex = 0;

        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            clearTextBox.Text = "";
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
