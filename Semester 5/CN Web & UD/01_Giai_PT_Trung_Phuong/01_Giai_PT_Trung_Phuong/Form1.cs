using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace _1_Giai_PT_Trung_Phuong
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

        private void butGiai_Click(object sender, EventArgs e)
        {
            XL_PT_TRUNG_PHUONG P;
            XL_NGHIEM_PT_TRUNG_PHUONG ng;
            String szHesoA = txtA.Text;
            String szHesoB = txtB.Text;
            String szHesoC = txtC.Text;

            String ChuoiLoi = XL_LOI.Loi(szHesoA, szHesoB, szHesoC);

            if (ChuoiLoi == "")
            {
                float a = float.Parse(szHesoA);
                float b = float.Parse(szHesoB);
                float c = float.Parse(szHesoC);

                P = new XL_PT_TRUNG_PHUONG(a, b, c);                
                ng = P.GiaiPT();

                lblNghiem.Text = ng.Chuoi();
            }
            else
                MessageBox.Show(ChuoiLoi, "Loi");
        } 
    }
}