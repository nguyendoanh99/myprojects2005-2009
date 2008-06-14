using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Unify
{
    class Program
    {
        static _Term[] w1;
        static _Term[] w2;

        static void Main(string[] args)
        {
            /*
            _MGU s = new _MGU();
            
            s.Add(new _Element(new _Variable("t"), _Term.arrPatternObject[2].NewObject("M")));
            s.Add(new _Element(new _Variable("x"), new _Variable("y")));
            s.Add(new _Element(new _Variable("y"), _Term.arrPatternObject[2].NewObject("p(z)")));
            s.Add(new _Element(new _Variable("z"), _Term.arrPatternObject[2].NewObject("G(t)")));
            _Term x = _Term.arrPatternObject[2].NewObject("F(G(H(x)))");
            _Term y = x.Replace(s);
            */
            ReadFile("..\\..\\Unify.inp");
            WriteFile("..\\..\\Unify.out");
        }
        static void ReadFile(String FileName)
        {
            String str = _FileProcess.ReadFile(FileName);
            String[] arrStr = str.Split(new String[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            int num = int.Parse(arrStr[0]);
            w1 = new _Term[num];
            w2 = new _Term[num];
            for (int i = 1; i <= num; ++i)
            {
                String[] tempStr = arrStr[i].Split(new String[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                w1[i - 1] = _Term.arrPatternObject[2].NewObject(tempStr[0]);
                w2[i - 1] = _Term.arrPatternObject[2].NewObject(tempStr[1]);
                Console.WriteLine(w1[i - 1].ToString() + " " + w2[i - 1].ToString());
            }
        }
        static void WriteFile(String FileName)
        {
            
            String str = "";
            for (int i = 0; i < w1.Length; ++i)
            {
                _Unify u = new _Unify(w1[i], w2[i]);
                _MGU s;
                str += (i + 1) + ". ";
                Boolean flag = u.Run(out s);
                if (flag == true)
                    str += "Yes: " + s.ToString();
                else
                    str += "No";
                str += "\n";
            }
            Console.WriteLine(str);
            _FileProcess.WriteFile(FileName, str);
        }
    }
}
