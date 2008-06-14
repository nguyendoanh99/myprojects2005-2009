using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace BackwardChaining
{
    class _KB
    {
        #region Khai bao thuoc tinh
        ArrayList mContent; // Chua danh sach doi tuong _Horn
        #endregion
        #region Khai bao property
        public _Horn this[int index]
        {
            get
            {
                return (_Horn)mContent[index];
            }
        }
        public int Count
        {
            get
            {
                return mContent.Count;
            }
        }
        #endregion
        #region Khai bao phuong thuc
        #region Ham tao
        public _KB()
        {
            mContent = new ArrayList();
        }
        public _KB(_KB p)
        {
            mContent = new ArrayList();
            for (int i = 0; i < p.mContent.Count; ++i)
                Add((_Horn)p.mContent[i]);
        }
        #endregion
        #region Add : them 1 doi tuong _Horn vao KB
        public void Add(_Horn p)
        {
            mContent.Add(new _Horn(p));
        }
        #endregion
        #region ToString
        public override String ToString()
        {
            String result = "KB\n";
            for (int i = 0; i < mContent.Count; ++i)
            {
                _Horn temp = (_Horn) mContent[i];
                result += temp.ToString() + "\n";
            }
            result += "ENDKB";

            return result;
        }
        #endregion
        #endregion
    }
}
