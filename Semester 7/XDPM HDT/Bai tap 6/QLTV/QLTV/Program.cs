using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QLTV
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string DBFullPathName = Application.StartupPath + "\\ThuVien.mdb";
            DAO.DataProvider.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DBFullPathName;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.CurrentCulture = new System.Globalization.CultureInfo("vi-VN");
            Application.Run(new TheDocGia());
        }
    }
}