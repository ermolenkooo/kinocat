using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;
using System.Collections.ObjectModel;

namespace App1.ViewModels
{
    class LetterViewModel : BaseViewModel
    {
        public Command BackCommand { get; }
        public Command UserCommand { get; }
        public Command FilmCommand { get; }

        private Film selectedFilm;
        private User selectedUser;
        private Letter letter;

        public User User { get; set; }

        public INavigation Navigation { get; set; }

        public LetterViewModel(Letter l, User u)
        {
            letter = l;
            User = u;
            selectedFilm = new Film();
            BackCommand = new Command(OnBackClicked);
            UserCommand = new Command(UserClicked);
            FilmCommand = new Command(FilmClicked);

            var allFilms = App.Database.GetFilms();
            var marks = App.Database.GetMarks();
            var users = App.Database.GetUsers();

            var us = users.Find(x => x.Id == l.Id_user);
            var f = allFilms.Find(x => x.Id == l.Id_film);
            SelectedUser = new User { Id = us.Id, Image = us.Image, Username = us.Username };
            SelectedFilm = new Film { Id = f.Id, Age = f.Age, Country = f.Country, Description = f.Description, Genre = f.Genre, Name = f.Name, Original = f.Original, Poster = f.Poster, Seasons = f.Seasons, Timing = f.Timing, Year = f.Year };
            SelectedFilm.Mark = marks.Find(x => x.Id_user == selectedUser.Id && x.Id_film == selectedFilm.Id).Mark;
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

        public Letter Letter
        {
            get { return letter; }
            set
            {
                if (letter != value)
                {
                    letter = value;
                    OnPropertyChanged("Letter");
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
                    selectedFilm = value;
                    OnPropertyChanged("SelectedFilm");
                }
            }
        }

        private void OnBackClicked(object obj) //стрелка назад
        {
            Navigation.PopAsync();
        }

        private void UserClicked(object obj) //переходим к пользователю
        {
            if (selectedUser.Id == User.Id)
                Navigation.PushAsync(new ProfilPage(User));
            else Navigation.PushAsync(new FollowerPage(selectedUser, User));
        }

        private void FilmClicked(object obj) //переходим к фильму
        {
            if (selectedFilm == null)
                Navigation.PushAsync(new FilmPage(selectedFilm, SelectedUser));
            else
                Navigation.PushAsync(new SerialPage(selectedFilm, SelectedUser));
        }
    }
}
