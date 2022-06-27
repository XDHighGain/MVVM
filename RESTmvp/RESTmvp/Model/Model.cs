using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Net;
//using System.Net;
//using System.Reflection;
//using static System.Text.Encoding;
//using static System.Char;
//using Newtonsoft.Json;

namespace RESTmvp
{
    public class Model
    {
        public List<string> GetListOfUni(string countryName)
        {
            PropertyInfo[] property;
            List<string> allObjects = new List<string>();
            property = typeof(Uni2).GetProperties();
            string currentProperty = property[3].Name;

            if (countryName == "")
            {
                //label2.Visible = true;
                //label2.Text = "No result. Choose country";
            }
            else
            {
                string jsonString = new WebClient().DownloadString("http://universities.hipolabs.com/search?country=" + countryName);

                string subString;
                string uniName;
                int count = Regex.Matches(jsonString, currentProperty).Count;
                int startPos = 0;
                int endPos = 0;
                int lenght;
                for (int i = 0; i < count; i++)
                {
                    lenght = jsonString.Length;
                    startPos = jsonString.IndexOf(currentProperty) + 8;
                    subString = jsonString.Substring(startPos, lenght - startPos);
                    endPos = subString.IndexOf("\"");
                    uniName = Regex.Unescape(subString.Substring(0, endPos));
                    // uniName = Regex.Unescape(uniName);                    
                    allObjects.Add(@uniName);
                    jsonString = subString;
                    startPos = 0;
                    endPos = 0;
                }
                allObjects.Sort();
                //listBox1.DataSource = allObjects;


            }
            return allObjects;
        }

        public string GetCount(List<string> listOfObjects)
        {
            string counter =  listOfObjects.Count().ToString();
            if ( counter == "0" )
            {
                return "Empty list, check spelling";
            }
            else
            {
                return "Count of universities:" + counter;
            }

        }

        public class Uni2
        {
            public List<string> domains { get; set; }
            public List<string> web_pages { get; set; }

            // [JsonProperty("state-province")]
            public object StateProvince { get; set; }
            public string name { get; set; }
            public string country { get; set; }
            public string alpha_two_code { get; set; }
        }

    }



}
