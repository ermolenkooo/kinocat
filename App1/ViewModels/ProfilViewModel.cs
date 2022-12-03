using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;
using App1.ModelsForDB;

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

        public ProfilViewModel(User u)
        {
            User = u;
            List<FollowerDB> followers = new List<FollowerDB>();
            List<FollowerDB> following = new List<FollowerDB>();
            var follow = App.Database.GetFollowers();
            foreach (var f in follow) 
            {
                if (f.Id_following == User.Id)
                    followers.Add(f);
            }
            foreach (var f in follow)
            {
                if (f.Id_follower == User.Id)
                    following.Add(f);
            }
            User.countOfFollowers = followers.Count;
            User.countOfFollowing = following.Count;
            FollowingCommand = new Command(OnFollowingClicked);
            FollowersCommand = new Command(OnFollowersClicked);
            SerialsCommand = new Command(OnSerialsClicked);
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

        private void OnSerialsClicked(object obj)
        {
            Navigation.PushAsync(new ProfilWithSerials(user));
        }

        private void OnMarksClicked(object obj)
        {
            Navigation.PushAsync(new MarksPage(user, user, false));
        }

        private void OnWatchlistClicked(object obj)
        {
            Navigation.PushAsync(new WatchlistPage(user, user, false));
        }

        private void OnLoveClicked(object obj)
        {
            Navigation.PushAsync(new LovePage(user, user, false));
        }

        private void OnLettersClicked(object obj)
        {
            Navigation.PushAsync(new LettersOfUserPage(user, user, false));
        }

        private void OnSearchClicked(object obj)
        {
            Navigation.PushAsync(new SearchPage(user));
        }
    }
}
