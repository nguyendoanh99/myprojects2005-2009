using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FunctionSpecificationLibrary;

namespace InputOutputFunctionGeneration
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

        private void button1_Click(object sender, EventArgs e)
        {
            FunctionSpecification fs = new FunctionSpecification(txtFunctionSpecification.Text);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(fs.GenerateInputFunction());
            sb.AppendLine(fs.GenerateOutputFunction());
            sb.AppendLine(fs.GenerateMainFunction());
            txtResult.Text = sb.ToString();
        }
    }
}