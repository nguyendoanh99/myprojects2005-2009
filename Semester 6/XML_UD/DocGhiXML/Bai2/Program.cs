using System;
using System.Collections.Generic;
using System.Text;

namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            _DaThuc dthuc = new _DaThuc();
            dthuc.ReadXML(@"..\..\DaThuc.xml");
            dthuc.WriteXML(@"c:\DaThuc.xml");
            Console.WriteLine(dthuc);
        }
    }
}
