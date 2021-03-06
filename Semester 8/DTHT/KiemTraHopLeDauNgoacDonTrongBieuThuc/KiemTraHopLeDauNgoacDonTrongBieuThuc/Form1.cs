using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KiemTraHopLeDauNgoacDonTrongBieuThuc
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Trả về vị trí đầu tiên làm cho biểu thức bất hợp lệ
        /// </summary>
        /// <param name="text"> Biểu thức</param>
        /// <returns>-1: hợp lệ; >-1: vị trí đầu tiên làm cho biểu thức bất hợp lệ</returns>
        public static int KiemTraHopLeDauNgoacDonTrongBieuThuc(string text)
        {
            int result = -1;
            List<int> l = new List<int>();
            for (int i = 0; i < text.Length; ++i )
            {
                if (text[i] == '(')
                {
                    l.Add(i);
                }
                else
                    if (text[i] == ')')
                    {
                        if (l.Count == 0)
                        {
                            result = i;
                            break;
                        }
                        else
                            l.RemoveAt(l.Count - 1);
                    }
            }

            if (l.Count > 0)
                result = l[l.Count - 1];

            return result;
        }

        public Form1()
        {
            InitializeComponent();
        }

        
        private void txtEquation_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            string strEquation = tb.Text;
            int result = KiemTraHopLeDauNgoacDonTrongBieuThuc(strEquation);

            if (result == -1)
                lblResult.Text = "Biểu thức hợp lệ";
            else
                lblResult.Text = "Biểu thức bất hợp lệ tại vị trí " + result.ToString();
        }
    }
}