using System;
using System.Collections.Generic;
using System.Text;

namespace ThuePhongConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            KHACHSAN ks = new KHACHSAN();
            ks.ReadXML(@"..\..\phong.xml");
            ks.WriteXML(@"c:\testKhachSan.xml");
        }
    }
}
