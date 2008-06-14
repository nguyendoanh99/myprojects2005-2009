using System;

public struct NHI_THUC
{
    public Double a;
    public Double b;
}
class XL_NHI_THUC
{
    public static NHI_THUC Nhap(String Ghi_chu)
    {
        NHI_THUC kq;
        XL_CHUOI.Xuat(Ghi_chu);
        kq.a=XL_SO_THUC.Nhap("Nhap a : ");        
        kq.b = XL_SO_THUC.Nhap("Nhap b : ");        
        return kq;
    }
    public static NGHIEM Tim_Nghiem(NHI_THUC P)
    {
        NGHIEM kq;
        kq.nghiem = _NGHIEM.Co_nghiem;
        kq.x = 0;
        kq.chieu_bpt = CHIEU_BAT_PHUONG_TRINH.Nho_hon;
        if (P.a == 0)
        {
            if (P.b > 0)
                kq.nghiem = _NGHIEM.Vo_so_nghiem;
            else
                kq.nghiem = _NGHIEM.Vo_nghiem;
        }
        else
        {
            kq.nghiem = _NGHIEM.Co_nghiem;
            kq.x = -P.b / P.a;
            if (P.a > 0)
                kq.chieu_bpt = CHIEU_BAT_PHUONG_TRINH.Lon_hon;
            else
                kq.chieu_bpt = CHIEU_BAT_PHUONG_TRINH.Nho_hon;
        }
        return kq;
    }
    public static String Chuoi(NHI_THUC P)
    {
        String kq = "";
        kq = kq + P.a;
        kq = kq + "x";
        if (P.b >= 0)
            kq = kq + "+" + P.b;
        else
            kq = kq + P.b;
        return kq;
    }
}
