using System;
using System.Collections.Generic;
using System.Text;

namespace RobinsonAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            _Clause x = new _Clause("p");
            _Clause y = new _Clause("~p|v");
            int i;
            int j;
            _KB kb = new _KB();
            kb.AddClause(x);
            kb.AddClause(new _Clause("v"));
            kb.AddClause(y);
            
            Console.WriteLine(kb.FindAntithesisClause(out i, out j));
            Console.WriteLine(i + " " + j);
            /*
            _RobinsonAlgorithm x = new _RobinsonAlgorithm();
            x.ReadFile("..\\..\\RobinsonInput.inp");
             * */
            /*
            _Literal t = new _Literal("~literal");
            _Clause clause = new _Clause("~p|q|r");
            
            _KB kb = new _KB();
            _KB kb1 = new _KB("p|~q");
            kb.ResultToKB("m&s, p , ~s & k");
            kb.AddClause(clause);
            kb1.AddClause(clause);            

            _KB kq = kb;
            kq = kb + kb1;

            Console.WriteLine("_Literal t = " + !t);
            Console.WriteLine("_Clause clause = " + clause);
            Console.WriteLine("_KB kb = " + kb);
            Console.WriteLine("_KB kb1 = " + kb1);
            Console.WriteLine("_KB kq=kb + kb1 = " + kq);
            Console.WriteLine("_KB kb = " + kb);
            */
        }
    }
}
