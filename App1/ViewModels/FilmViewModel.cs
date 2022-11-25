﻿using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;
using System.Collections.ObjectModel;

namespace App1.ViewModels
{
    class FilmViewModel : BaseViewModel
    {
        public Command BackCommand { get; }
        public Command ClickCommand { get; }
        public Command LoveCommand { get; }
        public Command WantCommand { get; }
        public Command LetterCommand { get; }
        public Command Star1Command { get; }
        public Command Star2Command { get; }
        public Command Star3Command { get; }
        public Command Star4Command { get; }
        public Command Star5Command { get; }

        private Film selectedFilm;
        private User selectedUser;
        private ObservableCollection<Mark> marks;
        private bool isLove;
        private bool isWant;
        private bool isLetter;
        private bool star1;
        private bool star2;
        private bool star3;
        private bool star4;
        private bool star5;

        public INavigation Navigation { get; set; }

        public FilmViewModel(Film f, User u)
        {
            marks = new ObservableCollection<Mark>();
            selectedUser = u;
            selectedFilm = f;
            BackCommand = new Command(OnBackClicked);
            LoveCommand = new Command(OnLoveClicked);
            WantCommand = new Command(OnWantClicked);
            LetterCommand = new Command(OnLetterClicked);
            ClickCommand = new Command(OnClicked);
            Star1Command = new Command(OnStar1Clicked);
            Star2Command = new Command(OnStar2Clicked);
            Star3Command = new Command(OnStar3Clicked);
            Star4Command = new Command(OnStar4Clicked);
            Star5Command = new Command(OnStar5Clicked);

            MarkOfUserList marksf = new MarkOfUserList();
            marksf.GetMarks();
            UserList users = new UserList();
            users.GetFollowing();
            var n = marksf.Marks.Find(x => x.Id_user == selectedUser.Id && x.Id_film == selectedFilm.Id);
            if (n == null)
                selectedFilm.Mark = 0;
            else
                selectedFilm.Mark = n.Mark;

            var mymarks = marksf.Marks.FindAll(x => x.Id_film == selectedFilm.Id);
            foreach(var m in mymarks)
            {
                foreach(var us in users.Users)
                {
                    if (m.Id_user == us.Id)
                        marks.Add(new Mark { M = m.Mark, Image = us.Image });
                }
            }

            LoveList loves = new LoveList();
            loves.GetLoves();
            WatchList watch = new WatchList();
            watch.GetWatches();
            LetterList letters = new LetterList();
            letters.GetLetters();

            if (loves.Loves.Find(x => x.Id_film == selectedFilm.Id && x.Id_user == selectedUser.Id) != null)
                IsLove = true;
            else
                IsLove = false;

            if (watch.Watches.Find(x => x.Id_film == selectedFilm.Id && x.Id_user == selectedUser.Id) != null)
                IsWant = true;
            else
                IsWant = false;

            if (letters.Letters.Find(x => x.Id_film == selectedFilm.Id && x.Id_user == selectedUser.Id) != null)
                IsLetter = true;
            else
                IsLetter = false;

            if (selectedFilm.Mark == 0) 
            {
                star1 = false;
                star2 = false;
                star3 = false;
                star4 = false;
                star5 = false;
            }
            if (selectedFilm.Mark == 1)
            {
                star1 = true;
                star2 = false;
                star3 = false;
                star4 = false;
                star5 = false;
            }
            if (selectedFilm.Mark == 2)
            {
                star1 = true;
                star2 = true;
                star3 = false;
                star4 = false;
                star5 = false;
            }
            if (selectedFilm.Mark == 3)
            {
                star1 = true;
                star2 = true;
                star3 = true;
                star4 = false;
                star5 = false;
            }
            if (selectedFilm.Mark == 4)
            {
                star1 = true;
                star2 = true;
                star3 = true;
                star4 = true;
                star5 = false;
            }
            if (selectedFilm.Mark == 5)
            {
                star1 = true;
                star2 = true;
                star3 = true;
                star4 = true;
                star5 = true;
            }
        }

