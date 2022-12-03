using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;
using System.Collections.ObjectModel;

namespace App1.ViewModels
{
    class LettersOfUserViewModel : BaseViewModel
    {
        public Command BackCommand { get; }

        private Film selectedFilm;
        private User selectedUser;
        private ObservableCollection<Film> films;

        public INavigation Navigation { get; set; }

        public LettersOfUserViewModel(User u, User selUser, bool isSerial)
        {
            selectedUser = u;
            selectedFilm = new Film();
            films = new ObservableCollection<Film>();
            BackCommand = new Command(OnBackClicked);

            var allFilms = App.Database.GetFilms();
            var marks = App.Database.GetMarks();
            var letters = App.Database.GetLetters();
            if (!isSerial)
            {
                foreach (var l in letters)
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
                foreach (var l in letters)
                    if (l.Id_user == selUser.Id)
                    {
                        foreach (var f in allFilms)
                            if (f.Id == l.Id_film && f.Seasons != null)
                                films.Add(new Film { Id = f.Id, Age = f.Age, Country = f.Country, Description = f.Description, Genre = f.Genre, Name = f.Name, Original = f.Original, Poster = f.Poster, Seasons = f.Seasons, Timing = f.Timing, Year = f.Year });
                    }
            }
            foreach (var f in films)
                f.Mark = marks.Find(x => x.Id_user == selUser.Id && x.Id_film == f.Id).Mark;
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
                    Film prfilm = value;
                    selectedFilm = null;
                    OnPropertyChanged("SelectedFilm");
                    ToLetter(prfilm);
                }
            }
        }

        private void OnBackClicked(object obj) //стрелка назад
        {
            Navigation.PopAsync();
        }

        public void ToLetter(Film f)
        {
            var letters = App.Database.GetLetters();
            foreach (var l in letters)
                if (l.Id_film == f.Id && l.Id_user == selectedUser.Id)
                {
                    Letter letter = new Letter { Id = l.Id, Id_film = l.Id_film, Id_user = l.Id_user, Text = l.Text };
                    Navigation.PushAsync(new LetterPage(letter, SelectedUser));
                    break;
                }
        }
    }
}
