using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Essentials;
using App1.ModelsForDB;
using App1.Models;

namespace App1.ViewModels
{
    public class RegViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegCommand { get; }
        public Command FileCommand { get; }

        private string username;
        private string email;
        private string password;
        private string file;
        private string warning;

        public INavigation Navigation { get; set; }

        public RegViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegCommand = new Command(OnRegClicked);
            FileCommand = new Command(OnFileClicked);
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

        public string File
        {
            get { return file; }
            set
            {
                if (file != value)
                {
                    file = value;
                    OnPropertyChanged("File");
                }
            }
        }

        public string Warning
        {
            get { return warning; }
            set
            {
                if (warning != value)
                {
                    warning = value;
                    OnPropertyChanged("Warning");
                }
            }
        }

        private void OnLoginClicked(object obj)
        {
            Navigation.PushAsync(new LoginPage());
        }

        private void OnRegClicked(object obj)
        {
            var users = App.Database.GetUsers();
            foreach(var u in users)
            {
                if (Email == null || Username == null || Password == null)
                {
                    Warning = "Заполните все поля!";
                    return;
                }
                else if (Email == u.Email)
                {
                    Warning = "На данный e-mail уже зарегистрирован аккаунт!";
                    return;
                }
                else if (Username == u.Username) 
                {
                    Warning = "Данное имя пользователя уже используется!";
                    return;
                }
            }
            UserDB userdb = new UserDB { Email = Email, Password = Password, Username = Username, Image = File };
            App.Database.SaveUser(userdb);
            users = App.Database.GetUsers(); 
            foreach (var u in users)
            {
                if (u.Username == Username)
                {
                    User user = new User { Email = Email, Password = Password, Username = Username, Image = File, Id = u.Id };
                    Navigation.PushAsync(new ProfilPage(user));
                    break;
                }
            }
        }

        private async void OnFileClicked(object obj) ////////////////////////////////
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Выберите фото профиля!"
            });

            File = result.FileName;
        }
    }
}
