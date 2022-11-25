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
    class WatchList
    {
        private List<WatchItem> watches;

        public WatchList()
        {

        }

        public List<WatchItem> Watches
        {
            get { return watches; }
        }

        public void GetWatches()
        {
            watches = new List<WatchItem>();
            string jsonString = GetJSON();
            var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonString);
            var u = jsonObject["Watchlist"];
            foreach (var x in u)
                watches.Add(x.ToObject<WatchItem>());
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
