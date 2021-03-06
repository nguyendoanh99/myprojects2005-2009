using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace TaoDuLieuDictionary
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

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void butInput_Click(object sender, EventArgs e)
        {
             if (openFileDialog1.ShowDialog() == DialogResult.OK)
             {
                 string sz = openFileDialog1.FileName;
                 txtInput.Text = sz;
                 txtOutput.Text = sz.Substring(0, sz.Length - 4);
             }
        }

        private void butOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string sz = saveFileDialog1.FileName;
                txtOutput.Text = sz;
            }
        }

        private void butCreate_Click(object sender, EventArgs e)
        {
            try
            {
                CDictionary dic = new CDictionary();
                string szInput = txtInput.Text.Trim();
                string szOutput = txtOutput.Text.Trim();
                dic.ReadFile(szInput);
                dic.WriteFile(szOutput);
            }
            catch (System.Exception e1)
            {
                MessageBox.Show(e1.ToString());
                return;
            }
            MessageBox.Show("Dữ liệu từ điển được tạo thành công");
        }
    }
}