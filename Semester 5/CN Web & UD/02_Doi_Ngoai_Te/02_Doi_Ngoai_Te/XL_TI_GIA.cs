using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Doi_Ngoai_Te
{
    public class XL_TI_GIA
    {
        private static char Ky_Tu_Phan_Cach = '\t';
        private static String ChuoiLoi = "";
        private String m_szKyHieu;
        private String m_szTenNgoaiTe;
        private double m_dMuaVao;
        private double m_dChuyenKhoan;
        private double m_dBanRa;

        public static char LayKyTuPhanCach()
        {
            return Ky_Tu_Phan_Cach;
        }

        public String KyHieu
        {
            get
            {
                return m_szKyHieu;
            }
        }
        public String TenNgoaiTe
        {
            get
            {
                return m_szTenNgoaiTe;
            }
        }
        public double MuaVao
        {
            get 
            {
                return m_dMuaVao;
            }
        }
        public double ChuyenKhoan
        {
            get
            {
                return m_dChuyenKhoan;
            }
        }
        public double BanRa
        {
            get
            {
                return m_dBanRa;
            }
        }
        public static String XemLoi()
        {
            return ChuoiLoi;
        }
        private void KhoiTao(String szKyHieu, String szTenNgoaiTe, double dMuaVao,
            double dChuyenKhoan, double dBanRa)
        {
            ChuoiLoi = "";
            m_szKyHieu = szKyHieu;
            m_szTenNgoaiTe = szTenNgoaiTe;
            // Kiem tra dMuaVao
            if (dMuaVao < 0)
            {
                ChuoiLoi += "dMuaVao phải lớn hơn 0";
                m_dMuaVao = 0;
            }
            else
                m_dMuaVao = dMuaVao;
            // Kiem tra dChuyenKhoan
            if (dChuyenKhoan < 0)
            {
                ChuoiLoi += "dChuyenKhoan phải lớn hơn 0";
                m_dChuyenKhoan = 0;
            }
            else
                m_dChuyenKhoan = dChuyenKhoan;
            // Kiem tra dBanRa
            if (dBanRa < 0)
            {
                ChuoiLoi += "dBanRa phải lớn hơn 0";
                m_dBanRa = 0;
            }
            else
                m_dBanRa = dBanRa;
        }
        public XL_TI_GIA(String szKyHieu, String szTenNgoaiTe, double dMuaVao,
            double dChuyenKhoan, double dBanRa)
        {
            KhoiTao(szKyHieu, szTenNgoaiTe, dMuaVao, dChuyenKhoan, dBanRa);
        }
        public XL_TI_GIA(String szThongTin)
        {           
            String kt = KiemTra(szThongTin);
            // Kiem tra du lieu
            if (kt == "")
            {
                String[] Chuoi = szThongTin.Split(new char[] { Ky_Tu_Phan_Cach }, StringSplitOptions.RemoveEmptyEntries);
                m_szKyHieu = Chuoi[0];
                m_szTenNgoaiTe = Chuoi[1];
                m_dMuaVao = double.Parse(Chuoi[2]);
                m_dChuyenKhoan = double.Parse(Chuoi[3]);
                m_dBanRa = double.Parse(Chuoi[4]);
            }
            else
            {
                ChuoiLoi = kt;
            }
        }

        public static String KiemTra(String szThongTin)
        {
            String kq = "";
            String[] Chuoi = szThongTin.Split(new char[] { Ky_Tu_Phan_Cach }, StringSplitOptions.RemoveEmptyEntries);

            if (Chuoi.Length != 5)
            {
                kq += "Chuỗi thông tin tỉ giá cần có 5 cột";
            }
            else
            {
                double temp;
                try
                {
                    temp = double.Parse(Chuoi[2]);
                    if (temp < 0)
                        kq += "\nGiá trị mua vào phải lớn hơn 0";
                }
                catch (Exception e)
                {
                    kq += "\nGiá trị mua vào phải là số thực";
                }

                try
                {
                    temp = double.Parse(Chuoi[3]);
                    if (temp < 0)
                        kq += "\nGiá trị chuyển khoản phải lớn hơn 0";
                }
                catch (Exception e)
                {
                    kq += "\nGiá trị chuyển khoản phải là số thực";
                }

                try
                {
                    temp = double.Parse(Chuoi[4]);
                    if (temp < 0)
                        kq += "\nGiá trị bán ra phải lớn hơn 0";
                }
                catch (Exception e)
                {
                    kq += "\nGiá trị bán ra phải là số thực";
                }
            }

            return kq;
        }
    }
}
