using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DictionaryForPC.ServiceForDictionary;
using System.IO;
namespace DictionaryForPC
{
    public partial class Form1 : Form
    {
        CDictionary dic = new CDictionary();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime d1 = DateTime.Now;
            dic.ReadFile(@"c:\Anh_Viet4");
            DateTime d2 = DateTime.Now;
            textBox1.Text = (d2 - d1).ToString();
            comboBox1.Items.AddRange(dic.ListWord.ToArray());
//            Infor item = new Infor();
//            item.szWord = ".";
//            dic.BinarySearchForIndex(0, dic.Count,item, new CompareInforWithoutExact());
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            ComboBox cmb = (ComboBox) sender;
            int index = dic.FindWord(cmb.Text);
            textBox1.Text = dic[index].Meaning;
             */ 
//            MessageBox.Show(cmb.SelectedText);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            
            ComboBox cmb = (ComboBox)sender;
            int index = dic.FindWord(cmb.Text);
            if (index >= 0)
            {
                CRecord rec = dic[index];
                textBox1.Text = rec.Meaning;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Service t = new Service();
            byte[] temp = t.TextToSpeak("what's your name");
            FileStream fs = new FileStream("temp.wav", FileMode.Create, FileAccess.Write);
            fs.Write(temp, 0, temp.Length);
            fs.Close();
            testSound.Sound.PlaySoundWin32("temp.wav", 0, 0);
        }
    }
}