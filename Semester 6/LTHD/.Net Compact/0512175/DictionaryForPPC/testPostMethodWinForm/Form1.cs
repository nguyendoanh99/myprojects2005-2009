using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;



namespace testPostMethodWinForm
{
    public partial class Form1 : Form
    {        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
//            CTranslator t = new CTranslator(textBox2.Text, "en|es");
            CTranslator t = new CTranslator(textBox2.Text, "en|zh-TW");
            
            textBox1.Text = t.Perform();
        }
    }
    
}