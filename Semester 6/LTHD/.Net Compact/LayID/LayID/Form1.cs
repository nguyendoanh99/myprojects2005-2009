using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace LayID
{
    public partial class Form1 : Form
    {
        // For Windows Mobile, replace user32.dll with coredll.dll
        public const int GWL_ID = (-12);
        [DllImport("coredll.dll", EntryPoint="FindWindowW", SetLastError=true)]
        private static extern IntPtr FindWindowCE(string lpClassName, string lpWindowName);
        [DllImport("coredll.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("coredll.dll")]
        static extern bool SetWindowText(IntPtr hWnd, string lpString);
        [DllImport("coredll.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        public Form1()
        {
            InitializeComponent();
        }

        private void butFind_Click(object sender, EventArgs e)
        {
            string caption = txtCaption.Text;
            IntPtr result = FindWindowCE(null, caption);
            StringBuilder sb = new StringBuilder();
//            SetWindowText(result, "Co len");
            //int t = GetWindowText(result, sb, 25);
            int t = GetWindowLong(result, GWL_ID);
            txtResult.Text = result.ToString() +" " + t.ToString();
        }
    }
}