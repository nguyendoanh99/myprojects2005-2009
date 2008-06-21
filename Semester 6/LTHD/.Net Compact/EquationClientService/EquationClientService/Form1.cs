using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace EquationClientService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            localhost.Service t = new localhost.Service();            
            byte[] t1 = t.GiaiPT(0, 0, 0);
            string s = Encoding.ASCII.GetString(t1);
            Nghiem m = Nghiem.XMLtoNghiem(s);
        }
    }
}