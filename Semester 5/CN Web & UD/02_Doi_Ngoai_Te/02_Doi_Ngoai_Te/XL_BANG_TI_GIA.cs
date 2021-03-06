using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Doi_Ngoai_Te
{
    public class XL_BANG_TI_GIA
    {
        private static String Ky_Tu_Xuong_Dong = "\r\n";
        private static String ChuoiLoi = "";
        private XL_TI_GIA[] m_BangTiGia;

        public static String XemLoi()
        {
            return ChuoiLoi;
        }
        public XL_BANG_TI_GIA(String szTenFile)
        {
            String szChuoi = LT_TAP_TIN.Doc(szTenFile);
            ChuoiLoi = "";
            if (szChuoi != "")
            {
                String kt = KiemTra(szChuoi);
                if (kt == "")
                {
                    String[] ChuoiDong = szChuoi.Split(new String[] { Ky_Tu_Xuong_Dong }, StringSplitOptions.RemoveEmptyEntries);
                    m_BangTiGia = new XL_TI_GIA[ChuoiDong.Length];
                    for (int i = 0; i < ChuoiDong.Length; ++i)                    
                        m_BangTiGia[i] = new XL_TI_GIA(ChuoiDong[i]);                                        
                }
                else
                    ChuoiLoi = kt;
            }
            else
            {
                ChuoiLoi += "Mở file bị lỗi";
            }
        }
        public static String KiemTra(String szChuoi)
        {
            String kq = "";
            String[] ChuoiDong = szChuoi.Split(new String[] { Ky_Tu_Xuong_Dong }, StringSplitOptions.RemoveEmptyEntries);

            if (ChuoiDong.Length > 0)
            {
                String temp;
                for (int i = 0; i < ChuoiDong.Length; ++i)
                {
                    temp = XL_TI_GIA.KiemTra(ChuoiDong[i]);
                    if (temp != "")
                    {
                        kq += "\nDòng " + i.ToString() + " bị lỗi: " + temp;
                    }
                    else
                    {
                        // Chua xu ly truong hop 2 ky hieu trung nhau
                    }
                }
            }
            else            
                kq += "Bảng tỉ giá phải có ít nhất một dòng";           

            return kq;
        }
        public int LaySoDong()
        {
            return m_BangTiGia.Length;
        }
        public XL_TI_GIA LayDong(int i)
        {
            ChuoiLoi = "";
            if (i < 0 || i >= m_BangTiGia.Length)
            {
                ChuoiLoi += "Không có dòng tương ứng trong bảng tỉ giá";
                return null;
            }

            return m_BangTiGia[i];
        }
        public double LayGiaTri(String szLoaiNgoaiTe, String szHinhThucDoi)
        {
            double kq = -1;
            
            szLoaiNgoaiTe = szLoaiNgoaiTe.Trim();
            szHinhThucDoi = szHinhThucDoi.Trim();
            ChuoiLoi = "";

            if (m_BangTiGia.Length == 0)
            {
                ChuoiLoi += "Bảng tỉ giá chưa có dữ liệu";
            }
            else
            {
                int index;
                for (index = 0; index < m_BangTiGia.Length; ++index)
                    if (String.Compare(m_BangTiGia[index].KyHieu, szLoaiNgoaiTe, true) == 0)
                        break;

                if (index < m_BangTiGia.Length)
                {
                    switch (szHinhThucDoi.ToUpper())
                    {
                        case "MUA_VAO":
                            kq = m_BangTiGia[index].MuaVao;
                            break;
                        case "CHUYEN_KHOAN":
                            kq = m_BangTiGia[index].ChuyenKhoan;
                            break;
                        case "BAN_RA":
                            kq = m_BangTiGia[index].BanRa;
                            break;
                        default:
                            ChuoiLoi += "Không có hình thức đổi tương ứng";                            
                            break;
                    }
                }
                else
                    ChuoiLoi += "Không có loại ngoại tệ tương ứng với '" + szLoaiNgoaiTe + "'";
            }

            return kq;
        }
    }
}
