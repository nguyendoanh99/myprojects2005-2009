using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BackwardChaining
{
    class _Unify
    {
        #region Khai bao thuoc tinh
        _Term mArg1;
        _Term mArg2;
        #endregion
        #region Khai bao ham rieng
        private void Init(_Term x, _Term y)
        {
            mArg1 = _Term.arrPatternObject[(int)x.GetType()].NewObject(x);
            mArg2 = _Term.arrPatternObject[(int)y.GetType()].NewObject(y);
        }
        private Boolean Run(_Term x, _Term y, ref _MGU s)
        {
            if (x.CompareTo(y))
                return true;
            else
                if (x.GetType() == _TypeOfTerm.VARIABLE)
                    return Unify_var((_Variable)x, y, ref s);
                else
                    if (y.GetType() == _TypeOfTerm.VARIABLE)
                        return Unify_var((_Variable)y, x, ref s);
                    else
                        if (x.GetType() == _TypeOfTerm.COMPOSITE && y.GetType() == _TypeOfTerm.COMPOSITE)
                        {
                            if (x.Name != y.Name)
                                return false;

                            _Composite comX = (_Composite)x;
                            _Composite comY = (_Composite)y;

                            if (comX.Count != comY.Count) // Khong cung toan tu
                                return false;

                            for (int i = 0; i < comX.Count; ++i)
                            {
                                _Term tempArrX = comX[i].Replace(s);
                                _Term tempArrY = comY[i].Replace(s);

                                if (Run(tempArrX, tempArrY, ref s) == false)
                                    return false;
                            }

                            return true;
                        }
                        else // x hoac y la hang
                            return false;
        }        
        private Boolean Unify_var(_Variable var, _Term x, ref _MGU s)
        {
            _Element val;
            if ((val = s.Find(var)) != null)
                return Run(val.Arg2, x, ref s);
            else
                if ((val = s.Find(x)) != null)
                    return Run(var, val.Arg1, ref s);
                else
                    if (x.IsAppear(var) == true)
                        return false;
                    else
                    {
                        s.Add(new _Element(var, x));
                        return true;
                    }
        }
        #endregion
        #region Khai bao Ham tao
        public _Unify(_Term x, _Term y)
        {
            Init(x, y);
        }
        public _Unify(_Unify p)
        {
            Init(p.mArg1, p.mArg2);
        }
        #endregion
        #region Khai bao phuong thuc
        public Boolean Run(out _MGU s)
        {
            s = new _MGU();
            return Run(mArg1, mArg2, ref s); ;
        }
        #endregion
    }
}
