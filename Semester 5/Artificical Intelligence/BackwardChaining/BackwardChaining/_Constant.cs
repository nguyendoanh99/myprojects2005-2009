using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace BackwardChaining
{
    class _Constant : _Term
    {
        #region Khai bao phuong thuc
        #region Ham tao
        public _Constant()
            : base()
        {
        }
        public _Constant(String name)            
            : base(char.ToUpper(name[0]) + name.Substring(1).ToLower())
        {
        }
        public _Constant(_Term p)
            : base(char.ToUpper(p.Name[0]) + p.Name.Substring(1).ToLower())
        {
        }
        #endregion
        #region GetType : lay loai cua bieu thuc
        // lay loai cua bieu thuc
        public override _TypeOfTerm GetType()
        {
            return _TypeOfTerm.CONSTANT;
        }
        #endregion
        #region NewObject : Tao doi tuong mau
        public override _Term NewObject()
        {
            return new _Constant();
        }
        public override _Term NewObject(_Term p)
        {
            return new _Constant(p);
        }
        // Chuyen chuoi thanh _Constant
        public override _Term NewObject(String str)
        {
            return new _Constant(str);
        }
        #endregion
        #region ToString : Chuyen _Constant thanh chuoi
        public override String ToString()
        {
            return Name;
        }
        #endregion        
        #region CompareTo : So sanh 2 bieu thuc co bang nhau hay khong
        public override Boolean CompareTo(_Term p)
        {
            if (p.GetType() != _TypeOfTerm.CONSTANT)
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
            _Constant result = new _Constant(this);
            return result;
        }
        #endregion
        #region GetListOfVariable : lay danh sach cac bien
        public override ArrayList GetListOfVariable()
        {
            ArrayList result = new ArrayList();
            return result;
        }
        #endregion
        #region GetListOfVariable2 : lay danh sach cac bien, khong lay bien trung
        public override ArrayList GetListOfVariable2()
        {
            return GetListOfVariable();
        }
        #endregion
        #endregion
    }
}
