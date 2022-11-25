using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class RegViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegCommand { get; }

        private string username;
        private string email;
        private string password;

        public INavigation Navigation { get; set; }

        public RegViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegCommand = new Command(OnRegClicked);
        }

        public string Username
        {
            get { return username; }
            set
            {
                if (username != value)
                {
                    username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        private void OnLoginClicked(object obj)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void OnRegClicked(object obj)
        {
            Navigation.PushAsync(new ProfilPage());
        }
    }
}
