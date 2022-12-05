using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;
using App1.ModelsForDB;

namespace App1.ViewModels
{
    class FollowerWithSerialsViewModel : BaseViewModel
    {
        public Command FollowingCommand { get; }
        public Command FollowersCommand { get; }
        public Command FilmsCommand { get; }
        public Command MarksCommand { get; }
        public Command WatchlistCommand { get; }
        public Command LoveCommand { get; }
        public Command LettersCommand { get; }
        public Command SearchCommand { get; }
        public Command BackCommand { get; }
        public Command ClickCommand { get; }

        private User selectedUser;

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

        public FollowerWithSerialsViewModel(User u, User myuser)
        {
            selectedUser = u;
            User = myuser;
            BackCommand = new Command(OnBackClicked);
            ClickCommand = new Command(OnButtonClicked);
            FollowingCommand = new Command(OnFollowingClicked);
            FollowersCommand = new Command(OnFollowersClicked);
            FilmsCommand = new Command(OnFilmsClicked);
            MarksCommand = new Command(OnMarksClicked);
            WatchlistCommand = new Command(OnWatchlistClicked);
            LoveCommand = new Command(OnLoveClicked);
            LettersCommand = new Command(OnLettersClicked);
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

        private void OnBackClicked(object obj) //стрелка назад
        {
            Navigation.PopAsync();
        }

        private void OnFollowingClicked(object obj)
        {
            Navigation.PushAsync(new FollowingPage(User, SelectedUser));
        }

        private void OnFollowersClicked(object obj)
        {
            Navigation.PushAsync(new FollowersPage(User, SelectedUser));
        }

        private void OnFilmsClicked(object obj)
        {
            Navigation.PushAsync(new FollowerPage(selectedUser, user));
        }

        private void OnMarksClicked(object obj)
        {
            Navigation.PushAsync(new MarksPage(user, selectedUser, true));
        }

        private void OnWatchlistClicked(object obj)
        {
            Navigation.PushAsync(new WatchlistPage(user, selectedUser, true));
        }

        private void OnLoveClicked(object obj)
        {
            Navigation.PushAsync(new LovePage(user, selectedUser, true));
        }

        private void OnLettersClicked(object obj)
        {
            Navigation.PushAsync(new LettersOfUserPage(user, selectedUser, true));
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
