using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace TripleDESUpdate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

        private void butEncrypt_Click(object sender, EventArgs e)
        {
            String strInput = txtInput.Text.Trim();
            String strOutput = txtOutput.Text.Trim();
            String strPassword = txtPassword.Text;
            string strIV = txtIV.Text;
            PaddingMode PM = (PaddingMode) cmbPaddingMode.SelectedItem;
            CipherMode CM = (CipherMode) cmbModeofOperation.SelectedItem;
            int iKeySize = (rB128.Checked == true) ? 128 : 192;

            if (strPassword.Length * 8 != iKeySize)
            {
                MessageBox.Show("Chiều dài của mật khẩu phải là " + string.Format("{0}", iKeySize / 8));
                return;
            }

            if (strIV.Length != 8 && (CM != CipherMode.ECB))
            {
                MessageBox.Show("Chiều dài của IV phải là 8 ký tự.");
                txtIV.Select(0, strIV.Length);
                txtIV.Focus();
                return;
            }

            if (CM == CipherMode.ECB)
                strIV = "12345678";

            try
            {
                CTripleDES TDES = new CTripleDES(strPassword, iKeySize, strIV, PM, CM);
                TDES.EcryptFile(strInput, strOutput);
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
            string strIV = txtIV.Text;
            PaddingMode PM = (PaddingMode)cmbPaddingMode.SelectedItem;
            CipherMode CM = (CipherMode)cmbModeofOperation.SelectedItem;
            int iKeySize = (rB128.Checked == true) ? 128 : 192;

            if (strPassword.Length * 8 != iKeySize)
            {
                MessageBox.Show("Chiều dài của mật khẩu phải là " + string.Format("{0}", iKeySize / 8));
                return;
            }

            if (strIV.Length != 8 && (CM != CipherMode.ECB))
            {
                MessageBox.Show("Chiều dài của IV phải là 8 ký tự.");
                txtIV.Select(0, strIV.Length);
                txtIV.Focus();
                return;
            }

            if (CM == CipherMode.ECB)
                strIV = "12345678";

            try
            {
                CTripleDES TDES = new CTripleDES(strPassword, iKeySize, strIV, PM, CM);
                TDES.DecryptFile(strInput, strOutput);
                MessageBox.Show("Giải mã thành công");
            }
            catch (System.Exception e1)
            {
                MessageBox.Show("Lỗi: \n" + e1.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khoi tao cmbPaddingMode
            cmbPaddingMode.Items.Add(PaddingMode.ANSIX923);
            cmbPaddingMode.Items.Add(PaddingMode.ISO10126);
            cmbPaddingMode.Items.Add(PaddingMode.PKCS7);
            // Khoi tao cmbModeofOperation
            cmbModeofOperation.Items.Add(CipherMode.ECB);
            cmbModeofOperation.Items.Add(CipherMode.CBC);
            cmbModeofOperation.Items.Add(CipherMode.CFB);
            cmbModeofOperation.Items.Add(CipherMode.CTS);
            cmbModeofOperation.Items.Add(CipherMode.OFB);

            cmbPaddingMode.SelectedIndex = 0;
            cmbModeofOperation.SelectedIndex = 0;
        }

        private void cmbModeofOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;            
            CipherMode cm = (CipherMode) cmb.SelectedItem;
            if (cm == CipherMode.ECB)
            {
                txtIV.Enabled = false;
            }
            else
                txtIV.Enabled = true;
        }

        private void cmbPaddingMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}