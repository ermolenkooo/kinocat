using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace App1.Models
{
    public class User : INotifyPropertyChanged
    {
        public int id;
        public string username;
        public string image;
        public bool readMe;
        public int countOfFollowers;
        public int countOfFollowing;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                OnPropertyChanged("Username");
            }
        }

        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged("Image");
            }
        }

        public bool ReadMe
        {
            get { return readMe; }
            set
            {
                readMe = value;
                OnPropertyChanged("ReadMe");
            }
        }

        public int CountOfFollowers
        {
            get { return countOfFollowers; }
            set
            {
                countOfFollowers = value;
                OnPropertyChanged("CountOfFollowers");
            }
        }

        public int CountOfFollowing
        {
            get { return countOfFollowing; }
            set
            {
                countOfFollowing = value;
                OnPropertyChanged("CountOfFollowing");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
