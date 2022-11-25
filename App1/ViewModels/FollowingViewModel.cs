﻿using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;
using System.Collections.ObjectModel;

namespace App1.ViewModels
{
    public class FollowingViewModel : BaseViewModel
    {
        public Command BackCommand { get; }
        public Command ClickCommand { get; }

        private User selectedUser;
        private UserList userList = new UserList();
        private ObservableCollection<User> following;

        public INavigation Navigation { get; set; }

        public FollowingViewModel()
        {
            BackCommand = new Command(OnBackClicked);
            ClickCommand = new Command(OnButtonClicked);
            following = new ObservableCollection<User>();
            userList.GetFollowing();
            foreach (User u in userList.Users)
            {
                Following.Add(new User() { Id = u.Id, Username = u.Username, Image = u.Image, ReadMe = u.ReadMe, CountOfFollowing = u.CountOfFollowing, CountOfFollowers = u.CountOfFollowers });
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
        public ObservableCollection<User> Following
        {
            get { return following; }
            set
            {
                if (following != value)
                {
                    following = value;
                    OnPropertyChanged("Following");
                }
            }
        }

        private void OnBackClicked(object obj) //стрелка назад
        {
            Navigation.PopAsync();
        }

        private void OnButtonClicked(object obj) //клик на кнопку отписаться/подписаться - что-то меняем в бд
        {
            User f = new User();
            foreach(User u in following)
            {
                if (u.Id == (int)obj)
                {
                    f = u;
                    break;
                }
            }
            var ind = following.IndexOf(f);
            if (following[ind].ReadMe == true)
                following[ind].ReadMe = false;
            else following[ind].ReadMe = true;
        }
    }
}