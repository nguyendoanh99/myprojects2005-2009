using System;
using System.Collections.Generic;
using System.Text;

namespace RobinsonAlgorithm
{
    class _Literal
    {
        #region Khai bao thuoc tinh

        private String mName; // ten menh de
        private Boolean mNot; // true : ~_Literal
                             // false : _Literal

        #endregion
        #region Khai bao phuong thuc
        #region Ham tao
        public _Literal(String Name)
        {
            Name = Name.Trim();
            // Chua kiem tra tinh hop le
            if (Name[0] == '~') // dang phu dinh
            {
                mNot = true;
                Name = Name.Replace("~", "");
            }
            else
                mNot = false;

            mName =String.Copy(Name);
        }
        // Ham tao sao chep
        public _Literal(_Literal p)
        {
            if (p == null)
            {
                mName = null;
                mNot = false;
                return;
            }

            mName = String.Copy(p.mName);
            mNot = p.mNot;
        }
        #endregion
        #region Dinh nghia cac ham phu dinh : Phu dinh bien menh de
        // Phu dinh bien menh de
        public _Literal Negative()   
        {
            _Literal result = new _Literal(mName);
            result.mNot = !mNot;

            return result;
        }
        public static _Literal operator !(_Literal p)
        {
            return p.Negative();
        }
        #endregion
        #region ToString : Chuyen Literal ve chuoi
        // Chuyen Literal ve chuoi
        public override String ToString()
        {
            String result;

            if (mNot)
                result = "~" + mName;
            else
                result = mName;
    
            return result;
        }
        #endregion
        #region Antithesis : Kiem tra 2 bien menh de co doi ngau nhau khong
        // Kiem tra 2 bien menh de co doi ngau nhau khong
        // true : doi ngau nhau
        // false : khong doi ngau nhau
        public static Boolean Antithesis(_Literal p, _Literal q)
        {
            Boolean result = false;
            if (p.mName == null || q.mName == null)
                return result;

            result = ((p.mName == q.mName) && (p.mNot != q.mNot));
            return result;
        }
        #endregion

        #endregion
    }
}
