using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Unify
{
    class _Composite : _Term
    {
        
        #region Khai bao thuoc tinh
        private ArrayList mComponents;    // danh sach cac _Term
        #endregion
        #region Khai bao property
        public _Term this[int index]
        {
            get
            {
                return (_Term)mComponents[index];
            }
        }
        // Cho biet so phan tu co trong MGU
        public int Count
        {
            get
            {
                return mComponents.Count;
            }
        }
        #endregion 
        #region Khai bao ham rieng
        private void Init(ArrayList Components)
        {
            if (Components == null)
                mComponents = null;
            else
            {                
                mComponents = new ArrayList();

                for (int i = 0; i < Components.Count; ++i)
                {
                    _Term p = (_Term) Components[i];
                    mComponents.Add(_Term.arrPatternObject[(int) p.GetType()].NewObject(p));
                }
            }
        }
        #endregion
        #region Khai bao phuong thuc
        #region Ham tao
        public _Composite() : base()
        {
            mComponents = null;
        }
        public _Composite(String name, ArrayList Components)
            : base(name)
        {
            Init(Components);
        }
        public _Composite(_Composite p)
            : base(p.Name)
        {
            Init(p.mComponents);
        }
        #endregion
        #region GetType : lay loai cua bieu thuc
        // lay loai cua bieu thuc
        public override _TypeOfTerm GetType()
        {
            return _TypeOfTerm.COMPOSITE;
        }
        #endregion
        #region NewObject : Tao doi tuong mau
        public override _Term NewObject()
        {
            return new _Composite();
        }
        public override _Term NewObject(_Term p)
        {            
            return new _Composite((_Composite) p);
        }
        // Chuyen chuoi thanh _Composite
        public override _Term NewObject(String str)
        {
            _Term result = null;
            Stack stack = new Stack();
            int index;
            str = str.Trim();
            
            while (str != "")
            {
                #region ...
                index = str.IndexOfAny(new char[] { '(', ',', ')' });
                if (index == -1) // Chi xay ra khi do la bien hoac hang
                {
                    #region ...
                    str = str.Trim();
                    char c = str[0];

                    if (Char.IsUpper(c)) // La hang
                        stack.Push(new _Constant(str));
                    else
                        stack.Push(new _Variable(str));

                    str = "";
                    #endregion
                }
                else
                {
                    #region ...
                    String tempstr = str.Substring(0, index).Trim();
                    if (tempstr != "")
                        stack.Push(tempstr);

                    #region switch (str[index])
                    switch (str[index])
                    {
                        case '(':
                            stack.Push("(");
                            break;
                        case ')':
                            ArrayList arr = new ArrayList();
                            Object temp;
                            temp = stack.Pop();
                            while (temp.ToString() != "(")
                            {
                                if (temp.GetType() == "".GetType()) // Kieu chuoi
                                {
                                    String strTemp = (String) temp;
                                    char c = strTemp[0];
                                    
                                    if (Char.IsUpper(c)) // La hang
                                        arr.Add(new _Constant(strTemp));
                                    else
                                        arr.Add(new _Variable(strTemp));
                                }
                                else
                                {
                                    arr.Add(temp);
                                }
                                temp = stack.Pop();
                            }
                            
                            // Chinh lai vi tri cua cac tham so theo dung thu tu
                            ArrayList arrTemp = new ArrayList();
                            for (int i = arr.Count - 1; i >= 0; --i)
                                arrTemp.Add(arr[i]);

                            // Ten ham hoac ten vi tu
                            temp = stack.Pop();

                            // Dua doi tuong moi vao stack
                            stack.Push(new _Composite((String)temp, arrTemp));
                            break;
                    }
                    #endregion
                    str = str.Substring(index + 1);
                    #endregion
                }
                #endregion
            }
            
            result = (_Term) stack.Pop();

            return result;
        }
        #endregion
        #region ToString : Chuyen Composite thanh chuoi
        public override String ToString()
        {
            String result = Name + "(";
            if (mComponents != null)
            {
                for (int i = 0; i < mComponents.Count; ++i )
                {
                    _Term x = (_Term) mComponents[i];                    
                    result += x.ToString();
                    if (i < mComponents.Count - 1)
                        result += ", ";
                }
            }
            result += ")";
            

            return result;
        }
        #endregion
        #region CompareTo : So sanh 2 bieu thuc co bang nhau hay khong
        public override Boolean CompareTo(_Term p)
        {
            if (p.GetType() != _TypeOfTerm.COMPOSITE)
                return false;

            if (Name != p.Name)
                return false;

            _Composite temp = (_Composite) p;
            if (mComponents.Count != temp.mComponents.Count)
                return false;

            for (int i = 0; i < mComponents.Count; ++i)
            {
                _Term temp1 = (_Term) mComponents[i];
                _Term temp2 = (_Term) temp.mComponents[i];
                if (temp1.CompareTo(temp2) == false)
                    return false;
            }

            return true;
        }
        #endregion
        #region GetArguments : lay toan bo cac tham so cua vi tu (ham)
        public ArrayList GetArguments()
        {
            ArrayList result = new ArrayList();
            
            for (int i = 0; i < mComponents.Count; ++i)
            {
                _Term p = (_Term)mComponents[i];
                result.Add(_Term.arrPatternObject[(int)p.GetType()].NewObject(p));
            }
            return result;
        }
        #endregion
        #region IsAppear : Kiem tra p co nam trong bieu thuc hay khong
        public override Boolean IsAppear(_Term p)
        {
            Boolean flag = false;
            if (p.GetType() == _TypeOfTerm.COMPOSITE)
                return false;

            for (int i = 0; i < mComponents.Count; ++i)
            {
                _Term temp = (_Term)mComponents[i];
                if (temp.GetType() == _TypeOfTerm.COMPOSITE)
                    flag = temp.IsAppear(p);
                else
                    flag = temp.CompareTo(p);

                if (flag == true)
                    return true;
            }
            return false;
        }
        #endregion
        #region Replace :  The term bang tap s
        public override _Term Replace(_MGU s)
        {
            _Term result = null;
            ArrayList temp = new ArrayList();
            for (int i = 0; i < mComponents.Count; ++i)
                temp.Add(this[i].Replace(s));

            result = new _Composite(Name, temp);
            
            return result;
        }
        #endregion
        #endregion
    }
}
