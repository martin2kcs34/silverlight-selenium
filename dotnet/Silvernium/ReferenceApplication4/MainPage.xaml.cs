using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DBServer.Selenium.Silvernium.ReferenceApplication
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            InitializeDisplayMemberPathComboBox();
            InitializeMusiciansDataGrid();
            InitializeBooksDataGrid();
            InitializeEditableDataGrid();
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

        private void InitializeMusiciansDataGrid()
        {
            musiciansDataGrid.ItemsSource = new Collection<Musician>
                                               {
                                                   new Musician {Id = 1, Name = "Alex", Instrument = "Guitar"},
                                                   new Musician {Id = 2, Name = "Geddy", Instrument = "Bass"},
                                                   new Musician {Id = 3, Name = "Neil", Instrument = "Drums"}
                                               };
        }

        private void InitializeBooksDataGrid()
        {
            var books = new Collection<Book>
                            {
                                new Book {Title = "2001 - A Space Odissey", Author = "Arthur C. Clarke"},
                                new Book {Title = "Cien Anos de Soledad", Author = "Gabriel Garcia Marquez"},
                                new Book {Title = "Dom Casmurro", Author = "Machado de Assis"},
                                new Book {Title = "For Whom the Bell Tolls", Author = "Ernest Hemingway"},
                                new Book {Title = "La Invencion de Morel", Author = "Adolfo Bioy Casares"},
                                new Book {Title = "Los Siete Locos", Author = "Roberto Arlt"},
                                new Book {Title = "O Tempo e o Vento", Author = "Erico Verissimo"},
                                new Book {Title = "The Lord of The Rings", Author = "J.R.R. Tolkien"},
                                new Book {Title = "The Unbearable Lightness of Being", Author = "Milan Kundera"}
                            };
            var pagedView = new PagedCollectionView(books);
            booksDataGrid.ItemsSource = pagedView;
            booksDataPager.Source = pagedView;
        }

        private void InitializeEditableDataGrid()
        {
            editableDataGrid.ItemsSource =
                new Collection<EditableDataRow>
                {
                   new EditableDataRow {Editable = true, Label = "Row 1", ButtonContent = "Button 1",
                       Checked = true, SelectedIndex = 0, TextBlockText = "TextBlock 1", TextBoxText = "TextBox 1"},
                   new EditableDataRow {Editable = true, Label = "Row 2", ButtonContent = "Button 2",
                       Checked = false, SelectedIndex = 1, TextBlockText = "TextBlock 2", TextBoxText = "TextBox 2"},
                   new EditableDataRow {Editable = false, Label = "Row 3", ButtonContent = "Button 3",
                       Checked = true, SelectedIndex = 0, TextBlockText = "TextBlock 3", TextBoxText = "TextBox 3"}
                };
        }

        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            clearTextBox.Text = "";
        }

        private void MusiciansDataGridSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (musiciansDataGrid.SelectedItem is Musician)
            {
                var musician = (Musician)musiciansDataGrid.SelectedItem;
                musicianTextBlock.Text = musician.Name + " plays " + musician.Instrument;
            }
            else
            {
                musicianTextBlock.Text = "";
            }
        }

        private void InnerButtonClick(object sender, RoutedEventArgs e)
        {
            var innerButton = (Button)sender;
            new ModalWindow("Clicked at " + innerButton.Content).Show();
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

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class EditableDataRow
    {
        public bool Editable { get; set; }
        public bool ReadOnly
        {
            get { return !Editable; }
        }
        public string Label { get; set; }
        public string ButtonContent { get; set; }
        public bool Checked { get; set; }
        public int SelectedIndex { get; set; }
        public string TextBlockText { get; set; }
        public string TextBoxText { get; set; }
    }

}
