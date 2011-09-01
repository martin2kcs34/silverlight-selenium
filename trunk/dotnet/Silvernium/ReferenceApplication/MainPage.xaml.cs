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

            InitializeDisplayMemberPathComboBox();

            InitializeMusiciansDataGrid();
        }

        private void InitializeMusiciansDataGrid()
        {
            musiciansDataGrid.ItemsSource = new Collection<Musician>
                                               {
                                                   new Musician {Id = 1, Name = "Alex", Instrument = "Guitar"},
                                                   new Musician {Id = 2, Name = "Geddy", Instrument = "Bass"},
                                                   new Musician {Id = 3, Name = "Neil", Instrument = "Drums"}
                                               };
        }

        private void InitializeDisplayMemberPathComboBox()
        {
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

        private void MusiciansDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (musiciansDataGrid.SelectedItem is Musician)
            {
                var musician = (Musician) musiciansDataGrid.SelectedItem;
                musicianTextBlock.Text = musician.Name + " plays " + musician.Instrument;
            }
            else
            {
                musicianTextBlock.Text = "";
            }
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Musician : Person
    {
        public string Instrument { get; set; }
    }
}
