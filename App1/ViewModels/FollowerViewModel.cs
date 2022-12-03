using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;

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

        public INavigation Navigation { get; set; }

        public FollowerViewModel(User u)
        {
            selectedUser = u;
            BackCommand = new Command(OnBackClicked);
            ClickCommand = new Command(OnButtonClicked);
            FollowingCommand = new Command(OnFollowingClicked);
            FollowersCommand = new Command(OnFollowersClicked);
            SerialsCommand = new Command(OnSerialsClicked);
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

        private void OnFollowingClicked(object obj)
        {
            //Navigation.PushAsync(new FollowingPage());
        }

        private void OnFollowersClicked(object obj)
        {
            //Navigation.PushAsync(new FollowersPage());
        }

        private void OnSerialsClicked(object obj)
        {
            //Navigation.PushAsync(new ProfilWithSerials());
        }

        private void OnMarksClicked(object obj)
        {
            //Navigation.PushAsync(new MarksPage(selectedUser));
        }

        private void OnWatchlistClicked(object obj)
        {
            //Navigation.PushAsync(new WatchlistPage(selectedUser));
        }

        private void OnLoveClicked(object obj)
        {
            //Navigation.PushAsync(new LovePage(selectedUser));
        }

        private void OnLettersClicked(object obj)
        {
            //Navigation.PushAsync(new LettersOfUserPage(selectedUser));
        }

        private void OnBackClicked(object obj) //стрелка назад
        {
            Navigation.PopAsync();
        }

        private void OnButtonClicked(object obj) //клик на кнопку отписаться/подписаться - что-то меняем в бд
        {
            if (selectedUser.ReadMe == true)
                selectedUser.ReadMe = false;
            else selectedUser.ReadMe = true;
        }
    }
}
