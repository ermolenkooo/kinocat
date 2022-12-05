using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;
using System.Collections.ObjectModel;

namespace App1.ViewModels
{
    class LettersOfFilmViewModel : BaseViewModel
    {
        public Command BackCommand { get; }

        private Film selectedFilm;
        private User selectedUser;
        private InputLetter selectedLetter;
        private ObservableCollection<InputLetter> letters;

        public INavigation Navigation { get; set; }

        public LettersOfFilmViewModel(User u, Film f)
        {
            selectedUser = u;
            selectedFilm = f;
            BackCommand = new Command(OnBackClicked);
            letters = new ObservableCollection<InputLetter>();

            var allFilms = App.Database.GetFilms();
            var marks = App.Database.GetMarks();
            var users = App.Database.GetUsers();
            var let = App.Database.GetLetters();

            foreach (var l in let)
                if (l.Id_film == f.Id)
                    letters.Add(new InputLetter { Id_film = f.Id, Id_user = l.Id_user });
            foreach (var l in letters)
            {
                l.Username = users.Find(x => x.Id == l.Id_user).Username;
                l.Image = users.Find(x => x.Id == l.Id_user).Image;
                l.Mark = marks.Find(x => x.Id_film == f.Id && x.Id_user == l.Id_user).Mark;
            }
        }

        public ObservableCollection<InputLetter> Letters
        {
            get { return letters; }
            set
            {
                if (letters != value)
                {
                    letters = value;
                    OnPropertyChanged("Letters");
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

        public Film SelectedFilm
        {
            get { return selectedFilm; }
            set
            {
                if (selectedFilm != value)
                {
                    Film tempFilm = value;
                    selectedFilm = null;
                    OnPropertyChanged("SelectedFilm");
                }
            }
        }

        public InputLetter SelectedLetter
        {
            get { return selectedLetter; }
            set
            {
                if (selectedLetter != value)
                {
                    InputLetter tempLetter = value;
                    selectedLetter = null;
                    OnPropertyChanged("SelectedLetter");
                    var let = App.Database.GetLetters();
                    var l = let.Find(x => x.Id_film == value.Id_film && x.Id_user == value.Id_user);
                    Navigation.PushAsync(new LetterPage(new Letter { Id = l.Id, Id_film = l.Id_film, Id_user = l.Id_user, Text = l.Text }, SelectedUser));
                }
            }
        }

        private void OnBackClicked(object obj) //стрелка назад
        {
            Navigation.PopAsync();
        }
    }
}
