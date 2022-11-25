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

        public INavigation Navigation { get; set; }

        public LetterViewModel(Letter l)
        {
            letter = l;
            selectedUser = new User();
            selectedFilm = new Film();
            BackCommand = new Command(OnBackClicked);
            UserCommand = new Command(UserClicked);
            FilmCommand = new Command(FilmClicked);

            FilmList allFilms = new FilmList();
            allFilms.GetFilms();
            MarkOfUserList marks = new MarkOfUserList();
            marks.GetMarks();
            UserList users = new UserList();
            users.GetUsers();
            SelectedUser = users.Users.Find(x => x.Id == l.Id_user);
            SelectedFilm = allFilms.Films.Find(x => x.Id == l.Id_film);
            SelectedFilm.Mark = marks.Marks.Find(x => x.Id_user == selectedUser.Id && x.Id_film == selectedFilm.Id).Mark;
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

        }

        private void FilmClicked(object obj) //переходим к фильму
        {

        }
    }
}
