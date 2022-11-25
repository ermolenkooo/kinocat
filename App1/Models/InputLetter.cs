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
    public class InputLetter : INotifyPropertyChanged
    {
        public string username;
        public string image;
        public int mark;
        public int id_film;
        public int id_user;

        public int Id_film
        {
            get { return id_film; }
            set
            {
                id_film = value;
                OnPropertyChanged("Id_film");
            }
        }

        public int Id_user
        {
            get { return id_user; }
            set
            {
                id_user = value;
                OnPropertyChanged("Id_user");
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

        public int Mark
        {
            get { return mark; }
            set
            {
                mark = value;
                OnPropertyChanged("Mark");
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
