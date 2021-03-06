using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace _1_Giai_PT_Trung_Phuong
{
    class XL_NGHIEM_PT_TRUNG_PHUONG: ArrayList
    {
        public String Chuoi()
        {
            String kq = "";

            if (this.Count == 0)
                kq += "Phương trình vô nghiệm";
            else
            {
                kq += "Phương trình có " + this.Count.ToString() + " nghiệm:";
                for (int i = 0; i < this.Count; ++i)
                    kq += "\nx" + (i + 1).ToString() + " = " + this[i].ToString();

                if (this.Count == 1)
                    kq = kq.Replace("x1", "x");
            }
            return kq;
        }
    }
}
