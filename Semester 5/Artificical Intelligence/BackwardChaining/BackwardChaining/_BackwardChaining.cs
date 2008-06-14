using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace BackwardChaining
{
    class _BackwardChaining
    {
        #region Khai bao thuoc tinh
        struct _Item
        {
            public _Variable val; // Bien
            public int Count; // So lan xuat hien cua bien
        }        
        _KB mKB; // Chua tap KB
        ArrayList mVariable; // Danh sach cac _It   em
        ArrayList mResult;
        _Term mG; // Chua cau truy van da bien doi
        #endregion
        #region Khai bao property
        public int Count
        {
            get
            {
                return mResult.Count;
            }
        }
        public _MGU this[int index]
        {
            get
            {
                return (_MGU)mResult[index];
            }
        }
        #endregion
        #region Khai bao ham rieng
        private void Run(ArrayList goals, _MGU theta)
        {
            #region if (goals.Count == 0)
            if (goals.Count == 0)
            {
                mResult.Add(theta);
                ArrayList ListVariable = mG.GetListOfVariable();
                _MGU result = new _MGU();
                #region for (int j = 0; j < ListVariable.Count; ++j) : thay tap the thanh ket qua cuoi cung
                for (int j = 0; j < ListVariable.Count; ++j)
                {
                    _Variable val = (_Variable)ListVariable[j];
                    result.Add(new _Element(new _Variable(val.Name.Replace("?", "")), val.Replace(theta)));
                }
                #endregion
                #region Kiem tra ket qua vua tim duoc da co hay chu
                Boolean flag = false;
                for (int i = 0; i < mResult.Count; ++i)
                {
                    _MGU temp = (_MGU) mResult[i];
                    if (temp.CompareTo(result) == true)
                    {
                        flag = true;
                        break;
                    }
                }
                #endregion
                if (flag == false) // Chi nhan cac ket qua chua co
                    mResult.Add(result);

                return;
            }
            #endregion
            _Term firstGoals = (_Term)goals[0];
            _Term q1 = firstGoals.Replace(theta);
            #region for (int i = 0; i < mKB.Count; ++i)
            for (int i = 0; i < mKB.Count; ++i)
            {
                _Term q = mKB[i].Right;
                _Unify u = new _Unify(q, q1);
                _MGU Temptheta1; // Chua phep the cua viec dong nhat q1 voi q, co dang {x/y, y/A)
                _MGU tempMGU = new _MGU(); // Chua phep the o dang trung gian, chi dung de the vao p1,...,pn, dang {x/x0, y/y0}
                _MGU theta1 = new _MGU(); // Phep the that su (da thay doi ten bien) cua phep dong nhat q1 voi q, co dang {x0/y0, y0/A}

                #region if (u.Run(out Temptheta1) == true)
                if (u.Run(out Temptheta1) == true)
                {
                    #region for (int j = 0; j < Temptheta1.Count; ++j) doi ten bien trong tap the de co tap the moi la theta1
                    ArrayList arrIndex = new ArrayList(); // Ghi nhan nhung bien nao xuat hien (tuc la bien count tang)
                    for (int j = 0; j < Temptheta1.Count; ++j)
                    {
                        #region if (theta.Find((_Term)Temptheta1[j].Arg1) != null)
                        // Neu bien da co trong theta (tuc la bien co lien quan den cac phep the khac),
                        // thi khong doi ten
                        if (theta.Find((_Term)Temptheta1[j].Arg1) != null)
                        {
                            theta1.Add(Temptheta1[j]);
                            continue;
                        }
                        #endregion
                        #region for (k = 0; k < mVariable.Count; ++k)
                        // Kiem tra xem bien cua Temptheta1[j] da xuat hien chua
                        int k;
                        Boolean flag = false;
                        for (k = 0; k < mVariable.Count; ++k)
                        {
                            _Item tempItem = (_Item)mVariable[k];
                            if (Temptheta1[j].Arg1.CompareTo(tempItem.val))
                            {
                                flag = true;
                                break;
                            }
                        }
                        #endregion
                        #region if (flag == false)
                        // Neu chua co bien thi them vao tap hop, con neu bien da xuat hien thi tang so lan xuat hien len 1 don vi
                        _Item ItemTemp;
                        if (flag == false)
                        {
                            ItemTemp = new _Item();
                            ItemTemp.val = new _Variable(Temptheta1[j].Arg1);
                            ItemTemp.Count = 0;
                            mVariable.Add(ItemTemp);
                        }
                        else
                        {
                            ItemTemp = (_Item)mVariable[k];
                            ItemTemp.Count++;
                            mVariable[k] = ItemTemp;
                            arrIndex.Add(k);
                            // Doi ten bien va dua vao tap theta1
                            
                        }
//                        theta1.Add(new _Element(new _Variable(ItemTemp.val.Name + "_" + ItemTemp.Count.ToString()), Temptheta1[j].Arg2));
                        _Term tempArg2 = new _Variable(ItemTemp.val.Name + "_" + ItemTemp.Count.ToString());
                        theta1.Add(new _Element(Temptheta1[j].Arg1, tempArg2));
                        theta1.Add(new _Element((_Variable) tempArg2, Temptheta1[j].Arg2));
                        tempMGU.Add(new _Element(Temptheta1[j].Arg1, theta1[theta1.Count - 1].Arg1));
                        #endregion
                    }
                    #endregion
                    _MGU tempTheta = theta + theta1;
                    #region tempGoals = [p1,...,pn] | Rest(goals)
                    ArrayList tempGoals = new ArrayList();
                    #region for (int j = 0; j < mKB[i].Left.Count; ++j)
                    // Them p1,...,pn vao tempGoals, cac phan tu truoc khi them vao da duoc doi ten bien
                    for (int j = 0; j < mKB[i].Left.Count; ++j)
                    {
                        _Term t = (_Term)mKB[i].Left[j];
//                        tempGoals.Add(t.Replace(tempMGU));
                        tempGoals.Add(t.Replace(theta1));
                    }
                    #endregion
                    #region for (int j = 1; j < goals.Count; ++j)
                    // Them cac rest(goals) vao tempGoals, loai bo cac phan tu trung
                    for (int j = 1; j < goals.Count; ++j)
                    {
                        Boolean flag = false;
                        _Term t2 = (_Term)goals[j];
                        for (int k = 0; k < tempGoals.Count; ++k)
                        {
                            _Term t1 = (_Term)tempGoals[k];

                            if (t1.CompareTo(t2))
                            {
                                flag = true;
                                break;
                            }
                        }

                        if (flag == false)
                            tempGoals.Add(goals[j]);
                    }
                    #endregion
                    #endregion
                    Run(tempGoals, tempTheta);
                    #region for (int j = 0; j < arrIndex.Count; ++j)
                    // Giam bien count, chi ap dung cho nhung bien ma count thay doi
                    for (int j = 0; j < arrIndex.Count; ++j)
                    {
                        _Item ItemTemp;
                        int k = (int) arrIndex[j];
                        ItemTemp = (_Item)mVariable[k];
                        ItemTemp.Count--;
                        mVariable[k] = ItemTemp;
                    }
                    #endregion
                }
                #endregion
            }
            #endregion
        }
        #endregion
        #region Khai bao phuong thuc
        #region Ham tao
        public _BackwardChaining(_KB p)
        {
            mKB = new _KB();
            #region for (int i = 0; i < p.Count; ++i)
            for (int i = 0; i < p.Count; ++i)
            {
                _Horn horn = (_Horn)p[i];
                ArrayList left = new ArrayList();
                _Term right;
                _MGU tempMgu = new _MGU();
                #region Lay tat ca cac bien o 1 dong
                ArrayList arrVal = new ArrayList();
                arrVal = horn.Right.GetListOfVariable2();
                for (int j = 0; j < horn.Left.Count; ++j)
                {
                    _Term tempTerm = (_Term)horn.Left[j];
                    ArrayList arrValLeft = tempTerm.GetListOfVariable2();
                    for (int l = 0; l < arrValLeft.Count; ++l)
                    {
                        _Variable v1 = (_Variable)arrValLeft[l];
                        Boolean flag1 = false;
                        for (int k = 0; k < arrVal.Count; ++k)
                        {
                            _Variable v2 = (_Variable)arrVal[k];
                            if (v1.CompareTo(v2))
                            {
                                flag1 = true;
                                break;
                            }
                        }
                        if (flag1 == false)
                            arrVal.Add(arrValLeft[l]);
                    }
                }
                #endregion
                for (int j = 0; j < arrVal.Count; ++j)
                {
                    _Variable t = (_Variable)arrVal[j];
                    _Term tempArg2 = new _Variable(t.Name + "." + i);
                    tempMgu.Add(new _Element(t, tempArg2));
                }
                for (int j = 0; j < horn.Left.Count; ++j)
                {
                    _Term temp = (_Term) horn.Left[j];
                    left.Add(temp.Replace(tempMgu));
                }
                right = horn.Right.Replace(tempMgu);
                mKB.Add(new _Horn(left, right));
            }
            #endregion
            
        }
        #endregion
        #region Run : thuc hien thuat toan
        public void Run(_Term goal)
        {
            mVariable = new ArrayList();
            mResult = new ArrayList();
            _MGU theta = new _MGU();
            ArrayList _goals = new ArrayList();
            // Tien xu ly
            if (goal.GetType() == _TypeOfTerm.COMPOSITE)
                mG = new _Composite((_Composite)goal).ExtraName("?");
            else
                if (goal.GetType() == _TypeOfTerm.VARIABLE)
                    mG = new _Variable("?" + goal.Name);
                else
                    mG = new _Constant(goal);

            _goals.Add(mG);
            Run(_goals, theta);
        }
        #endregion
        #region GetResult : tra ve ket qua cua thuat toan
        public String GetResult()
        {
            String result = "";
            Boolean flag = false;
            ArrayList ListVariable = new ArrayList();
            // Cau truy van co chua bien
            if (mG.GetType() == _TypeOfTerm.COMPOSITE)
            {
                _Composite temp = (_Composite)mG;
                ListVariable = temp.GetListOfVariable();
                if (temp.CountVariable > 0)
                    flag = true;
            }
            else
                if (mG.GetType() == _TypeOfTerm.VARIABLE)
                {
                    flag = true;
                    ListVariable.Add(mG);
                }

            if (flag == true)
            {
                if (mResult.Count == 0) // khong co dap an
                    result += "False";
                else
                {
                    
                    for (int i = 0; i < mResult.Count; ++i)
                    {
                        _MGU temp = (_MGU)mResult[i];
                        for (int j = 0; j < temp.Count; ++j)
                        {
                            result += temp[j].ToString() + ", ";
                        }
                        result += "\n";
                    }                    
                    result = result.Replace(", \n", "\n");
                    result = result.Substring(0, result.Length - 1);
                }
            }
            else
            {
                result += (mResult.Count > 0);
            }
            return result;
        }
        #endregion
        #endregion
    }
}
