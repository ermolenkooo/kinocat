using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;
using System.Collections.ObjectModel;

namespace App1.ViewModels
{
    class LoveViewModel : BaseViewModel
    {
        public Command BackCommand { get; }
        public Command ClickCommand { get; }

        private Film selectedFilm;
        private User selectedUser;
        private ObservableCollection<Film> films;

        public INavigation Navigation { get; set; }

        public LoveViewModel(User u)
        {
            selectedUser = u;
            selectedFilm = new Film();
            films = new ObservableCollection<Film>();
            BackCommand = new Command(OnBackClicked);
            ClickCommand = new Command(OnButtonClicked);

            FilmList allFilms = new FilmList();
            allFilms.GetFilms();
            MarkOfUserList marks = new MarkOfUserList();
            marks.GetMarks();
            LoveList loves = new LoveList();
            loves.GetLoves();
            foreach (var l in loves.Loves)
                if (l.Id_user == selectedUser.Id)
                    films.Add(allFilms.Films.Find(x => x.Id == l.Id_film));
            foreach (var f in films)
                f.Mark = marks.Marks.Find(x => x.Id_user == selectedUser.Id && x.Id_film == f.Id).Mark;
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
                    Navigation.PushAsync(new FollowerPage(tempUser));
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
                    Navigation.PushAsync(new FilmPage(value, SelectedUser));
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
