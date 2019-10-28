using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NotesApp.Models
{
    public class Notebook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int _userId;

        [Indexed]
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private string _name;

        

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


    }
}
