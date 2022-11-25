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
    public class LetterList : INotifyPropertyChanged
    {
        private List<Letter> letters;

        public LetterList()
        {

        }

        public List<Letter> Letters
        {
            get { return letters; }
        }

        public void GetLetters()
        {
            letters = new List<Letter>();
            string jsonString = GetJSON();
            var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonString);
            var u = jsonObject["Letters"];
            foreach (var x in u)
                letters.Add(x.ToObject<Letter>());
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
