using System;
using System.Collections.Generic;
using System.Text;

namespace PhanTichDacTaHam
{
    class FunctionSpecification
    {
        string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        List<Parameter> _parameters = new List<Parameter>();

        internal List<Parameter> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }
        Parameter _result;

        internal Parameter Result
        {
            get { return _result; }
            set { _result = value; }
        }
        public static Dictionary<string, string> VDMTypeToCSharpType = new Dictionary<string, string>();
        static FunctionSpecification()
        {
            VDMTypeToCSharpType.Add("Z", "int");
            VDMTypeToCSharpType.Add("N", "uint");
            VDMTypeToCSharpType.Add("N1", "uint");
            VDMTypeToCSharpType.Add("R", "float");
            VDMTypeToCSharpType.Add("Q", "float");
            VDMTypeToCSharpType.Add("B", "bool");
            VDMTypeToCSharpType.Add("CHAR", "char");            
        }
        public FunctionSpecification(string text)
        {
            string[] arr = text.Split(new char[] {'(', ')'});
            
            // Name
            _name = arr[0].Trim();

            // Parameters
            string[] arrPar = arr[1].Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrPar.Length; ++i)
            {
                _parameters.Add(new Parameter(arrPar[i]));
            }

            // Result
            _result = new Parameter(arr[2]);
        }

        public string GenerateInputFunction()
        {
            return GenerateInputFunction(VDMTypeToCSharpType);
        }

        public string GenerateInputFunction(Dictionary<string, string> ConvertType)
        {
            StringBuilder result = new StringBuilder();
                
            // 
            result.Append("void " + "Input" + "_" + Name + " ");
            result.Append("(");

            StringBuilder paramString = new StringBuilder();
            for (int i = 0; i < Parameters.Count; ++i )
            {
                Parameter pa = Parameters[i];

                paramString.Append(ConvertType[pa.Type] + "& " + pa.Name);
                if (i < Parameters.Count - 1)
                    paramString.Append(", ");
            }

            result.Append(paramString.ToString());
            result.AppendLine(")");

            //
            result.AppendLine("{");

            StringBuilder InputString = new StringBuilder();
            foreach (Parameter pa in Parameters)
            {
                InputString.AppendLine("\tcout << \"Please input value of " + pa.Name + "\";");
                InputString.AppendLine("\tcin >> " + pa.Name + ";");
            }

            result.Append(InputString.ToString());
            result.AppendLine("}");

            return result.ToString();
        }
    }
}
