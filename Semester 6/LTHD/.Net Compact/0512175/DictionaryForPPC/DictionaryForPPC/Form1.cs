using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using DictionaryForPPC.WebserviceForDictionary;
namespace DictionaryForPPC
{
    public partial class Form1 : Form
    {
        private List<CRecordLanguage> _Language = new List<CRecordLanguage>(); // Lưu mã chuyển đổi của 2 ngôn ngữ (dựa vào google)
        private Dictionary<string, string> _arrDictionary = new Dictionary<string, string>(); // Lưu các bộ từ điển hiện có
        private CDictionary _dic = new CDictionary();
        private MenuItem _CurrentDictionary = null;
        private string _strCurrentWord="";
        private List<string> _arrWord = new List<string>(); // Lưu các word đã tra
        private List<string> _arrVoice = new List<string>(); // Lưu các tên file âm thanh đã được phát
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Kiểm tra có bao nhiêu từ điển
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Program Files\DictionaryForPPC\Dictionaries.xml");
            XmlElement root = doc.DocumentElement;
            XmlNode node = root.FirstChild;
            while (node != null)
            {
                string szName = node.Attributes["name"].Value;
                string szFile = node.Attributes["file"].Value;
                _arrDictionary.Add(szName, szFile);
                node = node.NextSibling;
            }
            // Đưa các bộ từ điển hiện có lên menu
            foreach (KeyValuePair<string, string> rl in _arrDictionary)
            {
                MenuItem mi = new MenuItem();
                mi.Text = rl.Key;
                mi.Click += new System.EventHandler(mnuDictionary_Click);
                // Chọn bộ từ điển đầu tiên
                if (_CurrentDictionary == null)
                    _CurrentDictionary = mi;

                mnuDictionary.MenuItems.Add(mi);                
            }
            // Chọn bộ từ điển đầu tiên
            if (_CurrentDictionary != null)
            {
                _CurrentDictionary.Checked = true;
                LoadDictionary(_arrDictionary[_CurrentDictionary.Text]);
            }            

            panelTranslator.Visible = false;
            _Language.Add(new CRecordLanguage("English to Dutch", "en|nl"));
            _Language.Add(new CRecordLanguage("English to French", "en|fr"));
            _Language.Add(new CRecordLanguage("English to German", "en|de"));
            _Language.Add(new CRecordLanguage("English to Italian", "en|it"));
            _Language.Add(new CRecordLanguage("English to Portuguese", "en|pt"));
            _Language.Add(new CRecordLanguage("English to Spanish", "en|es"));
            _Language.Add(new CRecordLanguage("Dutch to English", "nl|en"));
            _Language.Add(new CRecordLanguage("French to English", "fr|en"));
            _Language.Add(new CRecordLanguage("French to Greman", "fr|de"));
            _Language.Add(new CRecordLanguage("Greman to English", "de|en"));
            _Language.Add(new CRecordLanguage("Greman to French", "de|fr"));
            _Language.Add(new CRecordLanguage("Italian to English", "it|en"));
            _Language.Add(new CRecordLanguage("Portuguese to English", "pt|en"));
            _Language.Add(new CRecordLanguage("Spanish to English", "es|en"));

            for (int i = 0; i < _Language.Count; ++i)
                cmbLanguage.Items.Add(_Language[i]);
            cmbLanguage.SelectedIndex = 0;            
            
        }

        private void cmbWord_TextChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            CRecord rec;
            int index = _dic.FindWord(cmb.Text);
            if (index >= 0)
            {
                rec = _dic[index];
                txtMeaning.Text = rec.Meaning.Replace("\n", "\r\n");
                _strCurrentWord = rec.Word;
            }

            int max = Math.Min(5, _dic.Count);
            cmbWord.Items.Clear();
            index = Math.Max(index + 1, 0);
            if (_dic.Count - index < max)
            {
                index = _dic.Count - max;
            }

