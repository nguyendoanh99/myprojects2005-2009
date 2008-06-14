using System;
using System.Collections.Generic;
using System.Text;

namespace _3_ThapHN_Console
{
    class XL_THAP_HN
    {
        private static String ChuoiLoi; // Ghi nhan cac loi phat sinh
        private int m_iSoDia; // So dia cua bai toan thap Ha Noi
        private int m_iCotNguon; // nhan cac gia tri 1, 2, 3
        private int m_iCotDich; // nhan cac gia tri 1, 2, 3        
        private Stack<XL_TRANG_THAI> m_StackTrangThai; // Luu lai cac lenh trong ham de qui
        public String XemLoi()
        {
            return ChuoiLoi;
        }
        // Di chuyen iSoDia tu cot iCotNguon sang cot iCotDich (iCotNguon <> iCotDich)
        // iSoDia : So dia cua bai toan ( > 0)
        // iCotNguon, iCotDich chi nhan mot trong cac gia tri 1, 2, 3
        public XL_THAP_HN(int iSoDia, int iCotNguon, int iCotDich)
        {
            ChuoiLoi = "";
            try
            {
                m_StackTrangThai = new Stack<XL_TRANG_THAI>();
            }
            catch (Exception e)
            {
                ChuoiLoi += "\nKhoi tao Stack bi loi";
            }
            // Kiem tra iSoDia
            if (iSoDia > 0)
                m_iSoDia = iSoDia;
            else
            {
                m_iSoDia = 1; // Cho gia tri mac dinh
                ChuoiLoi += "\niSoDia phai nhan gia tri lon hon 0";
            }
            // Kiem tra iCotNguon 
            if (iCotNguon <= 0 || iCotNguon > 3)
            {
                m_iCotNguon = 1; // Cho gia tri mac dinh
                ChuoiLoi += "\niCotNguon chi duoc nhan gia tri 1, 2, 3";
            }
            else            
                m_iCotNguon = iCotNguon;
            // Kiem tra iCotDich
            if (iCotDich <= 0 || iCotDich > 3)
            {
                m_iCotDich = (m_iCotNguon % 3) + 1; // Cho gia tri mac dinh
                ChuoiLoi += "\niCotDich chi duoc nhan gia tri 1, 2, 3";
            }
            else
            {
                if (iCotNguon == iCotDich)
                {
                    ChuoiLoi += "\niCotNguon phai khac iCotDich";
                    m_iCotDich = (m_iCotNguon % 3) + 1; // Cho gia tri mac dinh
                }
                else
                    m_iCotDich = iCotDich;
            }
            
            BatDauLai();
        }
        // Lam lai tu dau
        public void BatDauLai()
        {
            m_StackTrangThai.Clear();
            m_StackTrangThai.Push(new XL_TRANG_THAI(0, m_iSoDia, m_iCotNguon, m_iCotDich));
        }
        // Lay cach doi dia tiep theo trong qua trinh di chuyen dia
        // = null ket thuc qua trinh di chuyen dia
        public XL_TRANG_THAI LayCachDoiDiaKeTiep()
        {
            XL_TRANG_THAI kq;
            
            if (m_StackTrangThai.Count == 0)
                kq = null;
            else
            {
                kq = m_StackTrangThai.Pop();
                while (kq.TrangThai == 0) // la ham
                {
                    if (kq.N == 1)
                    {
                        m_StackTrangThai.Push(new XL_TRANG_THAI(1, 1, kq.CotNguon, kq.CotDich));
                    }
                    else
                    {
                        m_StackTrangThai.Push(new XL_TRANG_THAI(0, kq.N - 1, 6 - (kq.CotNguon + kq.CotDich), kq.CotDich));
                        m_StackTrangThai.Push(new XL_TRANG_THAI(1, kq.N, kq.CotNguon, kq.CotDich));
                        m_StackTrangThai.Push(new XL_TRANG_THAI(0, kq.N - 1, kq.CotNguon, 6 - (kq.CotNguon + kq.CotDich)));
                    }
                    kq = m_StackTrangThai.Pop();
                }            
            }

            return kq;
        }
    }
}