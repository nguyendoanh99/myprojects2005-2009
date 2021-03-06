using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionSpecificationLibrary
{
    public class FunctionSpecification
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
        private string _preInputFunction = "Input";

        public string PreInputFunction
        {
            get { return _preInputFunction; }
            set { _preInputFunction = value; }
        }
        private string _preOutputFunction = "Output";

        public string PreOutputFunction
        {
            get { return _preOutputFunction; }
            set { _preOutputFunction = value; }
        }
        private string _preCondition = "";
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
            string[] arrPart = text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            #region Function
            string[] arr = arrPart[0].Split(new char[] {'(', ')'});
            
            // Name
            _name = arr[0].Trim();

            // Parameters
            string[] arrPara = arr[1].Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arrPara.Length; ++i)
            {
                _parameters.Add(new Parameter(arrPara[i]));
            }

            // Result
            _result = new Parameter(arr[2]);
            #endregion

            #region pre
            if (arrPart.Length > 1)
            {
                _preCondition = arrPart[1].Remove(0, 3).Trim();
            }
            #endregion
        }

        public string GenerateInputFunction()
        {
            return GenerateInputFunction(VDMTypeToCSharpType);
        }

        public string GenerateInputFunction(Dictionary<string, string> ConvertType)
        {
            StringBuilder result = new StringBuilder();
                
            // 
            result.Append("void " + _preInputFunction + "_" + Name + " ");
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

        public string GenerateOutputFunction()
        {
            return GenerateOutputFunction(VDMTypeToCSharpType);
        }

        public string GenerateOutputFunction(Dictionary<string, string> ConvertType)
        {
            StringBuilder result = new StringBuilder();

            // 
            result.Append("void " + _preOutputFunction + "_" + Name + " ");
            result.Append("(");

            StringBuilder paramString = new StringBuilder();

            paramString.Append(ConvertType[_result.Type] + " " + _result.Name);

            result.Append(paramString.ToString());
            result.AppendLine(")");

            //
            result.AppendLine("{");

            StringBuilder OutputString = new StringBuilder();
            
            OutputString.AppendLine("\tcout << \"The value of " + _result.Name + ": \" << " + _result.Name + ";");

            result.Append(OutputString.ToString());
            result.AppendLine("}");

            return result.ToString();
        }

        public string GenerateMainFunction(Dictionary<string, string> ConvertType)
        {
//             void main()
//             {
//             // Khai báo biến và kết quả
//             // Gọi hàm nhập và truyền các biến để nhận giá trị nhập vào
//             if (biểu thức pre-condition)
//             {
//             // Gọi tên hàm, truyền tham số, trả kết quả về
//             // Xuất kết quả
//             }
            //             }
            StringBuilder sbResult = new StringBuilder();

            sbResult.AppendLine("void main()");
            sbResult.AppendLine("{");

            #region Khai báo biến và kết quả
            sbResult.AppendLine("\t// Khai báo biến và kết quả");
            StringBuilder paramString = new StringBuilder();
            for (int i = 0; i < Parameters.Count; ++i)
            {
                Parameter pa = Parameters[i];

                paramString.AppendLine("\t" + ConvertType[pa.Type] + " " + pa.Name + ";");
            }
            paramString.AppendLine("\t" + ConvertType[_result.Type] + " " + _result.Name + ";");
            sbResult.AppendLine(paramString.ToString());
            #endregion

            #region Gọi hàm nhập và truyền các biến để nhận giá trị nhập vào
            sbResult.AppendLine("\t// Gọi hàm nhập và truyền các biến để nhận giá trị nhập vào");
            StringBuilder sbIntputFunction = new StringBuilder();
            sbIntputFunction.Append("\t" + _preInputFunction + "_" + Name + "(");
            StringBuilder variableString = new StringBuilder();
            for (int i = 0; i < Parameters.Count; ++i)
            {
                Parameter pa = Parameters[i];

                variableString.Append(pa.Name);
                if (i < Parameters.Count - 1)
                    variableString.Append(", ");
            }
            sbIntputFunction.Append(variableString.ToString());
            sbIntputFunction.AppendLine(");");
            sbResult.AppendLine(sbIntputFunction.ToString());
            #endregion

            #region if (biểu thức pre-condition)
            StringBuilder sbPreCondition = new StringBuilder();
            if (_preCondition != string.Empty)
            {
                string temp = _preCondition.Replace("/\\", "&&");
                temp = temp.Replace("\\/", "||");
                temp = temp.Replace("=", "==");
                temp = temp.Replace("<>", "!=");
                sbPreCondition.AppendLine("\tif (" + temp + ")");
                sbPreCondition.AppendLine("{");

                StringBuilder sbFunction = new StringBuilder();
                sbFunction.Append("\t" + _result.Name + " = " + Name + "(");
                StringBuilder varString = new StringBuilder();
                for (int i = 0; i < Parameters.Count; ++i)
                {
                    Parameter pa = Parameters[i];

                    varString.Append(pa.Name);
                    if (i < Parameters.Count - 1)
                        varString.Append(", ");
                }
                sbFunction.Append(varString.ToString());
                sbFunction.Append(");");

                sbPreCondition.AppendLine(sbFunction.ToString());
                sbPreCondition.AppendLine("\t" + PreOutputFunction + "_" + Name + "(" + _result.Name + ");");
                sbPreCondition.AppendLine("}");
                sbPreCondition.Replace("\r\n", "\r\n\t");
            }
            #endregion

            sbResult.AppendLine(sbPreCondition.ToString());
            sbResult.AppendLine("}");

            return sbResult.ToString();

        }
        public string GenerateMainFunction()
        {
            return GenerateMainFunction(VDMTypeToCSharpType);
        }
    }
}
