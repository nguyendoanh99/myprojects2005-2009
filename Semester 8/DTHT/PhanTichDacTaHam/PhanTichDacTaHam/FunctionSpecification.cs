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
    }
}
