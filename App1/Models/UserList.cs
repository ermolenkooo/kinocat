using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace App1.Models
{
    public class UserList : INotifyPropertyChanged
    {
        private List<User> users;

        public UserList()
        {

        }

        public List<User> Users
        {
            get { return users; }
        }

        public void GetUsers()
        {
            users = new List<User>();
            string jsonString = GetJSON();
            var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonString);
            var u = jsonObject["Users"];
            foreach (var x in u)
                users.Add(x.ToObject<User>());
        }

        public void GetFollowers()
        {
            users = new List<User>();
            string jsonString = GetJSON();
            var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonString);
            var u = jsonObject["Followers"];
            foreach (var x in u)
                users.Add(x.ToObject<User>());
        }

        public void GetFollowing()
        {
            users = new List<User>();
            string jsonString = GetJSON();
            var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonString);
            var u = jsonObject["Following"];
            foreach (var x in u)
                users.Add(x.ToObject<User>());
        }

        public string GetJSON()
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json");
            string json = (File.Exists(path)) ? File.ReadAllText(path) : "";
            return json;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
