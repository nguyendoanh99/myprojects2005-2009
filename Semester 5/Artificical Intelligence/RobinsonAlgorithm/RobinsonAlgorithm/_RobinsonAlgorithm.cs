using System;
using System.Collections.Generic;
using System.Text;

namespace RobinsonAlgorithm
{
    class _RobinsonAlgorithm
    {
        #region Khai bao thuoc tinh
        private _KB mKB; // tap co so tri thuc
        private _KB[] mArrTest; // tap hop cac cau can test, da duoc chuyen thanh dang KB (tuc la da lay phu dinh cua cau can test)
        #endregion
        #region Khai bao phuong thuc
        #region ReadFile : Doc noi dung tu file de chuyen thanh du lieu cua doi tuong
        // Doc noi dung tu file de chuyen thanh du lieu cua doi tuong
        public void ReadFile(String filename)
        {
                        
            String str = _FileProcess.ReadFile(filename);
            // Loi doc file
            if (str == "")
            {
                Console.WriteLine("Khong doc duoc file");
                return;
            }
            else
            {
                String[] temp = str.Split(new String[] { "KB", "END KB" }, StringSplitOptions.RemoveEmptyEntries);
                // Phan tich chuoi temp[0] de tao KB gia thiet
                mKB = new _KB();
                String[] arrClause = temp[0].Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < arrClause.Length; ++i)
                    mKB.AddClause(new _Clause(arrClause[i]));
                Console.WriteLine(mKB);

                // Phan tich chuoi temp[1] de tao KB ket qua
                String[] arrTest = temp[1].Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                mArrTest = new _KB[arrTest.Length];
                for (int i = 0; i < mArrTest.Length; ++i)
                {
                    mArrTest[i] = _KB.ConclusionToKB(arrTest[i].Replace("S:", ""));
                    Console.WriteLine(mArrTest[i]);
                }
            }
        }
        #endregion
        #region RunAlgorithm :
        public String RunAlgorithm(int index)
        {
            String result = "";
            if (index >= 0 && index < mArrTest.Length)
            {
                _KB kb = mKB + mArrTest[index];

            }

            return result;
        }
        #endregion

        #endregion
    }
}
