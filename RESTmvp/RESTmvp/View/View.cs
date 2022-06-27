using MaterialSkin.Controls;
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
//using Newtonsoft.Json.Linq;
//using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Net;
using System.Reflection;
using static System.Text.Encoding;
using static System.Char;
using Newtonsoft.Json;


namespace RESTmvp
{
    public partial class View : MaterialForm
    {
        private Presenter _presenter;
        public View()
        {
            InitializeComponent();
            _presenter = new Presenter();
        }

        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                List<string> ListOfObjects = _presenter.GetCountryData(textBox1.Text);
                listBox1.DataSource = ListOfObjects;
                label2.Text = _presenter.GetCount(ListOfObjects);
                label2.Visible = true;

            }
        }

    }
}
