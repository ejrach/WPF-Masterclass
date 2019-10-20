using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using WeatherApp.Model;
using WeatherApp.ViewModel.Helpers;
using WeatherApp.ViewModel.Commands;
using System.Collections.ObjectModel;

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

        public ObservableCollection<City> Cities { get; set; }

        public SearchCommand SearchCommand { get; set; }

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

        public WeatherVM()
        {
            //Display data during design time, just to show data is binding to the view.
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
            {
                SelectedCity = new City
                {
                    LocalizedName = "New York"
                };

                CurrentConditions = new CurrentConditions
                {
                    WeatherText = "Partly cloudy",
                    Temperature = new Temperature
                    {
                        Imperial = new Units
                        {
                            Value = 65
                        }
                    }
                };
            }

            //Want to initialize the search command, even outside of design time.
            SearchCommand = new SearchCommand(this);

            Cities = new ObservableCollection<City>();
        }

        //This will be executed when the user presses the search button.
        public async void  MakeQuery()
        {
            var cities = await AccuWeatherHelper.GetCities(Query);

            Cities.Clear();

            //Add the cities from the query to the observable collection.
            foreach(var city in cities)
            {
                Cities.Add(city);
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
