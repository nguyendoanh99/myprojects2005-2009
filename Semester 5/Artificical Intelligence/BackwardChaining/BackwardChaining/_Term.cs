using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace BackwardChaining
{
    enum _TypeOfTerm
    {
        VARIABLE,
        CONSTANT,
        COMPOSITE
    }
    
    abstract class _Term
    {
        static public _Term[] arrPatternObject = new _Term[3] 
        {
            new _Variable(), 
            new _Constant(), 
            new _Composite() 
        };
        #region Khai bao thuoc tinh
        private String mName;       // Ten cua bieu thuc
        #endregion
        #region Khai bao property
        public String Name
        {
            get
            {
                return mName;
            }
        }
        #endregion
        #region Khai bao phuong thuc
        #region Ham tao
        public _Term()
        {
            mName = null;
        }
        public _Term(String name)
        {
            mName = name.Trim();          
        }
        public _Term(_Term p)
        {
            mName = String.Copy(p.mName);
        }
        #endregion
        #region ToString : Chuyen bieu thuc thanh chuoi
        public new virtual String ToString()
        {
            return mName;
        }
        #endregion

        #endregion
        #region Khai bao ham thuan ao
        // Tao doi tuong mau
        public abstract _Term NewObject();
        public abstract _Term NewObject(_Term p);
        // Chuyen chuoi thanh doi tuong tuong ung
        public abstract _Term NewObject(String str);
        // Lay loai cua bieu thuc        
        public new abstract _TypeOfTerm GetType();
        // Kiem tra 2 bieu thuc co bang nhau khong
        public abstract Boolean CompareTo(_Term p);
        // Kiem tra p co xuat hien trong bieu thuc hay khong
        public abstract Boolean IsAppear(_Term p);
        // The term bang tap s
        public abstract _Term Replace(_MGU s);
        // Lay danh sach cac bien cua bieu thuc
        public abstract ArrayList GetListOfVariable();
        // Lay danh sach cac bien cua bieu thuc, khong lay bien trung
        public abstract ArrayList GetListOfVariable2();
        #endregion
    }
}
