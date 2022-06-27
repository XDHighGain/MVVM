using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Net;
using System.Reflection;
using static System.Text.Encoding;
using static System.Char;
namespace Rest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("France");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            Popo();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            Parser();
        }

        public void Parser()
        {

            PropertyInfo[] property;
            List<string> allObjects = new List<string>();
            property = typeof(Uni).GetProperties();
            string currentProperty = property[3].Name;

            if (comboBox1.Text == "")
            {
                label3.Visible = true;
                label3.Text = "No result. Choose country";
            }
            else
            {
                string jsonString = new WebClient().DownloadString("http://universities.hipolabs.com/search?country=" + comboBox1.Text);

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
                listBox1.DataSource = allObjects;


            }
        }

        public async Task Popo()
        {
            if (comboBox1.Text == "")
            {
                label3.Visible = true;
                label3.Text = "No result. Choose country";
            }
            else
            {
                label3.Visible = false;
                listBox1.Items.Clear();
                string json = new WebClient().DownloadString("http://universities.hipolabs.com/search?country=" + comboBox1.Text);
                var machine = JsonConvert.DeserializeObject<List<Uni>>(json);

                if (machine.Count == 0)
                {
                    label3.Visible = true;
                    label3.Text = "No result. Check spelling";
                }
                else
                {
                    foreach (var data in machine)
                    {
                        Console.WriteLine(data.name);
                        listBox1.Items.Add(data.name);
                    }
                }
            }


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






