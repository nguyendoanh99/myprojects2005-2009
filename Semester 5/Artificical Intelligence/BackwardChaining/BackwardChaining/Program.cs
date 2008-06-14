using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace BackwardChaining
{
    class Program
    {
        static _Term[] G;
        static _KB kb;
        static void Main(string[] args)
        {
            /*
            _Composite x = (_Composite) _Term.arrPatternObject[2].NewObject("P(x,f(y,z),x)");
            _Composite y = x.ExtraName("?");
            ArrayList t = y.GetListOfVariable();
            for (int i = 0; i < t.Count; ++i)
            {
                _Variable t1 = (_Variable)t[i];
                Console.WriteLine(t1.ToString());
            }
            */
//             P(x,y,x) P(y,A,z)
            /*
            _Term x = _Term.arrPatternObject[2].NewObject("P(x,y,x)");
            _Term y = _Term.arrPatternObject[2].NewObject("P(y,A,z)");
            _Unify u = new _Unify(x, y);
            _MGU m;
            u.Run(out m);
            */

            ReadFile(args[0]);
            WriteFile(args[1]);
            
        }
        static void ReadFile(String FileName)
        {
            String str = _FileProcess.ReadFile(FileName);

            if (str == "")
            {
                Console.WriteLine("Khong mo duoc file");
            }
            else
            {
                String[] arrStr = str.Split(new String[] { "KB", "ENDKB" }, StringSplitOptions.RemoveEmptyEntries);
                // Xu ly co so tri thuc
                String[] temp = arrStr[0].Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                kb = new _KB();
                for (int i = 0; i < temp.Length; ++i)
                {
                    _Horn e = new _Horn(temp[i]);
                    kb.Add(e);
                }

//                Console.WriteLine(kb);

                temp = arrStr[1].Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                G = new _Term[temp.Length];
                for (int i = 0; i < temp.Length; ++i)
                {
                    G[i] = _Term.arrPatternObject[2].NewObject(temp[i].Replace("G:", ""));
//                    Console.WriteLine(G[i].ToString());
                }
            }
        }
        static void WriteFile(String FileName)
        {
            String str = "";
            _BackwardChaining bc = new _BackwardChaining(kb);
            for (int i = 0; i < G.Length; ++i)
            {
                bc.Run(G[i]);
                 
                str += G[i].ToString() + "\r\n";
//                Console.WriteLine(G[i].ToString());
//                Console.WriteLine(bc.GetResult() + "\n");
                str += bc.GetResult().Replace("\n", "\r\n") + "\r\n\r\n";

/*                Console.WriteLine(bc.Count);
                for (int j = 0; j < bc.Count; ++j)
                {
                    Console.WriteLine("\t" + bc[j]);
                }
                */
             }
            _FileProcess.WriteFile(FileName, str);
        }
    }
}
