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
        private Contact _contact;

        public Contact Contact
        {
            get { return _contact; }
            set 
            { 
                _contact = value;
                nameTextBlock.Text = _contact.Name;
                phoneTextBlock.Text = _contact.Phone;
                emailTextBlock.Text = _contact.Email;
            }
        }

        public ContactControl()
        {
            InitializeComponent();
        }
    }
}
