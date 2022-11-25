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
        public Command ClickCommand { get; }

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
            ClickCommand = new Command(OnButtonClicked);
            letters = new ObservableCollection<InputLetter>();

            FilmList allFilms = new FilmList();
            allFilms.GetFilms();
            MarkOfUserList marks = new MarkOfUserList();
            marks.GetMarks();
            UserList users = new UserList();
            users.GetUsers();
            LetterList let = new LetterList();
            let.GetLetters();

            foreach (var l in let.Letters)
                if (l.Id_film == f.Id)
                    letters.Add(new InputLetter { Id_film = f.Id, Id_user = l.Id_user, Mark = 2, Image = "", Username = "" });
            foreach (var l in letters)
            {
                l.Username = users.Users.Find(x => x.Id == l.Id_user).Username;
                l.Image = users.Users.Find(x => x.Id == l.Id_user).Image;
                l.Mark = marks.Marks.Find(x => x.Id_film == f.Id && x.Id_user == l.Id_user).Mark;
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
                    Navigation.PushAsync(new FilmPage(tempFilm, SelectedUser));
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
                    LetterList let = new LetterList();
                    let.GetLetters();
                    Letter l = let.Letters.Find(x => x.Id_film == value.Id_film && x.Id_user == value.Id_user);
                    Navigation.PushAsync(new LetterPage(l));
                }
            }
        }

        private void OnBackClicked(object obj) //стрелка назад
        {
            Navigation.PopAsync();
        }

        private void OnButtonClicked(object obj) //переходим к фильму
        {

        }
    }
}
