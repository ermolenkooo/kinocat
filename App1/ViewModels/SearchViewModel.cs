using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;
using System.Collections.ObjectModel;

namespace App1.ViewModels
{
    class SearchViewModel : BaseViewModel
    {
        public Command BackCommand { get; }

        private string search;
        private Film selectedFilm;
        private ObservableCollection<Film> films;
        private ObservableCollection<Film> films1;
        private ObservableCollection<Film> films2;
        private User selectedUser;

        public INavigation Navigation { get; set; }

        public SearchViewModel(User u)
        {
            selectedUser = u;
            selectedFilm = new Film();
            films = new ObservableCollection<Film>();
            films1 = new ObservableCollection<Film>();
            films2 = new ObservableCollection<Film>();
            BackCommand = new Command(OnBackClicked);

            var allFilms = App.Database.GetFilms();
            foreach (var f in allFilms)
                films.Add(new Film { Id = f.Id, Age = f.Age, Country = f.Country, Description = f.Description, Genre = f.Genre, Name = f.Name, Original = f.Original, Poster = f.Poster, Seasons = f.Seasons, Timing = f.Timing, Year = f.Year });
        }

        public ObservableCollection<Film> Films
        {
            get { return films; }
            set
            {
                if (films != value)
                {
                    films = value;
                    OnPropertyChanged("Films");
                }
            }
        }

        public ObservableCollection<Film> Films1
        {
            get { return films1; }
            set
            {
                films1 = value;
                OnPropertyChanged("Films1");
            }
        }

        public ObservableCollection<Film> Films2
        {
            get { return films2; }
            set
            {
                films2 = value;
                OnPropertyChanged("Films2");
            }
        }

        public string Search
        {
            get { return search; }
            set
            {
                if (search != value)
                {
                    search = value;
                    OnPropertyChanged("Search");
                    Searching();
                }
            }
        }

        public Film SelectedFilm
        {
            get { return selectedFilm; }
            set
            {
                if (selectedFilm != value)
                {
                    Film tmpfilm = value;
                    selectedFilm = null;
                    OnPropertyChanged("SelectedFilm");
                    if (tmpfilm.Seasons == null)
                        Navigation.PushAsync(new FilmPage(tmpfilm, SelectedUser));
                    else
                        Navigation.PushAsync(new SerialPage(tmpfilm, SelectedUser));
                }
            }
        }

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                if (selectedUser != value)
                {
                    selectedUser = value;
                    OnPropertyChanged("SelectedUser");
                }
            }
        }

        private void OnBackClicked(object obj) //стрелка назад
        {
            Navigation.PushAsync(new ProfilPage(selectedUser));
        }

        private void Searching()
        {
            ObservableCollection<Film> prfilms1 = new ObservableCollection<Film>();
            ObservableCollection<Film> prfilms2 = new ObservableCollection<Film>();

            List<Film> searchfilms = new List<Film>();

            foreach (var f in films) 
                if (f.Name.StartsWith(search, StringComparison.OrdinalIgnoreCase)) 
                    searchfilms.Add(f);

            if (search != "")
                for (int i = 0; i < searchfilms.Count; i++)
                    if (i % 2 == 0)
                        prfilms1.Add(searchfilms[i]);
                    else
                        prfilms2.Add(searchfilms[i]);

            Films1 = prfilms1;
            Films2 = prfilms2;
        }
    }
}
