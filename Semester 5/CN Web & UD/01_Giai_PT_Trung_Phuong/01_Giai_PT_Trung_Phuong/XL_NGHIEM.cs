using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
namespace _1_Giai_PT_Trung_Phuong
{
    public class XL_NGHIEM: ArrayList
    {
        public String Chuoi()
        {
            String kq = "";
            switch (this.Count)
            {
                case 0:
                    kq = "Phương trình vô nghiệm";
                    break;
                case 1:
                    kq = "Phương trình có nghiệm kép:\n";
                    kq += "x = " + this[0].ToString();
                    break;
                case 2:
                    kq = "Phương trình có 2 nghiệm phân biệt:\n";
                    kq += "x1 = " + this[0].ToString();
                    kq += "\nx2 = " + this[1].ToString();
                    break;
            }

            return kq;
        }
    }
}
