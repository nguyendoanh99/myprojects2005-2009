using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace RSAApp
{
    public partial class Form1 : Form
    {
        void LuuFile(string szNoiDung, string szPath)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(szPath, FileMode.Create, FileAccess.Write);
                fs.Write(Encoding.ASCII.GetBytes(szNoiDung), 0, szNoiDung.Length);
                fs.Close();
            }

            catch (System.Exception e1)
            {
                if (fs != null)
                    fs.Close();
                throw;
            }
        }
        void Encrypt(string szPubKey, string szInput, string szOutput)
        {
            StreamReader sr = null;
            FileStream fsInput = null;
            FileStream fsOutput = null;
            try
            {
                fsInput = new FileStream(szInput, FileMode.Open, FileAccess.Read);
                fsOutput = new FileStream(szOutput, FileMode.Create, FileAccess.Write);
                sr = new StreamReader(szPubKey);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(sr.ReadToEnd());
                int max = (rsa.KeySize / 8) - 11;
                
                byte[] PlainText = new byte[max];
                byte[] EncryptData;
                /*
                
                fsInput.Read(PlainText, 0, PlainText.Length);
                EncryptData = rsa.Encrypt(PlainText, false);
                fsOutput.Write(EncryptData, 0, EncryptData.Length);
                */
                
                int count = 0;
                while ((count = fsInput.Read(PlainText, 0, max)) != 0)
                {
                    byte[] temp = null;
                    if (count == max)
                        temp = PlainText;
                    else
                    {
                        temp = new byte[count];
                        Array.Copy(PlainText, temp, count);
                    }
                    EncryptData = rsa.Encrypt(temp, false);
                    fsOutput.Write(EncryptData, 0, EncryptData.Length);    
                }                              

                fsInput.Close();
                fsOutput.Close();
                sr.Close();
            }
            catch (System.Exception e)
            {
                if (fsInput != null)
                    fsInput.Close();
                
                if (fsOutput != null)
                    fsOutput.Close();

                if (sr != null)
                    sr.Close();

                throw;
            }            
        }
        void Decrypt(string szPriKey, string szInput, string szOutput)
        {
            StreamReader sr = null;
            FileStream fsInput = null;
            FileStream fsOutput = null;
            try
            {
                fsInput = new FileStream(szInput, FileMode.Open, FileAccess.Read);
                fsOutput = new FileStream(szOutput, FileMode.Create, FileAccess.Write);
                sr = new StreamReader(szPriKey);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(sr.ReadToEnd());
                int max = rsa.KeySize / 8;

                byte[] EncryptData = new byte[max];
                byte[] PlainText;
                int count;

                while ((count = fsInput.Read(EncryptData, 0, max)) != 0)
                {
                    PlainText = rsa.Decrypt(EncryptData, false);
                    fsOutput.Write(PlainText, 0, PlainText.Length);
                }

                fsInput.Close();
                fsOutput.Close();
                sr.Close();
            }
            catch (System.Exception e)
            {
                if (fsInput != null)
                    fsInput.Close();

                if (fsOutput != null)
                    fsOutput.Close();

                if (sr != null)
                    sr.Close();

                throw;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 384; i <= 16384; i += 8)
                cmbKeySize.Items.Add(i.ToString() + " bit");
            cmbKeySize.SelectedIndex = 0;
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbKeySize.SelectedIndex == -1)
            {
                MessageBox.Show("Chiều dài khóa không thích hợp.");
                cmbKeySize.Select(0, cmbKeySize.Text.Length);
                cmbKeySize.Focus();
                return;
            }
            
            string szPubKey;
            string szPriKey;
            string szKeySize = cmbKeySize.Text.Replace(" bit", "");
            int iKeySize;
            iKeySize = int.Parse(szKeySize);

            txtPrivateKey.Text = txtPublicKey.Text = "";
            try
            {   
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(iKeySize);
                szPubKey = rsa.ToXmlString(false);
                szPriKey = rsa.ToXmlString(true);
            }
            catch (System.Exception e1)
            {
                MessageBox.Show(e1.ToString());
                return;
            }

            txtPrivateKey.Text = szPriKey;
            txtPublicKey.Text = szPubKey;
        }

        private void txtPublicKey_TextChanged(object sender, EventArgs e)
        {
            TextBox obj = (TextBox)sender;

            if (obj.Text == "")
                butSavePubKey.Enabled = false;
            else
                butSavePubKey.Enabled = true;
        }

        private void txtPrivateKey_TextChanged(object sender, EventArgs e)
        {
            TextBox obj = (TextBox)sender;

            if (obj.Text == "")
                butSavePriKey.Enabled = false;
            else
                butSavePriKey.Enabled = true;
        }

        private void butSavePubKey_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string szPath = saveFileDialog1.FileName;
                string szPubKey = txtPublicKey.Text;
                try
                {
                    LuuFile(szPubKey, szPath);
                }
                catch (System.Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                    return;
                }

                MessageBox.Show("Đã lưu thành công.");
            }
            
        }       

        private void butSavePriKey_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string szPath = saveFileDialog1.FileName;
                string szPriKey = txtPrivateKey.Text;
                try
                {
                    LuuFile(szPriKey, szPath);
                }
                catch (System.Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                    return;
                }

                MessageBox.Show("Đã lưu thành công.");
            }
        }

        private void txtEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox obj = (CheckBox)sender;
            if (obj.Checked == true) // Ma hoa
            {
                lblKey.Text = "Khóa công khai";
                butPerform.Text = "Mã hóa";
                groupBox2.Text = "Mã hóa";
            }
            else
            {
                lblKey.Text = "Khóa riêng";
                butPerform.Text = "Giải mã";
                groupBox2.Text = "Giải mã";
            }
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
                txtOutput.Text = saveFileDialog1.FileName;
        }

        private void butBrowseKey_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txtKey.Text = openFileDialog1.FileName;
        }

        private void butPerform_Click(object sender, EventArgs e)
        {
            String szKey = txtKey.Text;
            string szInput = txtInput.Text;
            string szOutput = txtOutput.Text;
            if (chkEncrypt.Checked == true) // Encrypt
            {
                try
                {
                    Encrypt(szKey, szInput, szOutput);
                }
                catch (System.Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                    return;
                }
                MessageBox.Show("Mã hóa thành công.");
            }
            else
            {
                try
                {
                    Decrypt(szKey, szInput, szOutput);
                }
                catch (System.Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                    return;
                }
                MessageBox.Show("Giải mã thành công.");
            }
        }
    }
}