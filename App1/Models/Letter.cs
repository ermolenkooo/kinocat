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
    public class Letter : INotifyPropertyChanged
    {
        int id;
        int id_film;
        int id_user;
        int plus;
        int minus;
        string text;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

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

        public int Plus
        {
            get { return plus; }
            set
            {
                plus = value;
                OnPropertyChanged("Plus");
            }
        }

        public int Minus
        {
            get { return minus; }
            set
            {
                minus = value;
                OnPropertyChanged("Minus");
            }
        }

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged("Text");
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
