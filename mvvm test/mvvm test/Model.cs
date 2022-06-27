using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_test
{
    class Model
    {
        public List<string> list = new List<string>();
        public int getSumm(int a, int b)
        {
            return a + b;
        }

        internal List<string> GetData(string country)
        {
            list.Clear();
            string json = new WebClient().DownloadString("http://universities.hipolabs.com/search?country=" + country);
            var machine = JsonConvert.DeserializeObject<List<Uni>>(json);
            foreach (var i in machine)
            {
                list.Add(i.name);
            }
            list.Sort();
            return list;
        }

        public class Uni
        {
            public List<string> domains { get; set; }
            public List<string> web_pages { get; set; }

            [JsonProperty("state-province")]
            public object StateProvince { get; set; }
            public string name { get; set; }
            public string country { get; set; }
            public string alpha_two_code { get; set; }
        }

    }
}
