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
    public class Film : INotifyPropertyChanged
    {
        int id;
        string name;
        string poster;
        int mark;
        string description;
        string year;
        string genre;
        string country;
        string age;
        string timing;
        string original;
        string seasons;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Poster
        {
            get { return poster; }
            set
            {
                poster = value;
                OnPropertyChanged("Poster");
            }
        }

        public string Seasons
        {
            get { return seasons; }
            set
            {
                seasons = value;
                OnPropertyChanged("Seasons");
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

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        public string Year
        {
            get { return year; }
            set
            {
                year = value;
                OnPropertyChanged("Year");
            }
        }

        public string Genre
        {
            get { return genre; }
            set
            {
                genre = value;
                OnPropertyChanged("Genre");
            }
        }

        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }

        public string Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        public string Timing
        {
            get { return timing; }
            set
            {
                timing = value;
                OnPropertyChanged("Timing");
            }
        }

        public string Original
        {
            get { return original; }
            set
            {
                original = value;
                OnPropertyChanged("Original");
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
