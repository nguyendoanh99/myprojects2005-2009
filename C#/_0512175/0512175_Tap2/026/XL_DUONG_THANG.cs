using System;
public struct PHUONG_TRINH_DUONG_THANG
{
    public Double a;
    public Double b;
    public Double c;
}
class XL_DUONG_THANG
{
    public static PHUONG_TRINH_DUONG_THANG Nhap(String Ghi_chu)
    {
        PHUONG_TRINH_DUONG_THANG kq;
        XL_CHUOI.Xuat(Ghi_chu);
        kq.a = XL_SO_THUC.Nhap("Nhap a:");
        kq.b = XL_SO_THUC.Nhap("Nhap b:");
        kq.c = XL_SO_THUC.Nhap("Nhap c:");        
        return kq;
    }
    public static Double Khoang_cach(PHUONG_TRINH_DUONG_THANG D, DIEM I)
    {
        Double kq;
        kq = Math.Abs(D.a * I.x + D.b * I.y + D.c) / (D.a * D.a + D.b * D.b);
        return kq;
    }
    public static String Chuoi(PHUONG_TRINH_DUONG_THANG D)
    {
        String kq = "";
        kq = kq + D.a + "x";
        if (D.b >= 0)
            kq = kq + "+" + D.b;
        else
            kq = kq + D.b;
        kq = kq + "y";
        if (D.c >= 0)
            kq = kq + "+" + D.c;
        else
            kq = kq + D.c;
        kq = kq + "=0";
        return kq;
    }
}