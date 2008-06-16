using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ThuePhong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.BeginInvoke();
            comboBox1.BeginUpdate();
            comboBox1.Text = "dsf";
            comboBox1.EndUpdate();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}