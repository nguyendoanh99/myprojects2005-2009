using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FTPClient
{
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            Program.strHostname = txtHostName.Text;
            Program.strPassword = txtPassword.Text;
            Program.strUsername = txtUsername.Text;
        }
    }
}