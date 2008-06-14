using System;
using System.Collections.Generic;
using System.Text;

namespace RobinsonAlgorithm
{
    class _KB
    {
        #region Khai bao thuoc tinh
        private _Clause[] mArrClause; // chua cac menh de
        #endregion        
        #region Khai bao phuong thuc
        #region Ham tao
        public _KB()
        {
            mArrClause = null;
        }
        // Bien chuoi str thanh tap cac Gia thiet
        public _KB(String str)
        {
            // Chua kiem tra tinh hop le cua du lieu str
            StringToKB(str);
        }
        // Ham dung sao chep
        public _KB(_KB p)
        {
            if (p == null)
            {
                mArrClause = null;
                return;
            }

            mArrClause = new _Clause[p.mArrClause.Length];

            for (int i = 0; i < mArrClause.Length; ++i)
                mArrClause[i] = new _Clause(p.mArrClause[i]);
        }

        #endregion
        #region StringToKB : Chuyen chuoi thanh KB
        // Chuyen chuoi thanh KB
        public void StringToKB(String str)
        {
            // Chua kiem tra tinh hop le cua str
            // Phan tich thanh cac chuoi menh de
            String[] strClause = str.Split(new String[] {","},StringSplitOptions.RemoveEmptyEntries);
            mArrClause = new _Clause[strClause.Length];

            for (int i = 0; i < strClause.Length; ++i)
                mArrClause[i] = new _Clause(strClause[i]);
        }
        #endregion
        #region AddClause : Them menh de vao KB
        // Them menh de vao KB
        public void AddClause(_Clause p)
        {
            if (p == null)
                return;

            if (mArrClause == null)
                mArrClause= new _Clause[1];
            else
                Array.Resize(ref mArrClause, mArrClause.Length + 1);

            mArrClause[mArrClause.Length - 1] = new _Clause(p);
        }
        #endregion
        #region ToString : Chuyen KB ve chuoi
        // Chuyen KB ve chuoi
        public override string ToString()
        {
            String result = "";
            if (mArrClause != null)
            {
                for (int i = 0; i < mArrClause.Length; ++i)
                    result += "," + mArrClause[i].ToString();

                result = result.Substring(1);
            }

            return result;
        }
        #endregion
        #region ConclusionToKB : Chuyen chuoi ket luan thanh KB
        // Chuyen chuoi ket luan thanh KB
        public static _KB ConclusionToKB(String str)
        {
            // Chua kiem tra tinh hop le cua chuoi str
            _KB result = new _KB();
            str = str.Replace("|", ",");
            String[] strClause = str.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries); // Phan tich thanh cac chuoi menh de
            result.mArrClause = new _Clause[strClause.Length];

            // Them cac menh de vao KB
            for (int i = 0; i < strClause.Length; ++i)
            {
                _Clause clause = new _Clause();
                // Tu cac chuoi menh de, phan tich thanh cac chuoi bien menh de
                String[] strLiteral = strClause[i].Split(new String[] { "&" }, StringSplitOptions.RemoveEmptyEntries); 
                // Them cac bien menh de vao menh de clause
                for (int j = 0; j < strLiteral.Length; ++j)
                {
                    _Literal literal = new _Literal(strLiteral[j]);
                    clause.AddLiteral(!literal);
                }

                result.mArrClause[i] = clause;
            }

            return result;
        }
        #endregion
        #region operator+ : tao KB moi bang cach ghep 2 KB lai voi nhau
        // tao KB moi bang cach ghep 2 KB lai voi nhau
        public static _KB operator + (_KB p, _KB q)
        {
            _KB result;

            if (p == null)
            {
                if (q == null)
                    result = null;
                else
                    result = new _KB(q);
            }
            else
            {
                result = new _KB(p);

                if (q != null)
                {
                    for (int i = 0; i < q.mArrClause.Length; ++i)
                        result.AddClause(q.mArrClause[i]);
                }
            }

            return result;
        }
        #endregion
        #region FindAntithesisClause : Tim 2 menh de doi ngau
        // Tim 2 menh de doi ngau
        // true : neu tim thay; index1, index2 cho biet vi tri cua 2 menh de doi ngau da tim duoc
        // false : khong tim thay
        public Boolean FindAntithesisClause(out int index1, out int index2)
        {
            Boolean result = false;
            index1 = -1;
            index2 = -1;
            if (mArrClause == null)
                return result;

            for (int i = 0; i < mArrClause.Length; ++i)
            {
                for (int j = i + 1; j < mArrClause.Length; ++j)
                    if (_Clause.Antithesis(mArrClause[i], mArrClause[j]) == true)
                    {
                        result = true;
                        index1 = i;
                        index2 = j;
                        return result;
                    }
            }

            return result;
        }
        #endregion
        #region FindClause : Tim 2 menh de ma trong 2 menh de do co bien menh de doi ngau nhau
        // Tim 2 menh de ma trong 2 menh de do co bien menh de doi ngau nhau
        // true : tim thay; index1, index2 cho biet vi tri cua 2 menh de do
        // false : khong tim thay
        public Boolean FindClause(out int index1, out int index2)
        {
            Boolean result = false;
            index1 = -1;
            index2 = -1;

            if (mArrClause == null)
                return result;

            for (int i = 0; i < mArrClause.Length; ++i)
            {
                for (int j = i + 1; j < mArrClause.Length; ++j)
                    if (_Clause.AntithesisLiteral(mArrClause[i], mArrClause[j]) == true)
                    {
                        result = true;
                        index1 = i;
                        index2 = j;
                        return result;
                    }
            }

            return result;
        }
        #endregion

        #endregion
    }
}