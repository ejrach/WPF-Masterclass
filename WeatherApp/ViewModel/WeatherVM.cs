using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using WeatherApp.Model;

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

        private CurrentConditions _currentConditions;

        public CurrentConditions CurrentConditions
        {
            get { return _currentConditions; }
            set 
            { 
                _currentConditions = value;
                OnPropertyChange("CurrentConditions");
            }
        }

        private City _selectedCity;

        public City SelectedCity
        {
            get { return _selectedCity; }
            set 
            { 
                _selectedCity = value;
                OnPropertyChange("SelectedCity");
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
