using System;
using System.Collections.Generic;
using System.Text;
public struct LOAIPHONG
{
    public String Ten;
    public long DonGia;
}
class XuLyLoaiPhong
{
    private static String ChuoiPhanCach = ":";    
    public static Boolean SoSanh(LOAIPHONG A, LOAIPHONG B)
    {
        Boolean flag = A.Ten.CompareTo(B.Ten)==0;
        flag = flag && A.DonGia == B.DonGia;
        return flag;
    }
    public static LOAIPHONG KhoiTao(String Chuoi)
    {
        LOAIPHONG kq;
        kq.DonGia = long.MinValue;
        kq.Ten = "";
        if (KiemTra(Chuoi))
        {
            String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
            kq.Ten = M[0].Trim();
            kq.DonGia = long.Parse(M[1]);
        }
        return kq;
    }
    public static Boolean KiemTra(String Chuoi)
    {
        Boolean flag = true;
        String[] M = Chuoi.Split(new String[] { ChuoiPhanCach },
                StringSplitOptions.None);
        flag = M.Length == 2;
        flag= flag && XuLySoNguyen.KiemTra(M[1]);
        return flag;
    }
    public static String XuatChuoi(LOAIPHONG P)
    {
        String Chuoi=P.Ten+" : ";
        Chuoi = Chuoi + P.DonGia + " dong/ngay";
        return Chuoi;
    }
    public static Double TinhTien(LOAIPHONG P,PHIEUTHUE Phieu)
    {
        Double kq = 0;
        if (SoSanh(P,Phieu.LoaiPhong))
            kq = (Double)(P.DonGia * Phieu.SoNgay);
        return kq;
    }
}