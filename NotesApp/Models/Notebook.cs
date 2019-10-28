using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.Models
{
    public class Notebook
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int _userId;

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
