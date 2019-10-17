using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DesktopContactsApp.Classes;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> contacts;

        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contact>();

            //Read on initialze
            ReadDatabase();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            //Read when the window was closed.
            ReadDatabase();
        }

        void ReadDatabase()
        {
            
            
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();                  //generic method allows us to create a table if it doesn't exist. No error thrown.
                contacts = connection.Table<Contact>().ToList().OrderBy(c => c.Name).ToList();    //generic method allows us to read a table

                //LINQ equivalent of above, example
                //var variable = from c2 in contacts
                //               orderby c2.Name
                //               select c2;
            }

            if (contacts != null)
            {
                contactsListView.ItemsSource = contacts;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            //What this is saying:
            //  We want to take the contacts list and filter the contacts where the name contains whatever the user has written 
            //  in the text box.
            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            //LINQ query example
            //var filteredList2 = (from c2 in contacts
            //                    where c2.Name.ToLower().Contains(searchTextBox.Text.ToLower())
            //                    orderby c2.Name
            //                    select c2).ToList();

            contactsListView.ItemsSource = filteredList;
        }

        private void contactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Contact selectedContact = (Contact)contactsListView.SelectedItem;

            if(selectedContact != null)
            {
                DetailsWindow detailsWindow = new DetailsWindow(selectedContact);
                detailsWindow.ShowDialog();

                ReadDatabase();
            }
        }
    }
}
