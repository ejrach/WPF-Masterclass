using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NotesApp.Models
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private int _id;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        [MaxLength(50)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }



        private string _lastname;

        [MaxLength(50)]
        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        private string _username;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _password;

        

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

    }
}
