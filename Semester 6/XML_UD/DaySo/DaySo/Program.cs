using System;
using System.Collections.Generic;
using System.Text;

namespace DaySo
{
    class Program
    {
        static void Main(string[] args)
        {
            DaySo t = new DaySo();
            t.ReadXML(@"..\..\DaySo.xml");
            t.Sort();
            t.WriteXML(@"C:\testDaySo.xml");
        }
    }
}
