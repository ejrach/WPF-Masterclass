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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DesktopContactsApp.Classes;

namespace DesktopContactsApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        //Use the "propdp" snippet to create a dependency property. This allows us to use a control in XAML
        public Contact Contact
        {
            get { return (Contact)GetValue(ContactProperty); }
            set { SetValue(ContactProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Contact.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContactProperty =
            DependencyProperty.Register("Contact", 
                typeof(Contact), 
                typeof(ContactControl), 
                new PropertyMetadata(new Contact() { 
                    Name ="Name Lastname", 
                    Phone = "123-456-7890", 
                    Email = "email@domain.com" }
                ,SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = d as ContactControl;

            if (control != null)
            {
                //We get the NewValue that is assigned to the contact
                control.nameTextBlock.Text = (e.NewValue as Contact).Name;
                control.emailTextBlock.Text = (e.NewValue as Contact).Email;
                control.phoneTextBlock.Text = (e.NewValue as Contact).Phone;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
