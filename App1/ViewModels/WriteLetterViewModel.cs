using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;
using System.Collections.ObjectModel;

namespace App1.ViewModels
{
    class WriteLetterViewModel : BaseViewModel
    {
        public Command BackCommand { get; }
        public Command CreateCommand { get; }

        private Film selectedFilm;
        private User selectedUser;
        private string text;

        public INavigation Navigation { get; set; }

        public WriteLetterViewModel(User u, Film f)
        {
            selectedUser = u;
            selectedFilm = f;
            BackCommand = new Command(OnBackClicked);
            CreateCommand = new Command(OnButtonClicked);
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

        public Film SelectedFilm
        {
            get { return selectedFilm; }
            set
            {
                if (selectedFilm != value)
                {
                    selectedFilm = value;
                    OnPropertyChanged("SelectedLetter");
                }
            }
        }

        public string Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged("Text");
                }
            }
        }

        private void OnBackClicked(object obj) //стрелка назад
        {
            Navigation.PopAsync();
        }

        private void OnButtonClicked(object obj) //публикуем рецензию
        {
            App.Database.SaveLetter(new ModelsForDB.LetterDB { Id_film = selectedFilm.Id, Id_user = selectedUser.Id, Text = Text });
            Navigation.PushAsync(new FilmPage(selectedFilm, SelectedUser));
        }
    }
}
