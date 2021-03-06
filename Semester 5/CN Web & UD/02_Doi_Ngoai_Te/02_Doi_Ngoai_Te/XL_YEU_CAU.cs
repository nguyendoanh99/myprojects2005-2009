using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Doi_Ngoai_Te
{
    class XL_YEU_CAU
    {
        private static String ChuoiLoi = "";
        private double m_dSoTienCanDoi;
        private String m_szLoaiNgoaiTe;
        private String m_szHinhThucDoi;
        public static XL_BANG_TI_GIA BangTiGia;

        public static String XemLoi()
        {
            return ChuoiLoi;
        }
        public XL_YEU_CAU(double dSoTienCanDoi, String szLoaiNgoaiTe, String szHinhThucDoi)
        {
            ChuoiLoi = "";
            if (dSoTienCanDoi < 0)
            {
                ChuoiLoi += "dSoTienCanDoi phải lớn hơn 0";
                m_dSoTienCanDoi = 1;
            }
            else
                m_dSoTienCanDoi = dSoTienCanDoi;
            // Kiem tra LoaiNgoaiTe, HinhThucDoi co trong bang ti gia hay khong
            BangTiGia.LayGiaTri(szLoaiNgoaiTe, szHinhThucDoi);
            ChuoiLoi += XL_BANG_TI_GIA.XemLoi();
            // Dua cac gia tri nhap vao cac thuoc tinh tuong ung bat chap co loi hay khong
            m_szLoaiNgoaiTe = szLoaiNgoaiTe;
            m_szHinhThucDoi = szHinhThucDoi;
        }

        public double QuiDoi()
        {
            ChuoiLoi = "";
            double kq;
            double DonViTinh = BangTiGia.LayGiaTri(m_szLoaiNgoaiTe, m_szHinhThucDoi);
            ChuoiLoi += XL_BANG_TI_GIA.XemLoi();
            kq = m_dSoTienCanDoi * DonViTinh;
            return kq;
        }
    }
}
