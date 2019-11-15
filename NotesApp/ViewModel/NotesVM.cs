using NotesApp.Models;
using NotesApp.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NotesApp.ViewModel
{
    //What we want to do in this ViewModel:
    //  1. List notebooks
    //  2. List notes
    //  3. Display text inside a file
    //  4. Commands like create new notebook and create new note.
    public class NotesVM
    {
        public ObservableCollection<Notebook> Notebooks { get; set; }

        private Notebook _selectedNotebook;

        public Notebook SelectedNotebook
        {
            get { return _selectedNotebook; }
            set 
            { 
                _selectedNotebook = value; 
                //Todo: get notes
            }
        }

        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand NewNotebookCommand { get; set; }

        public NewNoteCommand NewNoteCommand { get; set; }

        public NotesVM()
        {
            NewNotebookCommand = new NewNotebookCommand(this);
            NewNoteCommand = new NewNoteCommand(this);

            //Create observable collections
            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();

            ReadNotebooks();
        }

        public void CreateNotebook()
        {
            Notebook notebook = new Notebook()
            {
                Name = "New Notebook"
            };

            DatabaseHelper.Insert(notebook);
        }

        public void CreateNote(int notebookId)
        {
            Note newNote = new Note()
            {
                NotebookId = notebookId,
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now,
                Title = "New Note"
            };

            DatabaseHelper.Insert(newNote);
        }

        public void ReadNotebooks()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                var notebooks = conn.Table<Notebook>().ToList();

                //First clear the oberservable collection
                Notebooks.Clear();
                foreach (var notebook in notebooks)
                {
                    Notebooks.Add(notebook);
                }
            }
        }

        public void ReadNotes()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DatabaseHelper.dbFile))
            {
                if(SelectedNotebook != null)
                {
                    //Using "where" so we only read notes that are part of the notebook.
                    var notes = conn.Table<Note>().Where(n => n.NotebookId == SelectedNotebook.Id).ToList();

                    //First clear the oberservable collection
                    Notes.Clear();
                    foreach (var note in notes)
                    {
                        notes.Add(note);
                    }
                }
            }
        }
    }
}
