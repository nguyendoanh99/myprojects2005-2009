using System;
using System.Collections.Generic;
using System.Text;

namespace Bai3
{
    class Program
    {
        static void Main(string[] args)
        {
            _BieuThuc b = new _BieuThuc();
            b.ReadXML(@"..\..\BieuThuc.xml");
            b.WriteXML(@"c:\BieuThucBai3.xml");
            Console.WriteLine(b);
        }
    }
}
