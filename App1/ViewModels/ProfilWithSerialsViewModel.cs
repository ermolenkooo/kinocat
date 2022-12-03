using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;

namespace App1.ViewModels
{
    public class ProfilWithSerialsViewModel : BaseViewModel
    {
        public Command FollowingCommand { get; }
        public Command FollowersCommand { get; }
        public Command FilmsCommand { get; }
        public Command MarksCommand { get; }
        public Command WatchlistCommand { get; }
        public Command LoveCommand { get; }
        public Command LettersCommand { get; }
        public Command SearchCommand { get; }

        //user

        public INavigation Navigation { get; set; }

        User user;

        public User User
        {
            get { return user; }
            set
            {
                if (user != value)
                {
                    user = value;
                    OnPropertyChanged("User");
                }
            }
        }

        public ProfilWithSerialsViewModel(User u)
        {
            User = u;
            FollowingCommand = new Command(OnFollowingClicked);
            FollowersCommand = new Command(OnFollowersClicked);
            FilmsCommand = new Command(OnFilmsClicked);
            MarksCommand = new Command(OnMarksClicked);
            WatchlistCommand = new Command(OnWatchlistClicked);
            LoveCommand = new Command(OnLoveClicked);
            LettersCommand = new Command(OnLettersClicked);
            SearchCommand = new Command(OnSearchClicked);
        }

        private void OnFollowingClicked(object obj)
        {
            Navigation.PushAsync(new FollowingPage());
        }

        private void OnFollowersClicked(object obj)
        {
            Navigation.PushAsync(new FollowersPage());
        }

        private void OnFilmsClicked(object obj)
        {
            Navigation.PushAsync(new ProfilPage(user));
        }

        private void OnMarksClicked(object obj)
        {
            Navigation.PushAsync(new MarksPage(user, user, true));
        }

        private void OnWatchlistClicked(object obj)
        {
            Navigation.PushAsync(new WatchlistPage(user, user, true));
        }

        private void OnLoveClicked(object obj)
        {
            Navigation.PushAsync(new LovePage(user, user, true));
        }

        private void OnLettersClicked(object obj)
        {
            Navigation.PushAsync(new LettersOfUserPage(user, user, true));
        }

        private void OnSearchClicked(object obj)
        {
            Navigation.PushAsync(new SearchPage(user));
        }
    }
}