        public ObservableCollection<Mark> Marks
        {
            get { return marks; }
            set
            {
                if (marks != value)
                {
                    marks = value;
                    OnPropertyChanged("Marks");
                }
            }
        }

        public User SelectedUser
        {
            get { return selectedUser; }
            set
            {
                if (selectedUser != value)
                {
                    User tempUser = value;
                    selectedUser = null;
                    OnPropertyChanged("SelectedUser");
                    Navigation.PushAsync(new FollowerPage(tempUser));
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
                    OnPropertyChanged("SelectedFilm");
                }
            }
        }

        public bool IsLove
        {
            get { return isLove; }
            set
            {
                if (isLove != value)
                {
                    isLove = value;
                    OnPropertyChanged("IsLove");
                }
            }
        }

        public bool IsWant
        {
            get { return isWant; }
            set
            {
                if (isWant != value)
                {
                    isWant = value;
                    OnPropertyChanged("IsWant");
                }
            }
        }

        public bool IsLetter
        {
            get { return isLetter; }
            set
            {
                if (isLetter != value)
                {
                    isLetter = value;
                    OnPropertyChanged("IsLetter");
                }
            }
        }

        public bool Star1
        {
            get { return star1; }
            set
            {
                if (star1 != value)
                {
                    star1 = value;
                    OnPropertyChanged("Star1");
                }
            }
        }

        public bool Star2
        {
            get { return star2; }
            set
            {
                if (star2 != value)
                {
                    star2 = value;
                    OnPropertyChanged("Star2");
                }
            }
        }

        public bool Star3
        {
            get { return star3; }
            set
            {
                if (star3 != value)
                {
                    star3 = value;
                    OnPropertyChanged("Star3");
                }
            }
        }

        public bool Star4
        {
            get { return star4; }
            set
            {
                if (star4 != value)
                {
                    star4 = value;
                    OnPropertyChanged("Star4");
                }
            }
        }

        public bool Star5
        {
            get { return star5; }
            set
            {
                if (star5 != value)
                {
                    star5 = value;
                    OnPropertyChanged("Star5");
                }
            }
        }

        private void OnBackClicked(object obj) //стрелка назад
        {
            Navigation.PopAsync();
        }

        private void OnLoveClicked(object obj) 
        {
            if (IsLove == true)
            {
                IsLove = false;
            }
            else
            {
                IsLove = true;
                /*LoveList love = new LoveList();
                love.GetLoves();
                love.AddLove(new Love { Id = love.Loves.Count, Id_film = selectedFilm.Id, Id_user = selectedUser.Id });*/
            }
        }

        private void OnWantClicked(object obj)
        {
            if (IsWant == true)
                IsWant = false;
            else IsWant = true;
        }

        private void OnLetterClicked(object obj) //написать рецензию
        {
            Navigation.PushAsync(new WriteLetterPage(SelectedUser, SelectedFilm));
        }

        private void OnClicked(object obj) //рецензии
        {
            Navigation.PushAsync(new LettersOfFilmPage(SelectedUser, SelectedFilm));
        }

        private void OnStar1Clicked(object obj)
        {
            Star1 = true;
            Star2 = false;
            Star3 = false;
            Star4 = false;
            Star5 = false;
        }

        private void OnStar2Clicked(object obj)
        {
            Star1 = true;
            Star2 = true;
            Star3 = false;
            Star4 = false;
            Star5 = false;
        }

        private void OnStar3Clicked(object obj)
        {
            Star1 = true;
            Star2 = true;
            Star3 = true;
            Star4 = false;
            Star5 = false;
        }

        private void OnStar4Clicked(object obj)
        {
            Star1 = true;
            Star2 = true;
            Star3 = true;
            Star4 = true;
            Star5 = false;
        }

        private void OnStar5Clicked(object obj)
        {
            Star1 = true;
            Star2 = true;
            Star3 = true;
            Star4 = true;
            Star5 = true;
        }
    }
}
