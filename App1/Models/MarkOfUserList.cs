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
    public class MarkOfUserList : INotifyPropertyChanged
    {
        private List<MarkOfUser> marks;

        public MarkOfUserList()
        {

        }

        public List<MarkOfUser> Marks
        {
            get { return marks; }
        }

        public void GetMarks()
        {
            marks = new List<MarkOfUser>();
            string jsonString = GetJSON();
            var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonString);
            var u = jsonObject["Marks"];
            foreach (var x in u)
                marks.Add(x.ToObject<MarkOfUser>());
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
