using System;
using System.Collections.Generic;
using System.Text;

namespace Unify
{
    class _Element
    {
        #region Khai bao thuoc tinh
        _Variable mArg1;
        _Term mArg2;
        #endregion
        #region Khai bao property
        public _Variable Arg1
        {
            get
            {
                return new _Variable(mArg1);
            }
        }
        public _Term Arg2
        {
            get
            {
                return _Term.arrPatternObject[(int) mArg2.GetType()].NewObject(mArg2);
            }
        }
        #endregion
        #region Khai bao ham rieng
        private void Init(_Variable var, _Term x)
        {
            mArg1 = new _Variable(var);
            mArg2 = _Term.arrPatternObject[(int)x.GetType()].NewObject(x);
        }
        #endregion
        #region Khai bao Ham tao
        public _Element(_Variable var, _Term x)
        {
            Init(var, x);
        }
        public _Element(_Element p)
        {
            Init(p.mArg1, p.mArg2);
        }
        #endregion
        #region Khai bao phuong thuc
        #region IsBelong : kiem tra x co nam trong _Element hay khong
        public Boolean IsBelong(_Variable x)
        {
            return mArg1.CompareTo(x);
        }
        public Boolean IsBelong(_Term x)
        {
            return mArg2.CompareTo(x);
        }
        #endregion
        public override String ToString()
        {
            String result;
            result = mArg1.ToString() + "/" + mArg2.ToString();
            return result;
        }
        #endregion
    }
}
