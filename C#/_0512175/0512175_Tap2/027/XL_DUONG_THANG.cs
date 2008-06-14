using System;
public enum VI_TRI_TUONG_DOI
{
    Cat_nhau,
    Song_song,
    Trung_nhau
}
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
    public static VI_TRI_TUONG_DOI Vi_tri_tuong_doi(PHUONG_TRINH_DUONG_THANG D1,
        PHUONG_TRINH_DUONG_THANG D2)
    {
        VI_TRI_TUONG_DOI kq;
        Double D;
        Double Dx;
        Double Dy;
        D = D1.a * D2.b - D2.a * D1.b;
        Dx = D1.b * D2.c - D2.b * D1.c;
        Dy = D1.c * D2.a - D2.c * D1.a;
        if (D != 0)
            kq = VI_TRI_TUONG_DOI.Cat_nhau;
        else
        {
            if (Dx != 0 || Dy != 0)
                kq = VI_TRI_TUONG_DOI.Song_song;
            else
                kq = VI_TRI_TUONG_DOI.Trung_nhau;
        }
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