using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        //Basically this interface is defined so that if the view changes, then the property is updated.
        //And vice versa.

        private string _query;

        public string Query
        {
            get { return _query; }
            set 
            { 
                _query = value;
                OnPropertyChange("Query");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChange(string propertyName)
        {
            //This triggers the event
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
