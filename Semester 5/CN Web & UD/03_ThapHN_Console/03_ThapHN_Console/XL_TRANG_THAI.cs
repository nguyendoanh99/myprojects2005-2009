using System;
using System.Collections.Generic;
using System.Text;

namespace _3_ThapHN_Console
{
    class XL_TRANG_THAI
    {
        private static String ChuoiLoi = ""; // Ghi nhan cac loi phat sinh
        private int m_iTrangThai;   // 0 : la ham -> m_iN duoc hieu la so dia can chuyen
                                    // 1 : buoc chuyen dia -> m_iN duoc hieu la dia thu m_iN
        private int m_iN;
        private int m_iCotNguon;
        private int m_iCotDich;
        public int TrangThai
        {
            get
            {
                return m_iTrangThai;
            }
        }
        public int N
        {
            get
            {
                return m_iN;
            }
        }
        public int CotNguon
        {
            get
            {
                return m_iCotNguon;
            }
        }
        public int CotDich
        {
            get
            {
                return m_iCotDich;
            }
        }
        public static String XemLoi()
        {
            return ChuoiLoi;
        }
        public XL_TRANG_THAI(int iTrangThai, int iN, int iCotNguon, int iCotDich)
        {
            ChuoiLoi = "";
            // Kiem tra iTrangThai
            if (iTrangThai < 0 || iTrangThai > 1)
            {
                ChuoiLoi += "\niTrangThai chi nhan gia tri 0 hoac 1";
                m_iTrangThai = 0;
            }
            else
                m_iTrangThai = iTrangThai;
            // Kiem tra iN
            if (iN <= 0)
            {
                ChuoiLoi += "\niN chi nhan cac gia tri lon hon 0";
                m_iN = 1;
            }
            else 
                m_iN = iN;
            m_iCotNguon = iCotNguon;
            m_iCotDich = iCotDich;
        }
    }
}