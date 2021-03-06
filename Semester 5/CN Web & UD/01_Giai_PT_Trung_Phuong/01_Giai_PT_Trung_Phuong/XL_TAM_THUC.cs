using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Giai_PT_Trung_Phuong
{
    class XL_TAM_THUC
    {
        private static String ChuoiLoi = "";
        private float m_A;
        private float m_B;
        private float m_C;

        public String XemLoi()
        {
            return ChuoiLoi;
        }
        public XL_TAM_THUC(float A, float B, float C)
        {
            ChuoiLoi = "";
            if (A == 0)
            {
                ChuoiLoi = "Hệ số A phải khác 0";
                m_A = 1;
            }
            else
                m_A = A;
            m_B = B;
            m_C = C;
        }
        public XL_NGHIEM GiaiPT()
        {
            XL_NGHIEM kq = new XL_NGHIEM();

            float delta = m_B * m_B - 4 * m_A * m_C;
            if (delta > 0)
            {
                float temp = (float) Math.Sqrt((double)delta);
                kq.Add((-m_B + temp) / (2 * m_A));
                kq.Add((-m_B - temp) / (2 * m_A));
            }
            else
                if (delta == 0)
                {
                    kq.Add(-m_B / (2 * m_A));
                }

            return kq;
        }
    }
}
