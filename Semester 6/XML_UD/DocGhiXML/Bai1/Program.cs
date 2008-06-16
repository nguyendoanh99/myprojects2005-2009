using System;
using System.Collections.Generic;
using System.Text;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            _BieuThuc b = new _BieuThuc();
            b.ReadXML(@"..\..\BieuThuc.xml");
            b.WriteXML(@"c:\BieuThuc.xml");
            Console.WriteLine(b);
        }
    }
}