            for (int i = index, count = 0; count < Math.Min(max, _dic.Count - index); count++)
            {
                rec = _dic[i + count];
                cmbWord.Items.Add(rec.Word);
            }
        }

        private void butTranslate_Click(object sender, EventArgs e)
        {
            string szOriginalText = txtOriginalText.Text.Trim();
            string szResultText = "";
            string szLanguage = _Language[cmbLanguage.SelectedIndex].Code;
            if (szOriginalText.Length != 0)
            {
                try
                {
                    Service t = new Service();
                    t.Url = "http://" + Properties.Resources.URLService + "/WebserviceForDictionary/Service.asmx";
                    szResultText = t.Translator(szOriginalText, szLanguage);
                }
                catch (System.Exception e1)
                {
                    MessageBox.Show(e1.ToString());
                }
                
            }
            txtResultText.Text = szResultText;
        }

        private void mnuDictionary_Click(object sender, EventArgs e)
        {
            MenuItem mi = (MenuItem)sender;
            if (mi == _CurrentDictionary)
                return;
            mi.Checked = true;
            LoadDictionary(_arrDictionary[mi.Text]);

            if (_CurrentDictionary != null)
                _CurrentDictionary.Checked = false;
            
            _CurrentDictionary = mi;

            panelTranslator.Visible = false;
            PanelDictionary.Visible = true;
        }

        private void mnuTranslator_Click(object sender, EventArgs e)
        {
            panelTranslator.Visible = true;
            PanelDictionary.Visible = false;
        }

        private void cmbWord_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void LoadDictionary(string FileName)
        {
            _dic.ReadFile(@"Program Files\DictionaryForPPC\" + FileName);
            cmbWord.Items.Clear();
            for (int count = 0; count < Math.Min(5, _dic.Count); count++)
            {
                CRecord rec = _dic[count];
                cmbWord.Items.Add(rec.Word);
            }
        }

        private void butSpeakWord_Click(object sender, EventArgs e)
        {
            Speak(_strCurrentWord, false);
        }
        // text: đoạn văn dùng để đọc
        // flag = true: đọc đoạn văn
        // flag = false: đọc từ
        private void Speak(string text, bool flag)
        {
            FileStream fs = null;
            string filename = "";
            try
            {
                int index = _arrWord.IndexOf(text);
                if (index >= 0 && flag == false)
                {
                    filename = _arrVoice[index];
                }
                else
                {
                    if (flag == false) // Đọc từ
                    {
                        if (_arrWord.Count > 9)
                        {
                            filename = _arrVoice[0];
                            _arrWord.RemoveAt(0);
                            _arrVoice.RemoveAt(0);
                        }
                        else
                            filename = @"Program Files\DictionaryForPPC\" + _arrVoice.Count.ToString() + ".wav";

                        _arrWord.Add(_strCurrentWord);
                        _arrVoice.Add(filename);
                    }
                    else
                        filename = @"Program Files\DictionaryForPPC\temp.wav";
                    
                    Service t = new Service();
                    t.Url = "http://" + Properties.Resources.URLService + "/WebserviceForDictionary/Service.asmx";
                    byte[] temp = t.TextToSpeak(text);
                    fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                    fs.Write(temp, 0, temp.Length);
                    fs.Close();
                }
                
                Sound.PlaySoundWinCE(filename, 0, 0);
            }
            catch (Exception e1)
            {
                if (fs != null)
                    fs.Close();
                MessageBox.Show(e1.ToString());
            }
        }

        private void butSpeakText_Click(object sender, EventArgs e)
        {
            string str = txtOriginalText.Text;
            Speak(str, true);
        }

        private void butSpeakResult_Click(object sender, EventArgs e)
        {
            string str = txtResultText.Text;
            Speak(str, true);
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
        }

        private void toolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {

        }
    }
    public class CRecordLanguage
    {
        public string Name;
        public string Code;
        public CRecordLanguage(string szName, string szCode)
        {
            Name = szName;
            Code = szCode;
        }
        public override string ToString()
        {
            return Name;
        }
    }

}