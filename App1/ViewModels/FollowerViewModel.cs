using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;
using App1.ModelsForDB;

namespace App1.ViewModels
{
    class FollowerViewModel : BaseViewModel
    {
        public Command FollowingCommand { get; }
        public Command FollowersCommand { get; }
        public Command SerialsCommand { get; }
        public Command MarksCommand { get; }
        public Command WatchlistCommand { get; }
        public Command LoveCommand { get; }
        public Command LettersCommand { get; }
        public Command BackCommand { get; }
        public Command ClickCommand { get; }

        private User selectedUser;

        public User User { get; set; }

        public INavigation Navigation { get; set; }

        public FollowerViewModel(User u, User myuser)
        {
            selectedUser = u;
            User = myuser;
            BackCommand = new Command(OnBackClicked);
            ClickCommand = new Command(OnButtonClicked);
            FollowingCommand = new Command(OnFollowingClicked);
            FollowersCommand = new Command(OnFollowersClicked);
            SerialsCommand = new Command(OnSerialsClicked);
            MarksCommand = new Command(OnMarksClicked);
            WatchlistCommand = new Command(OnWatchlistClicked);
            LoveCommand = new Command(OnLoveClicked);
            LettersCommand = new Command(OnLettersClicked);

            List<FollowerDB> followers = new List<FollowerDB>();
            List<FollowerDB> following = new List<FollowerDB>();
            var follow = App.Database.GetFollowers();
            foreach (var f in follow)
            {
                if (f.Id_following == u.Id)
                    followers.Add(f);
            }
            foreach (var f in follow)
            {
                if (f.Id_follower == u.Id)
                    following.Add(f);
            }
            selectedUser.countOfFollowers = followers.Count;
            selectedUser.countOfFollowing = following.Count;
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

        private void OnFollowingClicked(object obj)
        {
            Navigation.PushAsync(new FollowingPage(User, selectedUser));
        }

        private void OnFollowersClicked(object obj)
        {
            Navigation.PushAsync(new FollowersPage(User, selectedUser));
        }

        private void OnSerialsClicked(object obj)
        {
            Navigation.PushAsync(new FollowerWithSerialsPage(selectedUser, User));
        }

        private void OnMarksClicked(object obj)
        {
            Navigation.PushAsync(new MarksPage(User, selectedUser, false));
        }

        private void OnWatchlistClicked(object obj)
        {
            Navigation.PushAsync(new WatchlistPage(User, selectedUser, false));
        }

        private void OnLoveClicked(object obj)
        {
            Navigation.PushAsync(new LovePage(User, selectedUser, false));
        }

        private void OnLettersClicked(object obj)
        {
            Navigation.PushAsync(new LettersOfUserPage(User, selectedUser, false));
        }

        private void OnBackClicked(object obj) //стрелка назад
        {
            Navigation.PopAsync();
        }

        private void OnButtonClicked(object obj) //клик на кнопку отписаться/подписаться - что-то меняем в бд
        {
            var f = App.Database.GetFollowers().Find(x => x.Id_follower == User.Id && x.Id_following == selectedUser.Id);
            if (selectedUser.ReadMe == true)
            {
                selectedUser.ReadMe = false;
                selectedUser.CountOfFollowers--;
                App.Database.DeleteFollower(f.Id);
            }
            else
            {
                selectedUser.ReadMe = true;
                selectedUser.CountOfFollowers++;
                App.Database.SaveFollower(new ModelsForDB.FollowerDB { Id_follower = User.Id, Id_following = selectedUser.Id });
            }
        }
    }
}
