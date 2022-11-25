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
        public Command ClickCommand { get; }

        private Film selectedFilm;
        private User selectedUser;
        private ObservableCollection<Film> films1;
        private ObservableCollection<Film> films2;

        public INavigation Navigation { get; set; }

        public WatchlistViewModel(User u)
        {
            selectedUser = u;
            selectedFilm = new Film();
            films1 = new ObservableCollection<Film>();
            films2 = new ObservableCollection<Film>();
            BackCommand = new Command(OnBackClicked);
            ClickCommand = new Command(OnButtonClicked);

            List<Film> films = new List<Film>();
            FilmList allFilms = new FilmList();
            allFilms.GetFilms();
            WatchList list = new WatchList();
            list.GetWatches();
            foreach (var m in list.Watches)
                if (m.Id_user == selectedUser.Id)
                    films.Add(allFilms.Films.Find(x => x.Id == m.Id_film));
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
