using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;

namespace App1.ViewModels
{
    public class ProfilViewModel : BaseViewModel
    {
        public Command FollowingCommand { get; }
        public Command FollowersCommand { get; }
        public Command SerialsCommand { get; }
        public Command MarksCommand { get; }
        public Command WatchlistCommand { get; }
        public Command LoveCommand { get; }
        public Command LettersCommand { get; }
        public Command SearchCommand { get; }

        //user

        public INavigation Navigation { get; set; }

        User user;

        public ProfilViewModel()
        {
            FollowingCommand = new Command(OnFollowingClicked);
            FollowersCommand = new Command(OnFollowersClicked);
            SerialsCommand = new Command(OnSerialsClicked);
            MarksCommand = new Command(OnMarksClicked);
            WatchlistCommand = new Command(OnWatchlistClicked);
            LoveCommand = new Command(OnLoveClicked);
            LettersCommand = new Command(OnLettersClicked);
            SearchCommand = new Command(OnSearchClicked);
            user = new User();
            user.Id = 0;
            user.Image = "binosh.png";
            user.Username = "хэми";
        }

        private void OnFollowingClicked(object obj)
        {
            Navigation.PushAsync(new FollowingPage());
        }

        private void OnFollowersClicked(object obj)
        {
            Navigation.PushAsync(new FollowersPage());
        }

        private void OnSerialsClicked(object obj)
        {
            Navigation.PushAsync(new ProfilWithSerials());
        }

        private void OnMarksClicked(object obj)
        {
            Navigation.PushAsync(new MarksPage(user));
        }

        private void OnWatchlistClicked(object obj)
        {
            Navigation.PushAsync(new WatchlistPage(user));
        }

        private void OnLoveClicked(object obj)
        {
            Navigation.PushAsync(new LovePage(user));
        }

        private void OnLettersClicked(object obj)
        {
            Navigation.PushAsync(new LettersOfUserPage(user));
        }

        private void OnSearchClicked(object obj)
        {
            Navigation.PushAsync(new SearchPage(user));
        }
    }
}
