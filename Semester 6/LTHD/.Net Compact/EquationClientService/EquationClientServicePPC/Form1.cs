using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EquationClientServicePPC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void butGiaiPT_Click(object sender, EventArgs e)
        {

        }

        private void butGiaiPT_Click_1(object sender, EventArgs e)
        {
            txtKetQua.Text = "Xin doi trong giay lat...";

            float a = float.Parse(txtA.Text);
            float b = float.Parse(txtB.Text);
            float c = float.Parse(txtC.Text);
            String strIP = txtIPServer.Text;
            String strPort = txtPort.Text;

            try
            {
                EquationService.Service es = new EquationService.Service();
                es.Url = "http://" + strIP + ":" + strPort + "/EquationWebService/Service.asmx";
                byte[] arrKQ = es.GiaiPT(a, b, c);
                Nghiem ng = Nghiem.XMLtoNghiem(Encoding.ASCII.GetString(arrKQ, 0, arrKQ.Length));
                txtKetQua.Text = ng.ToString();
            }
            catch (System.Exception e1)
            {
                MessageBox.Show(e1.ToString());
                txtKetQua.Text = "";
            }
            
        }
    }
}