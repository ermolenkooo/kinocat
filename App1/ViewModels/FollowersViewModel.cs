using App1.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using App1.Models;
using System.Collections.ObjectModel;

namespace App1.ViewModels
{
    public class FollowersViewModel : BaseViewModel
    {
        public Command BackCommand { get; }
        public Command ClickCommand { get; }

        private User selectedUser;
        private UserList userList = new UserList();
        private ObservableCollection<User> followers;

        public INavigation Navigation { get; set; }

        public FollowersViewModel()
        {
            BackCommand = new Command(OnBackClicked);
            ClickCommand = new Command(OnButtonClicked);
            followers = new ObservableCollection<User>();
            userList.GetFollowers();
            foreach (User u in userList.Users)
            {
                Followers.Add(new User() { Id = u.Id, Username = u.Username, Image = u.Image, ReadMe = u.ReadMe, CountOfFollowing = u.CountOfFollowing, CountOfFollowers = u.CountOfFollowers });
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
        public ObservableCollection<User> Followers
        {
            get { return followers; }
            set
            {
                if (followers != value)
                {
                    followers = value;
                    OnPropertyChanged("Followers");
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
            foreach (User u in followers)
            {
                if (u.Id == (int)obj)
                {
                    f = u;
                    break;
                }
            }
            var ind = followers.IndexOf(f);
            if (followers[ind].ReadMe == true)
                followers[ind].ReadMe = false;
            else followers[ind].ReadMe = true;
        }
    }
}
