using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionSpecificationLibrary
{
    class Condition
    {

    }
    class SimpleCondition:Condition
    {
        private string _value1;

        public string Value1
        {
            get { return _value1; }
            set { _value1 = value; }
        }
        private string _value2;

        public string Value2
        {
            get { return _value2; }
            set { _value2 = value; }
        }
        private string _operation;

        public string Operation
        {
            get { return _operation; }
            set { _operation = value; }
        }
        public SimpleCondition(string text)
        {
            text = text.Trim(new char[] {'(', ')', ' '});
            string[] arr = text.Split(new string[] {"=", ">", "<", "<>"}, StringSplitOptions.RemoveEmptyEntries);
            _value1 = arr[0].Trim();
            _value2 = arr[1].Trim();
            _operation = text.Replace(_value1, "").Replace(_value2, "");
        }
    }
    class Conditions:Condition
    {
        private List<Condition> _parts = new List<Condition>();
        private List<string> _operationBooleans = new List<string>();

        public Conditions(string text)
        {
//             text = text.Trim();
//             while (text != string.Empty)
//             {
//                 int begin = 0;
//                 int d = 0;
//             }
        }
    }
}
