using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PhanTichDacTaHam;
namespace InputFunctionGeneration
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
            FunctionSpecification fs = new FunctionSpecification(txtText.Text);
            txtResult.Text = fs.GenerateInputFunction();
        }
    }
}