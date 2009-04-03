using System;
using System.Collections.Generic;
using System.Text;

namespace PhanTichDacTaHam
{
    class Parameter
    {
        string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        public Parameter(string text)
        {
            string[] arr = text.Split(new char[] { ':' });
            _name = arr[0].Trim();
            _type = arr[1].Trim().ToUpper();
        }
    }
}
