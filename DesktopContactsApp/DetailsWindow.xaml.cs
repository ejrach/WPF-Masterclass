using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DesktopContactsApp.Classes;
using SQLite;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        Contact contact;

        public DetailsWindow(Contact contact)
        {
            InitializeComponent();

            this.contact = contact;

            nameTextBox.Text = contact.Name;
            phoneNumberTextBox.Text = contact.Phone;
            emailTextBox.Text = contact.Email;
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = nameTextBox.Text;
            contact.Phone = phoneNumberTextBox.Text;
            contact.Email = emailTextBox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();  //this is ignored if the table already exists
                connection.Update(contact);
            }

            //Close the window
            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();  //this is ignored if the table already exists
                connection.Delete(contact);
            }

            //Close the window
            Close();
        }
    }
}
