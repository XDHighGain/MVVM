using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NameList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.DataSource = namesList;
        }

        string newName;
        List<string> namesList = new List<string> { "Вася", "Петя", "Жак", "Ян", "Евгений" };


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            newName = comboBox1.Text;
            if (newName != "")
            {
                namesList.Add(newName);
                listBox1.DataSource = null;
                namesList.Sort();
                listBox1.DataSource = namesList;
            }

        }

    }
}
