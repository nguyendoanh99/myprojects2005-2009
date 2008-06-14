using System;
using System.Collections.Generic;
using System.Text;

namespace RobinsonAlgorithm
{
    class _Clause
    {
        #region Khai bao thuoc tinh
        private _Literal[] mArrLiteral; // chua cac bien menh de        
        #endregion
        #region Khai bao phuong thuc
        #region Ham tao
        public _Clause()
        {
            mArrLiteral = null;
        }
        public _Clause(String str)
        {
            // Chua kiem tra tinh hop le cua chuoi str
            String[] temp = str.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            mArrLiteral = new _Literal[temp.Length];
            for (int i = 0; i < temp.Length; ++i)
                mArrLiteral[i] = new _Literal(temp[i]);
        }
        // Ham tao sao chep
        public _Clause(_Clause p)
        {
            if (p == null)
            {
                mArrLiteral = null;
                return;
            }

            mArrLiteral = new _Literal[p.mArrLiteral.Length];

            for (int i = 0; i < mArrLiteral.Length; ++i)
                mArrLiteral[i] = new _Literal(p.mArrLiteral[i]);
        }
        #endregion
        #region AddLiteral : Them bien menh de vao menh de
        // Them bien menh de vao menh de
        public void AddLiteral(_Literal p) 
        {
            if (p == null)
                return;

            if (mArrLiteral == null)
                mArrLiteral = new _Literal[1];
            else
                Array.Resize(ref mArrLiteral, mArrLiteral.Length + 1);

            mArrLiteral[mArrLiteral.Length - 1] = new _Literal(p);
        }
        #endregion
        #region ToString : Chuyen Clause thanh chuoi
        // Chuyen Clause thanh chuoi
        public override string ToString()
        {
            String result = "";
            if (mArrLiteral != null)
            {
                for (int i = 0; i < mArrLiteral.Length; ++i)
                    result += "|" + mArrLiteral[i].ToString();
             
                result = result.Substring(1);
            }
            
            return result;
        }
        #endregion
        #region Antithesis : Kiem tra 2 menh de co doi ngau nhau khong
        // Kiem tra 2 menh de co doi ngau nhau khong
        // true : doi ngau nhau
        // false : khong doi ngau nhau
        public static Boolean Antithesis(_Clause p, _Clause q)
        {
            Boolean result = false;
            if (p == null || q == null)
                return result;

            if (p.mArrLiteral == null || q.mArrLiteral == null)
                return result;

            if (p.mArrLiteral.Length != 1 || q.mArrLiteral.Length != 1)
                return result;

            result = _Literal.Antithesis(p.mArrLiteral[0], q.mArrLiteral[0]);

            return result;
        }
        #endregion
        #region AntithesisLiteral : Kiem tra 2 menh de co chua bien menh de doi ngau nhau khong
        // Kiem tra 2 menh de co chua bien menh de doi ngau nhau khong
        // true : co bien menh de doi ngau nhau
        // false : khong co bien menh de doi ngau nhau
        public static Boolean AntithesisLiteral(_Clause p, _Clause q)
        {
            Boolean result = false;
            if (p == null || q == null)
                return result;

            if (p.mArrLiteral == null || q.mArrLiteral == null)
                return result;

            for (int i = 0; i < p.mArrLiteral.Length && !result; ++i)
            {
                for (int j = 0; j < q.mArrLiteral.Length && !result; ++j)
                    if (_Literal.Antithesis(p.mArrLiteral[i], q.mArrLiteral[j]) == true)
                        result = true;
            }

            return result;
        }
        #endregion

        #endregion
    }
}
