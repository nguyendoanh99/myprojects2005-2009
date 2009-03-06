using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PhanTichDacTaHam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = txtText.Text;
            FunctionSpecification fs = new FunctionSpecification(str);
            lblFunctionName.Text = fs.Name;
            lsvParameters.Items.Clear();
            for (int i = 0;i < fs.Parameters.Count; ++i)
            {
                ListViewItem lvi = new ListViewItem(new string[] { fs.Parameters[i].Name, fs.Parameters[i].Type });
                lsvParameters.Items.Add(lvi);
            }

            lblResultName.Text = fs.Result.Name;
            lblResultType.Text = fs.Result.Type;
        }
    }
}