using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FTPClient
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            Program.strInput = txtInput.Text;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void SetlblCaption(string str)
        {
            lblCaption.Text = str;
        }
    }
}