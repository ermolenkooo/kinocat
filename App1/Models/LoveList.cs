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
    class LoveList
    {
        private List<Love> loves;

        public LoveList()
        {

        }

        public List<Love> Loves
        {
            get { return loves; }
        }

        public void GetLoves()
        {
            loves = new List<Love>();
            string jsonString = GetJSON();
            var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonString);
            var u = jsonObject["Love"];
            foreach (var x in u)
                loves.Add(x.ToObject<Love>());
        }

        public void AddLove(Love l)
        {
            /*string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json");
            string jsonString = (File.Exists(path)) ? File.ReadAllText(path) : "";
            var jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(jsonString);
            //jsonObject["Love"].Add(l);
            //List<Love> myloves = new List<Love>(); 
            /*var u = jsonObject["Love"];
            foreach (var x in u)
                myloves.Add(x.ToObject<Love>());
            myloves.Add(l);*/
            /*jsonObject["Love"] = new 
            //Newtonsoft.Json.Linq.JArray array = new Newtonsoft.Json.Linq.JArray();
            //jsonObject["Love"] = myloves;
            jsonObject = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObject);
            File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "json.json"), jsonObject);*/
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
