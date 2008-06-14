using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace BackwardChaining
{
    class _Horn
    {
        #region Khai bao thuoc tinh
        ArrayList mLeft; // tap cac bieu thuc ben ve trai
        _Term mRight; // bieu thuc ben ve phai
        #endregion
        #region Khai bao property
        public ArrayList Left
        {
            get
            {
                return mLeft;
            }
        }
        public _Term Right
        {
            get
            {
                return mRight;
            }
        }
        #endregion
        #region Khai bao phuong thuc
        #region Ham tao
        public _Horn(String str)
        {
            mLeft = new ArrayList();
            String[] strTemp = str.Split(new String[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
            if (strTemp.Length == 2) // Co ve trai
            {
                String[] arrTerm = strTemp[0].Split(new String[] { ")," }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < arrTerm.Length; ++i)
                {
                    if (i < arrTerm.Length - 1)
                        arrTerm[i] = arrTerm[i] + ")";

                    mLeft.Add(_Term.arrPatternObject[2].NewObject(arrTerm[i]));
                }
                str = strTemp[1];
            }
            mRight = _Term.arrPatternObject[2].NewObject(str);
        }
        public _Horn(_Horn p)
        {
            mLeft = new ArrayList();
            for (int i = 0; i < p.mLeft.Count; ++i)
            {
                _Term e = (_Term) p.mLeft[i];
                mLeft.Add(_Term.arrPatternObject[(int) e.GetType()].NewObject(e));
            }
            mRight = _Term.arrPatternObject[(int)p.mRight.GetType()].NewObject(p.mRight);
        }
        public _Horn(ArrayList Left, _Term Right)
        {
            mLeft = Left;
            mRight = Right;
        }
        #endregion
        #region ToString
        public override string ToString()
        {
            String result = "";
            if (mLeft.Count > 0)
            {
                for (int i = 0 ;i < mLeft.Count; ++i)
                {
                    _Term temp = (_Term) mLeft[i];
                    result += temp.ToString();

                    if (i < mLeft.Count - 1)
                        result += ", ";
                }
                result += " => ";
            }
            result += mRight.ToString();
            return result;
        }
        #endregion
        #endregion
    }
}
