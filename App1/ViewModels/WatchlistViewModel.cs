using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;
using System.Collections.ObjectModel;

namespace App1.ViewModels
{
    class WatchlistViewModel : BaseViewModel
    {
        public Command BackCommand { get; }

        private Film selectedFilm;
        private User selectedUser;
        private ObservableCollection<Film> films1;
        private ObservableCollection<Film> films2;

        public INavigation Navigation { get; set; }

        public WatchlistViewModel(User u, User selUser, bool isSerial)
        {
            selectedUser = u;
            selectedFilm = new Film();
            films1 = new ObservableCollection<Film>();
            films2 = new ObservableCollection<Film>();
            BackCommand = new Command(OnBackClicked);

            List<Film> films = new List<Film>();

            var allFilms = App.Database.GetFilms();
            var list = App.Database.GetWatchlist();
            if (!isSerial)
            {
                foreach (var l in list)
                    if (l.Id_user == selUser.Id)
                    {
                        foreach (var f in allFilms)
                            if (f.Id == l.Id_film && f.Seasons == null)
                            {
                                films.Add(new Film { Id = f.Id, Age = f.Age, Country = f.Country, Description = f.Description, Genre = f.Genre, Name = f.Name, Original = f.Original, Poster = f.Poster, Seasons = f.Seasons, Timing = f.Timing, Year = f.Year });
                                break;
                            }
                    }
            }
            else
            {
                foreach (var l in list)
                    if (l.Id_user == selUser.Id)
                    {
                        foreach (var f in allFilms)
                            if (f.Id == l.Id_film && f.Seasons != null)
                                films.Add(new Film { Id = f.Id, Age = f.Age, Country = f.Country, Description = f.Description, Genre = f.Genre, Name = f.Name, Original = f.Original, Poster = f.Poster, Seasons = f.Seasons, Timing = f.Timing, Year = f.Year });
                    }
            }

            for (int i = 0; i < films.Count; i++)
                if (i % 2 == 0)
                    films1.Add(films[i]);
                else
                    films2.Add(films[i]);
        }

        public ObservableCollection<Film> Films1
        {
            get { return films1; }
            set
            {
                if (films1 != value)
                {
                    films1 = value;
                    OnPropertyChanged("Films1");
                }
            }
        }

        public ObservableCollection<Film> Films2
        {
            get { return films2; }
            set
            {
                if (films2 != value)
                {
                    films2 = value;
                    OnPropertyChanged("Films2");
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
                    User tempUser = value;
                    selectedUser = null;
                    OnPropertyChanged("SelectedUser");
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
                    Film tempf = value;
                    selectedFilm = null;
                    OnPropertyChanged("SelectedFilm");
                    if (tempf.Seasons == null)
                        Navigation.PushAsync(new FilmPage(tempf, SelectedUser));
                    else
                        Navigation.PushAsync(new SerialPage(tempf, SelectedUser));
                }
            }
        }

        private void OnBackClicked(object obj) //стрелка назад
        {
            Navigation.PopAsync();
        }
    }
}
