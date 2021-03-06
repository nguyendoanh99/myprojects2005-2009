using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
namespace HashApp
{
    public partial class Form1 : Form
    {
        List<CState> _arrHashAlgorithm = new List<CState>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            _arrHashAlgorithm.Add(new CState(new SHA1CryptoServiceProvider(), "SHA1"));
            _arrHashAlgorithm.Add(new CState(new MD5CryptoServiceProvider(), "MD5"));
            _arrHashAlgorithm.Add(new CState(new SHA256Managed(), "SHA256"));
            _arrHashAlgorithm.Add(new CState(new SHA384Managed(), "SHA384"));
            _arrHashAlgorithm.Add(new CState(new SHA512Managed(), "SHA512"));
            
            cmbHashAlgorithm.DataSource = _arrHashAlgorithm;
            cmbHashAlgorithm.DisplayMember = "AlgorithmName";
            cmbHashAlgorithm.ValueMember = "Algorithm";
            cmbHashAlgorithm.SelectedIndex = 0;

        }

        private void cmbHashAlgorithm_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void butBrowseInput_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = openFileDialog1.FileName;
            }
        }

        private void butCreate_Click(object sender, EventArgs e)
        {
            CState selectedItem = (CState)cmbHashAlgorithm.SelectedItem;
            HashAlgorithm ha = selectedItem.Algorithm;
            FileStream fsInput = null;
            StreamWriter fsOutput = null;
            string InputFileName = txtInput.Text.Trim();
            string OutputFileName = InputFileName + "." + selectedItem.AlgorithmName;
            
            try
            {
                fsInput = new FileStream(InputFileName, FileMode.Open, FileAccess.Read);
                byte[] result = ha.ComputeHash(fsInput);
                fsOutput = new StreamWriter(OutputFileName);

                string str = ConvertToHexa(result);
                fsOutput.Write(str);
                
//                fsOutput.Write(result, 0, result.Length);
                fsInput.Close();
                fsOutput.Close();
                MessageBox.Show("File hash \"" + OutputFileName + "\" đã tạo thành công.");
            }
            catch (System.Exception e1)
            {
                if (fsInput != null)
                    fsInput.Close();
                if (fsOutput != null)
                    fsOutput.Close();

                MessageBox.Show(e1.ToString());
            }
        }

        private void butBrowseInput_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtInput.Text = openFileDialog1.FileName;
            }
        }

        private void butBrowseOutput_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtHashFile.Text = openFileDialog1.FileName;
            }
        }

        private void butBrowseInputTest_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtInputTest.Text = openFileDialog1.FileName;
            }
        }

        private void txtHashFile_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string strFileHash = txtHashFile.Text;
                string strHash = strFileHash.Substring(strFileHash.LastIndexOf('.') + 1);
                txtAlgorithm.Text = strHash;
            }
            catch (System.Exception)
            {
                txtAlgorithm.Text = "";
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HashAlgorithm ha;
            string strAlgorithm = txtAlgorithm.Text;
            CState item = new CState(null, strAlgorithm);
            int index = _arrHashAlgorithm.IndexOf(item);
            if (index >= 0)
            {
                ha = _arrHashAlgorithm[index].Algorithm;
                FileStream fsInput = null;
                StreamReader fsHash = null;
                string InputFileName = txtInputTest.Text.Trim();
                string HashFileName = txtHashFile.Text.Trim();
                try
                {
                    fsInput = new FileStream(InputFileName, FileMode.Open, FileAccess.Read);
                    fsHash = new StreamReader(HashFileName);

                    byte[] valueInput = ha.ComputeHash(fsInput);
                    string strInput = ConvertToHexa(valueInput);
                    string strHash = fsHash.ReadToEnd();
//                    fsHash.Read(valueHash, 0, valueHash.Length);

                    string str = "Tập tin \"" + InputFileName + "\" ___ phù hợp với tập tin hash \"" + HashFileName + "\"";

                    if(strHash == strInput)
//                    if (CompareArray(valueInput, valueHash) == true)
                        str = str.Replace("___ ", "");
                    else
                        str = str.Replace("___ ", "không ");

                    MessageBox.Show(str);

                    fsInput.Close();
                    fsHash.Close();
                }
                catch (System.Exception e1)
                {
                    if (fsInput != null)
                        fsInput.Close();
                    if (fsHash != null)
                        fsHash.Close();

                    MessageBox.Show(e1.ToString());
                }
            }
        }
        string ConvertToHexa(byte[] obj)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < obj.Length; ++i)
            {
                result.Append(string.Format("{0,2:X}", obj[i]).Replace(' ', '0'));

            }
                return result.ToString();
        }
        bool CompareArray(byte[] obj1, byte[] obj2)
        {
            if (obj1 == null || obj2 == null)
                return false;
            if (obj1.Length != obj2.Length)
                return false;

            for (int i = 0; i < obj1.Length; ++i)
                if (obj1[i] != obj2[i])
                    return false;

            return true;
        }
    }

    public class CState
    {
        private HashAlgorithm _HashAlgorithm;
        private string _AlgorithmName;

        public CState(HashAlgorithm HashAlg, string strName)
        {

            this._HashAlgorithm = HashAlg;
            this._AlgorithmName = strName;
        }

        public HashAlgorithm Algorithm
        {
            get
            {
                return _HashAlgorithm;
            }
        }

        public string AlgorithmName
        {

            get
            {
                return _AlgorithmName;
            }
        }
        public override bool Equals(object obj)
        {
            CState temp = obj as CState;
            if (temp == null)
                return false;

            if (AlgorithmName != temp.AlgorithmName)
                return false;
            return true;
        }
    }

}