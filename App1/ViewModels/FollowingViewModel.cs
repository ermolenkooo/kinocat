using App1.Views;
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
        private ObservableCollection<User> following;

        public User User { get; set; }

        public INavigation Navigation { get; set; }

        public FollowingViewModel(User u, User selu)
        {
            selectedUser = selu;
            User = u;
            BackCommand = new Command(OnBackClicked);
            ClickCommand = new Command(OnButtonClicked);
            following = new ObservableCollection<User>();

            var follow = App.Database.GetFollowers().FindAll(x => x.Id_follower == selu.Id);

            foreach (var f in follow)
            {
                var user = App.Database.GetUser(f.Id_following);
                var k = App.Database.GetFollowers().Find(x => x.Id_follower == User.Id && x.Id_following == user.Id);
                if (k != null)
                    following.Add(new User { Id = user.Id, Image = user.Image, Username = user.Username, ReadMe = true });
                else
                    following.Add(new User { Id = user.Id, Image = user.Image, Username = user.Username, ReadMe = false });
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
                    if (tempUser.Id != User.Id)
                        Navigation.PushAsync(new FollowerPage(tempUser, User));
                    else
                        Navigation.PushAsync(new ProfilPage(User));
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
            var f = App.Database.GetFollowers().Find(x => x.Id_follower == User.Id && x.Id_following == (int)obj);
            if (f != null)
            {
                App.Database.DeleteFollower(f.Id);
                foreach (var follow in following)
                {
                    if (follow.Id == (int)obj)
                        follow.ReadMe = false;
                }
            }
            else
            {
                App.Database.SaveFollower(new ModelsForDB.FollowerDB { Id_follower = User.Id, Id_following = (int)obj });
                foreach (var follow in following)
                {
                    if (follow.Id == (int)obj)
                        follow.ReadMe = true;
                }
            }
        }
    }
}
