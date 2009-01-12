using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Generated.ManagerObjects;
using NHibernate.Generated.BusinessObjects;
using test;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
//             try
//             {
//                 ManagerFactory mf = new ManagerFactory();
//                 IKhachHangManager kh = mf.GetKhachHangManager();
//                 KhachHang khdto = kh.GetById(3);
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(ex);
//             }
// 
//             //
            XeDaSuaTests test = new XeDaSuaTests();
            test.Create();
            //KhachHangTests t = new KhachHangTests();
            //t.Delete();
        }
    }
}
