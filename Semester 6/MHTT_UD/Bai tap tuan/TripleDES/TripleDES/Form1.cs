using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TripleDES
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

        private void butBrowseInput_Click(object sender, EventArgs e)
        {
             if (openFileDialog1.ShowDialog() == DialogResult.OK)
             {
                 txtInput.Text = openFileDialog1.FileName;
             }
        }

        private void butBrowseOutput_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtOutput.Text = saveFileDialog1.FileName;
            }
        }

        private void butEncrypt_Click(object sender, EventArgs e)
        {
            String strInput = txtInput.Text.Trim();
            String strOutput = txtOutput.Text.Trim();
            String strPassword = txtPassword.Text;
            int iKeySize = (rB128.Checked == true) ? 128 : 192;

            if (strPassword.Length * 8 != iKeySize)
            {
                MessageBox.Show("Chiều dài của mật khẩu phải là " + string.Format("{0}", iKeySize / 8));
                return;
            }

            try
            {
                CTripleDES.EcryptFile(strInput, strOutput, strPassword, iKeySize);
                MessageBox.Show("Mã hóa thành công");
            }
            catch (System.Exception e1)
            {
                MessageBox.Show("Lỗi: \n" + e1.Message);
            }            
        }

        private void butDecrypt_Click(object sender, EventArgs e)
        {
            String strInput = txtInput.Text.Trim();
            String strOutput = txtOutput.Text.Trim();
            String strPassword = txtPassword.Text;
            int iKeySize = (rB128.Checked == true) ? 128 : 192;

            if (strPassword.Length * 8 != iKeySize)
            {
                MessageBox.Show("Chiều dài của mật khẩu phải là " + string.Format("{0}", iKeySize / 8));
                return;
            }

            try
            {
                CTripleDES.DecryptFile(strInput, strOutput, strPassword, iKeySize);
                MessageBox.Show("Giải mã thành công");
            }
            catch (System.Exception e1)
            {
                MessageBox.Show("Lỗi: \n" + e1.Message);
            }
            
        }

        private void rB128_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtPassword.MaxLength = 16;
        }

        private void rb192_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtPassword.MaxLength = 24;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}