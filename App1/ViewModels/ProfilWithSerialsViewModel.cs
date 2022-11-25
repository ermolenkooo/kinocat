using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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

        //user

        public INavigation Navigation { get; set; }

        public ProfilWithSerialsViewModel()
        {
            FollowingCommand = new Command(OnFollowingClicked);
            FollowersCommand = new Command(OnFollowersClicked);
            FilmsCommand = new Command(OnFilmsClicked);
            MarksCommand = new Command(OnMarksClicked);
            WatchlistCommand = new Command(OnWatchlistClicked);
            LoveCommand = new Command(OnLoveClicked);
            LettersCommand = new Command(OnLettersClicked);
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
            Navigation.PushAsync(new ProfilPage());
        }

        private void OnMarksClicked(object obj)
        {
            //Navigation.PushAsync(new LoginPage());
        }

        private void OnWatchlistClicked(object obj)
        {
            //Navigation.PushAsync(new LoginPage());
        }

        private void OnLoveClicked(object obj)
        {
            //Navigation.PushAsync(new LoginPage());
        }

        private void OnLettersClicked(object obj)
        {
            //Navigation.PushAsync(new LoginPage());
        }

    }
}
