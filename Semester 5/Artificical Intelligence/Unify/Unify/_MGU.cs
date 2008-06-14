using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace Unify
{    
    class _MGU
    {
        #region Khai bao thuoc tinh
        ArrayList mContent; // chua mang cac Element
        #endregion
        #region Khai bao property
        public _Element this[int index]
        {
            get 
            {
                return (_Element) mContent[index];
            }
        }
        // Cho biet so phan tu co trong MGU
        public int Count
        {
            get 
            {
                return mContent.Count;
            }
        }
        #endregion 
        #region Khai bao Ham tao
        public _MGU()
        {
            mContent = new ArrayList();
        }
        #endregion
        #region Khai bao phuong thuc
        #region Add : Them mot phan tu vao _MGU
        public void Add(_Element x)
        {
            mContent.Add(new _Element(x));
            #region Doan sap xep cac phan tu, nhung ko giup cho viec thay the nhanh hon, nen ko ap dung nua (Nhung cach sap xep la dung)
            /* 
            int index1;
            int index2;
            _Element e;
            // Sap xep lai theo dang : {x/y, y/z, t/z, z/k} neu them {k/x} thi them vao dau
            for (index1 = 0; index1 < mContent.Count; ++index1)
            {
                e = (_Element)mContent[index1];
                if (x.Arg2.IsAppear(e.Arg1))
                    break;                
            }
            // co truoc {x/f(k), y/g(k), z/q(k)} can them vao {k/z} --> phai them vao sau {z/q(k)} them vao cuoi
            for (index2 = mContent.Count - 1; index2 >= 0; --index2)
            {
                e = (_Element)mContent[index2];
                if (e.Arg2.IsAppear(x.Arg1))
                {
                    ++index2;
                    break;
                }
            }
            // Truong hop {z/m, m/g(o), x/k, y/g(k), t/k} them vao {k/f(z)}
            if (index1 != mContent.Count && index2 != -1)
            {
                mContent.Insert(index2, new _Element(x));
                _Element temp = (_Element)mContent[index1];
                mContent.RemoveAt(index1);
                Add(temp);
            }
            else
                if (index1 != mContent.Count)
                    mContent.Insert(index1, new _Element(x));
                else
                    if (index2 != -1)
                        mContent.Insert(index2, new _Element(x));
                    else
          */
            #endregion
        }
        #endregion
        #region Find : tim x co nam trong _MGU
        public _Element Find(_Variable x)
        {
            _Element result = null;
            _Element temp;
            for (int i = 0; i < mContent.Count; ++i)
            {
                temp = (_Element) mContent[i];
                if (temp.IsBelong(x) == true)
                {
                    result = new _Element(temp);
                    break;
                }
            }
            return result;
        }
        public _Element Find(_Term x)
        {
            _Element result = null;
            _Element temp;
            for (int i = 0; i < mContent.Count; ++i)
            {
                temp = (_Element)mContent[i];
                if (temp.IsBelong(x) == true)
                    result = new _Element(temp);
            }
            return result;
        }
        #endregion
        #region ToString
        public override String ToString()
        {
            String result = "{";
            for (int i = 0; i < mContent.Count; ++i )
            {
                _Element temp = (_Element) mContent[i];
                result += temp.ToString();

                if (i < mContent.Count - 1)
                    result += ",";
            }
            result += "}";
            return result;
        }
        #endregion
        #endregion
    }
}
