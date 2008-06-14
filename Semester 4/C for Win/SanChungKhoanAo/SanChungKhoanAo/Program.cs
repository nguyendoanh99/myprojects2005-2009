using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SanChungKhoanAo
{
    static class Program
    {
        public static Form1 frm1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(frm1 = new Form1());
        }
    }
}