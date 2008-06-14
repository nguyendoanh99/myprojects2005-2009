using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Giai_PT_Trung_Phuong
{
    class XL_PT_TRUNG_PHUONG: XL_TAM_THUC
    {
        public XL_PT_TRUNG_PHUONG(float a, float b, float c): base(a, b, c)
        {            
        }
        public new XL_NGHIEM_PT_TRUNG_PHUONG GiaiPT()
        {
            XL_NGHIEM_PT_TRUNG_PHUONG kq = new XL_NGHIEM_PT_TRUNG_PHUONG();
            XL_NGHIEM nghiem2;
            nghiem2 = base.GiaiPT();

            foreach (float x in nghiem2)
            {
                if (x > 0)
                {
                    kq.Add((float)Math.Sqrt((double)x));
                    kq.Add(-(float)Math.Sqrt((double)x));
                }
                else
                    if (x == 0)
                        kq.Add(0);
            }
            return kq;
        }
    }
}
