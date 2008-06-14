using System;
using System.Collections.Generic;
using System.Text;

namespace Unify
{
    class _Variable : _Term
    {
        #region Khai bao phuong thuc
        #region Ham tao
        public _Variable() : base()
        {
        }
        public _Variable(String name) : base(name.ToLower())
        {
        }
        public _Variable(_Term p) : base(p.Name.ToLower())
        {
        }        
        #endregion
        #region GetType : lay loai cua bieu thuc
        // lay loai cua bieu thuc
        public override _TypeOfTerm GetType()
        {
            return _TypeOfTerm.VARIABLE;
        }
        #endregion
        #region NewObject : Tao doi tuong mau
        public override _Term NewObject()
        {
            return new _Variable();
        }
        public override _Term NewObject(_Term p)
        {
            return new _Variable(p);
        }
        // Chuyen chuoi thanh _Variable
        public override _Term NewObject(String str)
        {
            return new _Variable(str);
        }
        #endregion
        #region ToString : Chuyen _Variable thanh chuoi
        public override String ToString()
        {
            return Name;
        }
        #endregion
        #region CompareTo : So sanh 2 bieu thuc co bang nhau hay khong
        public override Boolean CompareTo(_Term p)
        {
            if (p.GetType() != _TypeOfTerm.VARIABLE)
                return false;

            if (Name != p.Name)
                return false;

            return true;
        }
        #endregion
        #region IsAppear : Kiem tra p co nam trong bieu thuc hay khong
        public override Boolean IsAppear(_Term p)
        {
            return CompareTo(p);
        }
        #endregion
        #region Replace :  The term bang tap s
        public override _Term Replace(_MGU s)
        {
            _Term result = new _Variable(this);
            for (int i = 0; i < s.Count; ++i)
            {
                if (s[i].Arg1.CompareTo(result))
                {
                    if (s[i].Arg2.GetType() != _TypeOfTerm.COMPOSITE)
                    {
                        result = _Term.arrPatternObject[(int)s[i].Arg2.GetType()].NewObject(s[i].Arg2);
                        if (result.GetType() == _TypeOfTerm.VARIABLE)
                            result = result.Replace(s);
                    }
                    else
                        result = s[i].Arg2.Replace(s);
                    break;
                }
            }

            return result;
        }
        #endregion
        #endregion
    }
}
