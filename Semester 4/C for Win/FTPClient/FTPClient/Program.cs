using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace FTPClient
{
    static class Program
    {
        public static string strInput;
        public static string strUsername;
        public static string strPassword;
        public static string strHostname;
        public static IntPtr m_HOpen = new IntPtr(0);      // giu handle cua InternetOpen
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            unsafe
            {
                m_HOpen = CWinINet.InternetOpen("FTPClient", CWinINet.INTERNET_OPEN_TYPE_PRECONFIG
                    , null, null, 0);

                if (m_HOpen.ToPointer() == null)
                {
                    MessageBox.Show("Loi. InternetOpen");
                    // Xu ly neu da co ket noi roi
                }
            }
            Application.Run(new Form1());            
        }
    }
}